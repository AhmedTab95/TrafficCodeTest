using HighWayCodeTraining.Controllers;
using HighWayCodeTraining.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using System.Linq;
using Moq;
using System.Threading;

namespace UnitTestProject1
{   

    [TestClass]
    public class UnitTest1
    {
        
        [TestMethod]
        public void TestCreate50Questions_questionListCount_CountPlus50()
         {

            using (IDal dal = new Dal())
            {
                
                List<Question> listBefore = dal.GetQuestionsList();
                int nbQuestions = listBefore.Count();


                dal.Create50Questions();

               
                Thread.SpinWait(5000);
            }

         } 
    }
}
