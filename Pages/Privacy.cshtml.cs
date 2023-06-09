// Подключение модулей

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplicationAuth.Pages
{
    [Authorize]
    public class PrivacyModel : PageModel
    {
        // Внедрение зависимостей
        private readonly ILogger<PrivacyModel> _logger;

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        // Обработка загрузки страницы
        public void OnGet()
        {
        }
    }
}