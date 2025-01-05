using System.Security.Claims;
using Edi.Captcha;
using feedback.Controllers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using feedback.Data;
using Localization.Services;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

DotNetEnv.Env.Load();

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.AddMvc()
    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization();

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[] { "ar", "en" };
    options.SetDefaultCulture(supportedCultures[0])
        .AddSupportedCultures(supportedCultures)
        .AddSupportedUICultures(supportedCultures);
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                       throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
    {
        options.SignIn.RequireConfirmedAccount = true;
        options.Tokens.PasswordResetTokenProvider = TokenOptions.DefaultProvider;
    })
    .AddEntityFrameworkStores<ApplicationDbContext>();


builder.Services.Configure<AuthMessageSenderOptions>(options =>
{
    options.SmtpServer = Environment.GetEnvironmentVariable("SmtpServer");
    options.SmtpPort = int.Parse(Environment.GetEnvironmentVariable("SmtpPort") ?? "587");
    options.SmtpUser = Environment.GetEnvironmentVariable("SmtpUser");
    options.SmtpPass = Environment.GetEnvironmentVariable("SmtpPass");
});
builder.Services.AddTransient<IEmailSender, EmailSender>();

builder.Services.AddScoped<ValidateCaptcha>();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20);
    options.Cookie.HttpOnly = false;
});

builder.Services.AddSessionBasedCaptcha();



var app = builder.Build();
var LocalizationOptions = app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value;
app.UseRequestLocalization(LocalizationOptions);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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



app.UseSession().UseCaptchaImage(options =>
{
    options.RequestPath = "/captcha-image";
    options.ImageHeight = 36;
    options.ImageWidth = 100;
});



using (var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
    using (var userManger = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>())
    {
        var user = new IdentityUser(Environment.GetEnvironmentVariable("ADMIN_EMAIL"))
        {
            EmailConfirmed = true,
            Email = Environment.GetEnvironmentVariable("ADMIN_EMAIL"),
        };
        
        userManger.CreateAsync(user,Environment.GetEnvironmentVariable("ADMIN_PASSWORD")).Wait();
    }
   
}


app.Run();