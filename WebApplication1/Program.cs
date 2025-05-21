using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using Microsoft.AspNetCore.Identity;
using WebApplication1.Data;
using WebApplication1.Areas.Identity.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity.UI.Services;
using WebApplication1.EmailVerification;

var builder = WebApplication.CreateBuilder(args);

// Get the connection string from configuration
var connectionString = builder.Configuration.GetConnectionString("WebApplication1ContextConnection")
    ?? throw new InvalidOperationException("Connection string 'WebApplication1ContextConnection' not found.");

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IEmailSender, Email>();
// Register the WebApplication1Context with the connection string
builder.Services.AddDbContext<WebApplication1Context>(options =>
    options.UseSqlServer(connectionString));

// Register Identity services using WebApplication1Context
builder.Services.AddDefaultIdentity<WebApplication1User>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<WebApplication1Context>();

// If regDbContext is another context, register it with its own connection string
builder.Services.AddDbContext<regDbContext>(options =>
    options.UseSqlServer("Server=DESKTOP-PVDQ2LO\\SQLEXPRESS;database=Eventure;Trusted_Connection=True;TrustServerCertificate=True;"));

// Add session services
builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
