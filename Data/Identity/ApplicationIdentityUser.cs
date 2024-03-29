﻿using Microsoft.AspNetCore.Identity;
using WebApplicationAuth.Models;

namespace WebApplicationAuth.Data.Identity
{
    // Объявление класса пользователя
    public class ApplicationIdentityUser : IdentityUser
    {
        public string EmployerName { get; set; } = String.Empty;
        public int EmployerId { get; set; }
        public Employer Employer { get; set; }
    }
}
