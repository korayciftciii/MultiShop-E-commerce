using Microsoft.AspNetCore.Authentication.JwtBearer;
using MultiShop.Cargo.BusinnessLayer.Abstract;
using MultiShop.Cargo.BusinnessLayer.Concrete;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Concrete;
using MultiShop.Cargo.DataAccessLayer.EntityFramework;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Cargo Api", Version = "v1" });
});
// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority = builder.Configuration["IdentityServerUrl"];
    opt.Audience = "resourceCargo";
    opt.RequireHttpsMetadata = true;
}
);

builder.Services.AddDbContext<CargoContext>();

builder.Services.AddScoped<ICargoCompanyDal, EfCargoCompanyDal>();
builder.Services.AddScoped<ICargoDetailDal, EfCargoDetailDal>();
builder.Services.AddScoped<ICargoCustomerDal, EfCargoCustomerDal>();
builder.Services.AddScoped<ICargoStatueDal, EfCargoStatueDal>();

builder.Services.AddScoped<ICargoCompanyService,CargoCompanyManager>();
builder.Services.AddScoped<ICargoCustomerService, CargoCustomerManager>();
builder.Services.AddScoped<ICargoDetailService, CargoDetailManager>();
builder.Services.AddScoped<ICargoStatueService, CargoStatueManager>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = string.Empty; // Swagger UI'yý kök dizine yerleþtirir
    });
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
