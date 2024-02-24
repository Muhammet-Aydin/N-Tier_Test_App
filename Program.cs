using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using N_Tier_App_Business.Abstract;
using N_Tier_App_Business.Concrete;
using N_Tier_App_Core.Context;
using N_Tier_App_Dal.Abstract;
using N_Tier_App_Dal.Concrete;
using N_Tier_Test_App_Entities.Concrete;

var builder = WebApplication.CreateBuilder(args);




// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<NTierContext>(
                    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Generic Repository ve Unit of Work konfigürasyonu 
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IOrderService, OrderManager>();
builder.Services.AddScoped<IProductServive, ProductManager>();
builder.Services.AddScoped<IOrderLineService, OrderLineManager>();
builder.Services.AddScoped<IUserService, UserManager>();




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
