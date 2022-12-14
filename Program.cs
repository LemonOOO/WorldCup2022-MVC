using WorldCup2022_MVC.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WorldCup2022_MVC.Respository;
using WorldCup2022_MVC.Interfaces;
using WorldCup2022_MVC.Services;
using WorldCup2022_MVC.Contexts;
using WorldCup2022_MVC.Models;
using WorldCup2022_MVC.ViewModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var connectionString = builder.Configuration.GetConnectionString("WorldCup2022");
builder.Services.AddDbContext<GroupContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDbContext<GroupStageContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDbContext<TeamContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDbContext<MatchesContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDbContext<KnockoutStageContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDbContext<PromotedTeamsContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDbContext<SimulatedKnockoutPhaseContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddTransient<ITeamRespository, TeamRespository>();
builder.Services.AddTransient<ITeamService, TeamService>();
builder.Services.AddTransient<IGroupStageRespository, GroupStageRespository>();
builder.Services.AddTransient<IGroupStageService, GroupStageService>();
builder.Services.AddTransient<IMatchesRespository, MatchesRespository>();
builder.Services.AddTransient<IMatchesService, MatchesService>();
builder.Services.AddTransient<IKnockoutStageRespository, KnockoutStageRespository>();
builder.Services.AddTransient<IKnockoutStageService, KnockoutStageService>();
builder.Services.AddTransient<IPromotedTeamsRespository, PromotedTeamsRespository>();
builder.Services.AddTransient<IPromotedTeamsService, PromotedTeamsService>();
builder.Services.AddTransient<ISimulatedKnockoutPhaseRespository, SimulatedKnockoutPhaseRespository>();
builder.Services.AddTransient<ISimulatedKnockoutPhaseService, SimulatedKnockoutPhaseService>();
builder.Services.AddControllersWithViews();
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
                name: "PlayGroup",
                pattern: "PlayGroup",
                defaults: new { controller = "PlayGroup", action = "RedirectToPlay" });
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
