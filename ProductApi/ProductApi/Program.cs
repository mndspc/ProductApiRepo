using ProductApi.Models;
using ProductApi.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();   
builder.Services.AddScoped<IProductRepo<Product>, ProductService>();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();
if (builder.Environment.IsProduction())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();
app.UseCors();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
