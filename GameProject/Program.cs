using Game.BL.Implement;
using Game.BL.Interface;
using Game.DL.Implement;
using Game.DL.Interface;
using Game.Domain.Data;
using Game.Shared.EFRepositry;
using Microsoft.EntityFrameworkCore;
using static System.Formats.Asn1.AsnWriter;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(option=>option.UseSqlServer(
      builder.Configuration.GetConnectionString("MyConnection")
    ));

#region services
builder.Services.AddTransient<ICategoryService,CategoryService>();
builder.Services.AddTransient<ICategoryRepositry,CategoryRepositry>();
builder.Services.AddTransient<IEFRepositry,EFRepositry>();
builder.Services.AddTransient<IDeviceRepositry,DeviceRepositry>();
builder.Services.AddTransient<IDeviceService,DeviceService>();
#endregion

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
    pattern: "{controller=Category}/{action=Index}/{id?}");

app.Run();
