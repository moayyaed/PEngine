using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PEngine.Models.User
{
    public class UserModel
    {
        [Key]
        public long Id { get; set; }

        public string Email { get; set; }
        public bool IsEmailOpened { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime LastLoggedAt { get; set; }

        public bool IsSuspended { get; set; }
        public DateTime SuspendedAt { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsBioUsed { get; set; }
        public string BioContent { get; set; }

        public string SNSListJson { get; set; }
        public List<SNSModel> SNSList => 
            JsonConvert.DeserializeObject<List<SNSModel>>(SNSListJson);
    }
}
