// Подключение модулей

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NuGet.Packaging.Signing;
using WebApplicationAuth.Data;
using WebApplicationAuth.Models;

namespace WebApplicationAuth.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        // Внедрение зависимостей
        public Employer? Employer { get; set; }

        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<ApplicationIdentityUser> _signInManager;

        public IndexModel(
            ILogger<IndexModel> logger, 
            SignInManager<ApplicationIdentityUser> signInManager,
            ApplicationDbContext context)
        {
            _logger = logger;
            _signInManager = signInManager;
            _context = context;
        }

        // Обработка загрузки страницы
        public void OnGet()
        {
            if (User.Identity != null)
            { 
                Employer = _context.Employers.Where(c => c.Email == User.Identity.Name).FirstOrDefault();
            }
        }
    }
}