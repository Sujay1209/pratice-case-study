using DAL.DataAccess;
using DAL.Models;
using DAL.Models.DAL.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

//To register dependencies
//builder.Services.AddScoped<IEventDetailsRepo<EventDetails>, EventDetailsRepo>();
builder.Services.AddScoped<IEventDetailsRepo<EventDetails>, EventDetailsRepo>();
//Api Versioning
builder.Services.AddApiVersioning(options =>
{
    //To configure default API Versioning
    options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
});

var app =builder.Build();
if(builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.UseRouting();
app.UseEndpoints(endpoints => {  endpoints.MapControllers(); });
app.Run();
