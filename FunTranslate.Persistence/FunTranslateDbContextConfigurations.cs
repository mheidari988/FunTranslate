using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FunTranslate.Persistence;
public class FunTranslateDbContextConfigurations : IEntityTypeConfiguration<FunTranslation>
{
    public void Configure(EntityTypeBuilder<FunTranslation> builder)
    {
        builder.Property(fun => fun.Text)
            .IsRequired()
            .HasMaxLength(FunTranslationConsts.Text.MaximumLength);
        builder.Property(fun => fun.Translated)
            .IsRequired()
            .HasMaxLength(FunTranslationConsts.Translated.MaximumLength);
        builder.Property(fun => fun.Translation)
            .IsRequired()
            .HasMaxLength(FunTranslationConsts.Translation.MaximumLength);
    }
}
