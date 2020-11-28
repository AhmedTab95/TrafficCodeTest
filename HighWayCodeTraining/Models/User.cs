using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HighWayCodeTraining.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Pleaser enter a name)")]
        [MaxLength(50, ErrorMessage = "Name too long (Max 50 characters)")]
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Pleaser enter an email")]
        [RegularExpression(@"(^.+)[@](.+)[.](\w +)$", ErrorMessage = "Please enter an email")]
        [MaxLength(75, ErrorMessage = "Name too long (Max 75 characters)")]
        [Column(TypeName = "varchar(75)")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Pleaser enter a password")]
        [RegularExpression(@"(^.+)[@](.+)[.](\w +)$", ErrorMessage = "Please enter a valid password")]
        [MaxLength(50, ErrorMessage = "Password too long (Max 50 characters)")]
        [Column(TypeName = "varchar(75)")]
        public string Password { get; set; }

    }
}
