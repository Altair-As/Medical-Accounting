using MessagePack;
using Microsoft.Build.Framework;
using System.Runtime.InteropServices;

namespace WebApplicationAuth.Models
{
    public class Employer
    {
        public int Id { get; set; }
        public string FIO { get; set; } = "John Doe";
        public string ? Speciality { get; set; }
        public string ? Department { get; set; }
        public string? Phone { get; set; }
        public string Email { get; set; } = "test@gmail.com";
        public ApplicationIdentityUser? ApplicationIdentityUser { get; set; }
    }
}
