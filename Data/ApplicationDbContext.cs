using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using feedback.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace feedback.Data;

public class ApplicationDbContext : IdentityDbContext
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IUserStore<IdentityUser> _userStore;
    private readonly IUserEmailStore<IdentityUser> _emailStore;
    private readonly ILogger<ApplicationDbContext> _logger;

    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        
    }
    

    public DbSet<Form> Form { get; set; }
    public DbSet<FormEntry> FormEntry { get; set; }
    public DbSet<DefaultForm> FormDefault { get; set; }
    
}