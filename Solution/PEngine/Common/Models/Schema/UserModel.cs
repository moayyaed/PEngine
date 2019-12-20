using System.ComponentModel.DataAnnotations;

namespace PEngine.Common.Models.Schema
{
    public class UserModel
    {
        [Key]
        public long Id { get; set; }

        public string Email { get; set; }
        public string Name { get; set; }

        public bool IsAdmin { get; set; }
    }
}