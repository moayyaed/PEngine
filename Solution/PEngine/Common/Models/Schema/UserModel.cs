using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace PEngine.Common.Models.Schema
{
    public class UserModel : IdentityUser<string>
    {
        public DateTime LastLogin { get; set; }
    }
}