using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HighWayCodeTraining.Models
{
    public class Image
    {
        public int Id { get; set; }

        public string Name { get; set; }
        [DisplayName("Upload Image :")]
        [NotMapped]
        public IFormFile File { get; set; }
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
    }
}
