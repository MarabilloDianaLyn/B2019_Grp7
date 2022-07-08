using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AI_TaskM.Models
{
    public class MainTask
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Title { get; set; } = "";

        [Required]
        public DateTime DueDate { get; set; }

        public string isComplete { get; set; }

        public string Progress { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual List<ToDo> ToDos { get; set; } = new List<ToDo>();
    }
}