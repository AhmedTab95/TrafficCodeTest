using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HighWayCodeTraining.Models
{
    public class Option
    {
        
        public int Id { get; set; }
        [MaxLength(250, ErrorMessage = "Question too long (Max 250 characters)")]
        [Column(TypeName = "varchar(250)")]
        public string Proposition { get; set; }
        public virtual bool State { get; set; }
        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
        
    }   
}
