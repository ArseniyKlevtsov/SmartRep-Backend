using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using SmartRep_Backend.Domain.interfaces.Services;
using SmartRep_Backend.Infrastructure.Data;
using SmartRep_Backend.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SmartRepDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("MySqlConnection"),
        new MySqlServerVersion(new Version(8, 0, 42)) 
    ));

builder.Services.AddScoped<IFileStorageService, LocalFileStorageService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

var filesPath = Path.GetFullPath(
    Path.Combine(
        builder.Environment.ContentRootPath,
        builder.Configuration["FileStorage:LocalPath"]
    )
);

//Directory.CreateDirectory(filesPath); // Создаём, если нет

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(filesPath),
    RequestPath = "/static-files"
});

app.Run();
