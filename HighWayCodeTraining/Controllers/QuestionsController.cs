using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HighWayCodeTraining.Models;
using HighWayCodeTraining.ViewModels;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Security.Cryptography.Xml;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.AspNetCore.Http;

namespace HighWayCodeTraining.Controllers
{
    public class QuestionsController : Controller 
    {
        private DBContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public QuestionsController(DBContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Questions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Questions.ToListAsync());
        }

        // GET: Questions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            IList<Option> optionList;
            Image image;
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Questions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (question == null)
            {
                return NotFound();
            }
            optionList = _context.Options.Include(o => o.Question).ToList();
            question.Options = optionList;

            image = _context.Images.FirstOrDefault(image => image.QuestionId == question.Id);
            question.Image = image;
            question.Image.Name = image.Name;

            return View(question);
          
        }

        // GET: Questions/Create

        public IActionResult Create()
        {
            return View();
        }

        // POST: Questions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> Create(Question question)
        {
            //[Bind("Id,Title,File,Tag,Option1,Option2,Option3,Option4,Correction")]//
            
            if (ModelState.IsValid)
            {
                question.Date = DateTime.Now;

                //Save image in folder image
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string filename = Path.GetFileNameWithoutExtension(question.Image.File.FileName);
                string extension = Path.GetExtension(question.Image.File.FileName);
                filename += DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/image" , filename);
                


                using (FileStream fileStream = new FileStream(path, FileMode.Create))
                {
                    await question.Image.File.CopyToAsync(fileStream);
                }
                question.Image.Name = filename;
                question.Image.Question = question;
                question.Image.QuestionId = question.Id;

                question.Date = DateTime.Now;
                for (int i = 0; i < 4; i++)
                {

                    question.Options[i].Question = question;
                    question.Options[i].QuestionId = question.Id;
                    
                }


                //Save record

                _context.Add(question);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(question);
        }

        // GET: Questions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            IList<Option> optionList;
            Image image; 
            
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Questions.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }
            optionList = _context.Options.Include(o => o.Question).ToList();
            question.Options = optionList;
            image = _context.Images.FirstOrDefault(i => i.Question == question);
            question.Image = image;

            return View(question);

           
        }

        // POST: Questions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Question question)
        {
            question.Date = DateTime.Now;

            if (id != question.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    Image image = _context.Images.FirstOrDefault(i => i.QuestionId == question.Id);

                    if (!System.IO.File.Exists(wwwRootPath + question.Image.File.Name))
                    {
                        
                        string newFilename = Path.GetFileNameWithoutExtension(question.Image.File.FileName);
                        string extension = Path.GetExtension(question.Image.File.FileName);
                        newFilename += DateTime.Now.ToString("yymmssfff") + extension;
                        string newPath = Path.Combine(wwwRootPath + "/image", newFilename);
                        question.Image.Name = newFilename;
                        question.Image.Question = question;
                        
                        using (FileStream fileStream = new FileStream(newPath, FileMode.Create))
                        {
                            await question.Image.File.CopyToAsync(fileStream);
                        }

                        image = question.Image;

                        for (int i = 0; i < 4; i++)
                        {

                            question.Options[i].Question = question;
                            question.Options[i].QuestionId = question.Id;

                        }
                        
                    }
 
                    //Save record
                    
                    _context.Update(question);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestionExists(question.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            } 
            return View(question);
                       
        }

        // GET: Questions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Questions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var question = await _context.Questions.FindAsync(id);
            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestionExists(int id)
        {
            return _context.Questions.Any(e => e.Id == id);
        }
    }
}
