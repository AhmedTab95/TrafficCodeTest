using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HighWayCodeTraining.Models
{
    public interface IDal : IDisposable
    {

        List<Question> GetQuestionsList();
                
        void Create50Questions(); //This mthode is to create 50 questions for the demo. Not in a real app

    }
}
