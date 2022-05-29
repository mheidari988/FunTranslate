var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddDapperServices(builder.Configuration);
builder.Services.AddAutoMapper(System.Reflection.Assembly.GetExecutingAssembly());
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(opt =>
{
    // No restriction at all
    opt.AddPolicy("Open", b => b.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("Open");
app.UseEndpoints(cnfg => cnfg.MapControllers());

app.Run();
