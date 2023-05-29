using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AutenticacaoUsuario.Areas.Identity.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AutenticacaoUsuarioIdentityDbContextConnection") ?? throw new InvalidOperationException("Connection string 'AutenticacaoUsuarioIdentityDbContextConnection' not found.");

builder.Services.AddDbContext<AutenticacaoUsuarioIdentityDbContext>(options => options.UseSqlite(connectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<AutenticacaoUsuarioIdentityDbContext>();

// Add services to the container.
builder.Services.AddRazorPages();

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

app.UseAuthorization();

app.MapRazorPages();

app.Run();
