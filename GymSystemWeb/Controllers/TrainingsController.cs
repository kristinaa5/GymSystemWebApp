using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GymSystem;
using GymSystem.Models;
using GymSystem.DBLayer;
using GymSystem.BusinessLogic.Interfaces;

namespace GymSystemWeb.Controllers
{
    public class TrainingsController : Controller
    {
        private readonly GymSystemDBContext _context;
        private readonly ITrainingService _trainingService;

        public TrainingsController(GymSystemDBContext context, ITrainingService trainingService)
        {
            _context = context;
            _trainingService = trainingService;
        }

        public IActionResult TrainingFilter()
        {
            return View();
        }

        [HttpPost]

        public IActionResult TrainingFilter([FromForm] DateTime date, [FromForm] string compare )
        {
            List<Training> result;

            switch(compare)
            {
                case "<":
                    result = _context.Trainings.Where(t => t.Date < date).ToList();
                    break;

                case ">":
                    result = _context.Trainings.Where(t => t.Date > date).ToList();
                    break;

                case "==":
                    result = _context.Trainings.Where(t => t.Date == date).ToList();
                    break;

                default:
                    result = null;
                    break;
            }

            ViewData["FilterDate"] = date.ToString("yyyy-MM-dd HH:mm:ss").Replace(' ', 'T');
            ViewData["FilterCompare"] = compare;

            return View(result);
        }

        // GET: Trainings
        public async Task<IActionResult> Index()
        {

            return View(_trainingService.getAll());
        }

        // GET: Trainings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var training = _trainingService.tryFind(id);
            if (training == null)
            {
                return NotFound();
            }

            return View(training);
        }

        // GET: Trainings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trainings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TrainingId,Date,Free")] Training training)
        {
            if (ModelState.IsValid)
            {
               _trainingService.Add(training);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(training);
        }

        // GET: Trainings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var training = _trainingService.Find(id);
            if (training == null)
            {
                return NotFound();
            }
            return View(training);
        }

        // POST: Trainings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TrainingId,Date,Free")] Training training)
        {
            if (id != training.TrainingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                   _trainingService.Update(training);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrainingExists(training.TrainingId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(training);
        }

        // GET: Trainings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var training = _trainingService.tryFind(id);
            if (training == null)
            {
                return NotFound();
            }

            return View(training);
        }

        // POST: Trainings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
           
            var training = _trainingService.Find(id);
            _trainingService.Remove(training);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrainingExists(int id)
        {
            return _trainingService.Exists(id);
        }
    }
}
