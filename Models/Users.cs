using System.ComponentModel.DataAnnotations;

namespace UsersTasksAPI.Models
{
    public class User
    {
        public User() { } 

        [Key]
        public int UserID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        public ICollection<UserTask> Tasks { get; set; }
    }
}

