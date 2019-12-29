using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace PEngine.Common.Models.Schema
{
    public class UserModel : IdentityUser<long>
    {
        public string Signature { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime LastLogin { get; set; }
        
        private new string PhoneNumber { get; set; }
        private new string PhoneNumberConfirmed { get; set; }
    }
}