using System.ComponentModel.DataAnnotations;
using System;

namespace UsersTasksAPI.Models
{public class UserTask
    {
        public UserTask() { } 

        [Key]
        public int TaskId { get; set; }
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public int Assignee { get; set; }  
        [Required]
        public DateTime DueDate { get; set; }
        public User User { get; set; }
    }
}
