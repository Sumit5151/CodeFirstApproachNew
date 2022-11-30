using CodeFirstApproach.BAL.EmployeeRepository;
using CodeFirstApproach.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("BrightDB3CS")
    )) ;

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

//add-migration Initialization
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Employee}/{action=Create}/{id?}");

app.Run();
