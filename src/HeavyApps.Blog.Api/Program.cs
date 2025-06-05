using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using OpenAPI3.Api.Data;
using OpenAPI3.Api.Models;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseInMemoryDatabase("openapi3-database");
    options.UseSeeding((x, _) =>
    {
        x.Set<Autor>().AddRange(DbInitializer.Autores);
        x.SaveChanges();
    });
});


// remover referências circulares do JSON
// builder.Services.AddControllers()
//     .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});


builder.Services.AddEndpointsApiExplorer();

builder.Services.AddRazorPages();

builder.Services.AddOpenApi(options =>
{
    options.OpenApiVersion = Microsoft.OpenApi.OpenApiSpecVersion.OpenApi3_0;
});


var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwaggerUI(opt =>
    {
        opt.SwaggerEndpoint("/openapi/v1.json", "OepnAPI 3 API V1");
        //opt.RoutePrefix = "swagger"; // Set Swagger UI at the app's root
    });

    app.UseReDoc(opt =>
    {
        opt.SpecUrl("/openapi/v1.json");
        //opt.RoutePrefix = "docs"; // Set ReDoc UI at /docs
    });

    app.MapScalarApiReference();

    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.MapStaticAssets();
app.MapRazorPages();

app.Run();
