using FunTranslate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Shouldly;

namespace FunTranslate.Persistence.IntegrationTests;
public class PersistenceIntegrationTests : IDisposable
{
    private readonly FunTranslateDbContext _context;

    public PersistenceIntegrationTests()
    {
        var builder = new DbContextOptionsBuilder<FunTranslateDbContext>();
        builder.UseSqlServer($"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FunTranslateDb_{Guid.NewGuid()};Integrated Security=True;");
        _context = new FunTranslateDbContext(builder.Options);
        _context.Database.Migrate();
    }

    public async void Dispose() => await _context.Database.EnsureDeletedAsync();

    [Fact]
    public async Task Query_FunTranslate_From_DbContext()
    {
        await _context.FunTranslates.AddRangeAsync(new List<FunTranslation>
        {
            new FunTranslation{ Text = "hello", Translation = "minion", Translated = "bello" },
            new FunTranslation{ Text = "hello", Translation = "yoda", Translated = "force be with you" },
            new FunTranslation{ Text = "hello", Translation = "test3", Translated = "test3" },
            new FunTranslation{ Text = "test4", Translation = "test4", Translated = "test4" },
            new FunTranslation{ Text = "test5", Translation = "test5", Translated = "test5" },
        });
        var afterInsert = await _context.SaveChangesAsync();

        var selectWithFilter = _context.FunTranslates.FromSqlRaw(
            @$"

                  SELECT * FROM dbo.FunTranslates WHERE [Text] = {{0}}

            ", "hello");

        var selectMinionHello = await _context.Set<FunTranslation>()
            .FirstOrDefaultAsync(x => x.Text == "hello" && x.Translation == "minion");

        var test4ToRemove = await _context.FunTranslates.FirstOrDefaultAsync(x => x.Text == "test4");
        _context.FunTranslates.Remove(test4ToRemove!);
        var afterRemove = await _context.SaveChangesAsync();

        afterInsert.ShouldBe(5);
        selectWithFilter.Count().ShouldBe(3);
        selectMinionHello.ShouldNotBeNull().Translated.ShouldBe("bello");
        afterRemove.ShouldBe(1);
    }
}
