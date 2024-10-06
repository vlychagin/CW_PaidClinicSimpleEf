using Microsoft.EntityFrameworkCore;

#region для решения проблемы ввода дробных чисел в поля типа number
using System.Globalization;
using PaidClinicSimpleEf.Models;

CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en");
CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");
#endregion

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Добавление функционала EntityFramework Core как сервиса приложения
var connection = "Server = (localdb)\\mssqllocaldb;Database = UserStore_db;Trusted_Connection=true";
builder.Services.AddDbContext<ApplicationContext>(
    options => options
        // подключение lazy loading, сначала установить NuGet-пакет Microsoft.EntityFrameworkCore.Proxies
        .UseLazyLoadingProxies()
        .UseSqlServer(connection)
);


var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
