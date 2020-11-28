using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;

namespace HighWayCodeTraining.Models
{
    public class Question 
    {
        [Key]
        public int Id {get; set;}

        public DateTime Date { get; set; }

        [DisplayName("Question :")]
        [Required(ErrorMessage = "Please add a question")]
        [MaxLength(250, ErrorMessage = "Question too long (Max 250 characters)")]
        [Column(TypeName = "varchar(250)")]
        public string Title { get; set; }

        [DisplayName("Category :")]
        [Required(ErrorMessage = "Please add at least one category")]
        [MaxLength(250, ErrorMessage = "Question too long (Max 250 characters)")]
        [Column(TypeName = "varchar(250)")]
        public string Tag { get; set; }
        
        [NotMapped]
        [DisplayName("Upload File :")]
        [Required(ErrorMessage = "Please add an Image")]
        public Image Image { get; set; }

        [Required(ErrorMessage = "Please add propositions")]
        [DisplayName("Answer options:")]        
        public virtual IList<Option> Options { get; set; }

        [DisplayName("Correction :")]
        [Required(ErrorMessage="Please add the correction")]
        [MaxLength(500, ErrorMessage = "Question too long (Max 250 characters)")]
        [Column(TypeName = "varchar(500)")]
        public string Correction { get; set; }

    }

}
