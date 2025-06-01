using SmartRep_Backend.WebApi.Extentions;
using SmartRep_Backend.WebApi.Extentions.ServiceRegistrators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSmartRepServices(builder.Configuration);

var app = builder.Build();
app.UseSmartrepMiddlewares(builder);
 
app.MapControllers();
app.Run();
