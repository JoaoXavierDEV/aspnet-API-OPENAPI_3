using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers()
    .AddApplicationPart(typeof(HeavyApps.Blog.Presentation.Controllers.IAssemblyReferenceControllers).Assembly);

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
        opt.SwaggerEndpoint("/openapi/v1.json", "HeavyApps.Blog API V1");
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
