using EmailSender.DAL;
using EmailSender.MVC.Models;
using EmailSender.MVC.Services;
using EmailSender.MVC.Services.Mailing_Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add configuration for mail settings
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));

// Add mailing service as a transient service
builder.Services.AddScoped<IMailingServices, MailingServices>();

//use Lazy Loading and Configuration Of Database
builder.Services.AddDbContext<ApplicationDbContext>(options =>

     options
    .UseLazyLoadingProxies()
    .UseSqlServer(builder.Configuration.GetConnectionString("DataBaseConnection")
));

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

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
app.MapControllerRoute("main", "{controller=Home}/{action=Index}/{id?}");


app.Run();
