using Microsoft.EntityFrameworkCore;
using projet2.Data;
using projet2.Repository;
using projet2.Repository.IRepository;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ApplicationDbContext1>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddEntityFrameworkStores<ApplicationDbContext1>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// utiliser pour modifier les valeur par defaut dans le cookies pour faire redirection vers la correcte page 

//builder.Services.ConfigureApplicationCookie(options =>
//{
//    options.LoginPath = "/Identity/Account/Login"; // path de login 
//    options.LogoutPath = "/Identity/Account/Logout"; // path de logout ...
//    options.AccessDeniedPath = "/Identity/Account/AccessDenied";

//});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllers();

app.MapRazorPages();

app.Run();
