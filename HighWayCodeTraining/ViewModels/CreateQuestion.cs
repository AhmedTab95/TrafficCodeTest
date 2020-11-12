using HighWayCodeTraining.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HighWayCodeTraining.ViewModels
{
    public class CreateQuestion
    {
        public Question Question { get; set; }
        public Image Image { get; set; }
    }
}
