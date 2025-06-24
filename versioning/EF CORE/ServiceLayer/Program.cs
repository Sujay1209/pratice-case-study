using DAL.DataAccess;
using DAL.Models;
using DAL.Models.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

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
//swagger
builder.Services.AddSwaggerGen(options =>
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Events API",
        Description = "Events Application",
        TermsOfService = new Uri("https://www.hexaware.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Shashang Sujay",
            Email = "shashangsujayeeeskct@gmail.com",
            Url = new Uri("https://linkedin.com/soyeb")
        },
        License = new OpenApiLicense
        {
            Name = "Hexaware",
            Url = new Uri("https://hexaware.com/license")
        }
    })
    );
//Default CORS policy
builder.Services.AddCors(options =>
{

    options.AddDefaultPolicy(builder =>
    {
        //To grant access for any domain- for any header -for any methods
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();

        //To grant access for specific domain and for specific methods
        //builder.WithOrigins("http://192.168.2.1", "http://localhost:4200").AllowAnyHeader().WithMethods("GET");
    });
});
//named policy
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowGetAndPost", builder =>
    {
        builder.WithOrigins("http://localhost:60685", "http://localhost:4200").AllowAnyHeader().WithMethods("GET", "POST");
    });
});


var app =builder.Build();
if(builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseSwagger();
app.UseSwaggerUI(c => {
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
});

app.UseEndpoints(endpoints => {  endpoints.MapControllers(); });
app.Run();
