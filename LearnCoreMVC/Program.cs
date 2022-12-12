using Data.Accesslayer;
using Data.Accesslayer.Models;
using Microsoft.EntityFrameworkCore;
using Business.Layer;
using Microsoft.AspNetCore.Http.Json;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddControllers().AddJsonOptions(options =>
//               options.JsonSerializerOptions.PropertyNamingPolicy = null);

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddDbContext<Learn_DBContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("constring")));

builder.Services.AddScoped<IEmployeeDA, EmployeeDA>();
builder.Services.AddScoped<IEmployeeBC, EmployeeBC>();
//builder.Services.Configure<JsonOptions>(options =>
//{
//    options.SerializerOptions.PropertyNameCaseInsensitive = false;
//    options.SerializerOptions.PropertyNamingPolicy = null;
//    options.SerializerOptions.WriteIndented = true;
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
