using ProductApi.Models;
using ProductApi.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();   
builder.Services.AddScoped<IProductRepo<Product>, ProductService>();

var app = builder.Build();
if (builder.Environment.IsProduction())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
