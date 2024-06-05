using Microsoft.EntityFrameworkCore;
using TripPortal.AutoMapper;
using TripPortal.Data;
using TripPortal.Interfaces;
using TripPortal.Repository;
using TripPortal.Services;
using FluentValidation.AspNetCore;
using TripPortal.Validators;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("TripPortal")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddScoped<ITripRepository, TripRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();

builder.Services.AddTransient<IStudentService, StudentService>();
builder.Services.AddTransient<ITripService, TripService>();
builder.Services.AddTransient<IReservationService, ReservationService>();
builder.Services.AddAutoMapper(options =>
{
    options.AddProfile<AutoMapperProfiles>();
});
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<StudentValidator>());

builder.Services.AddRazorPages();




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
app.MapRazorPages();

app.Run();
