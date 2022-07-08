using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AI_TaskM.Models
{
    public class ToDo
    {
        public ToDo()
        {
        }

        [Key]
        public int TodoId { get; set; }

        [ForeignKey("MainTask")]
        public int TaskId { get; set; }
        public virtual MainTask MainTask { get; private set; }

        [Required]
        public string Description { get; set; }

        public bool isDone { get; set; }

        [NotMapped]
        public bool IsDeleted { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}