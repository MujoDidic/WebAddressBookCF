using Microsoft.EntityFrameworkCore;
using WebAddressBookCF.Data;
using WebAddressBookCF.Services;
using WebAddressBookCF.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//--------------Database---------------------

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

//---------------------Images services------------------

builder.Services.AddScoped<IImageService, BasicImageService>();

//--------------Dodato za datum--------------
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

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
