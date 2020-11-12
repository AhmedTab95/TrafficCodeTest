using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace HighWayCodeTraining.Models
{
    public class Dal : IDal
    {
        private DBContext _context;

        public Dal()
        {
            

        }

        public List<Question> GetQuestionsList()
         {
            return _context.Questions.ToList();
        } 

        public void Create50Questions()
        {
            Question questionInit = _context.Questions.FirstOrDefault(q => q.Id == 1);
            for (int i= 0; i < 50; i++)
            {
                Question question = new Question
                {
                    Date = DateTime.Now,
                    Title = questionInit.Title,
                    Tag = questionInit.Tag,
                    Image = questionInit.Image,
                    Options = questionInit.Options,
                    Correction = questionInit.Correction,                  
                };
                i++;
                _context.Add(question);
                _context.SaveChanges();
            }
        }

        // Flag: Has Dispose already been called?
        bool disposed = false;

        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
            }

            disposed = true;
        }
    }
}
