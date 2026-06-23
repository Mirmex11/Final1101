using ReadCity.DataAccess;
using ReadCity.DataAccess.ConnectionFactory;
using ReadCity.DataAccess.Repositories;
using ReadCity.DataAccess.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IDbConnectionFactory>(_ => DatabaseConfig.CreateFactory());
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<OrderRepository>();
builder.Services.AddScoped<LookupRepository>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<AuthService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new() { Title = "Читай город API", Version = "v1" });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Читай город API v1");
    options.RoutePrefix = string.Empty;
});

app.MapControllers();

app.Run();
