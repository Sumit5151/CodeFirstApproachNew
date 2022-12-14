using CodeFirstApproach.BAL.AccountService;
using CodeFirstApproach.BAL.EmployeeRepository;
using CodeFirstApproach.DAL;
using Microsoft.EntityFrameworkCore;





var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("BrightDB3CS")
    ));

builder.Services.AddHttpContextAccessor();
builder.Services.AddSession(
    options=> options.IdleTimeout = TimeSpan.FromMinutes(10)
    );


builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IAccoutService, AccountService>();

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

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=EmployeeAjax}/{action=Index}/{id?}");

app.Run();
