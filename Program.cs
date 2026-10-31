using Microsoft.EntityFrameworkCore;
using SmartClinic.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrWhiteSpace(connectionString) || connectionString.Contains("Server=", StringComparison.OrdinalIgnoreCase))
{
    connectionString = "Data Source=smartclinic.db";
}

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.EnsureCreated();
    if (!db.Patients.Any())
    {
        db.Patients.AddRange(
            new SmartClinic.Models.Patient { FullName = "Sarah Jenkins", Email = "sarah.j@example.com", PhoneNumber = "(555) 234-5678", DateOfBirth = new DateTime(1992, 4, 15), Gender = "Female" },
            new SmartClinic.Models.Patient { FullName = "Michael Chang", Email = "m.chang@example.com", PhoneNumber = "(555) 345-6789", DateOfBirth = new DateTime(1988, 10, 20), Gender = "Male" },
            new SmartClinic.Models.Patient { FullName = "Emma Watson", Email = "emma.w@example.com", PhoneNumber = "(555) 456-7890", DateOfBirth = new DateTime(1995, 6, 8), Gender = "Female" },
            new SmartClinic.Models.Patient { FullName = "David Miller", Email = "dmiller@example.com", PhoneNumber = "(555) 567-8901", DateOfBirth = new DateTime(1979, 12, 1), Gender = "Male" }
        );
        db.SaveChanges();
    }
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Appointment}/{action=Index}/{id?}");

app.Run();
