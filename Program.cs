
using AutenticacaoUsuario;
using AutenticacaoUsuario.Data;
using AutenticacaoUsuario.Models;
using AutenticacaoUsuario.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'AutenticacaoUsuarioIdentityDbContextConnection' not found.");

builder.Services.AddDbContext<AutenticacaoUsuario.Data.DbContext>(options => options.UseSqlite(connectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<AutenticacaoUsuario.Data.DbContext>();

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddSingleton<IEmailSender, EmailSender>();

var app = builder.Build();

var sendGridKey = new Configuration.SendGridConfig();
app.Configuration.GetSection("SendGridKey").Bind(sendGridKey);
Configuration.SendGridKey = sendGridKey;

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
