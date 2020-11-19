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
    public class UserTrainingsController : Controller
    {
        private readonly GymSystemDBContext _context;
        private readonly IUserTrainingService _userTrainingService;
        private readonly ITrainingService _trainingService;

        public UserTrainingsController(GymSystemDBContext context, IUserTrainingService userTrainingService, ITrainingService trainingService)
        {
            _context = context;
            _userTrainingService = userTrainingService;
            _trainingService = trainingService;
        }

        // GET: UserTrainings
        public async Task<IActionResult> Index()
        {
            
            return View(_userTrainingService.getAll());
        }

        // GET: UserTrainings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userTraining = _userTrainingService.tryFind(id);
            if (userTraining == null)
            {
                return NotFound();
            }

            return View(userTraining);
        }

        // GET: UserTrainings/Create
        public IActionResult Create()
        {
            //ViewData["TrainingId"] = new SelectList(_context.Trainings.Select(t => new SelectListItem
            //{Text = t.Date.ToShortDateString() + " - " + t.Free.ToString(), Value = t.TrainingId.ToString()}).ToList());

            //ViewData["UserId"] = new SelectList(_context.Users.Select(u => new SelectListItem { Text = u.Name + " - " + u.Address,
            //Value = u.Id.ToString()}).ToList());

            if(_trainingService.GetAllAvailableTrainings().Count() != 0)
            {
                ViewData["TrainingId"] = new SelectList(_trainingService.GetAllAvailableTrainings(), "TrainingId", "Date");
                ViewData["UserId"] = new SelectList(_context.Users, "Id", "Name");
            }
            else
            {
                 ViewData["ErrorMessage"] = "Nema slobodnih termina.";
            }
            

            return View();
        }

        // POST: UserTrainings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,TrainingId")] UserTraining userTraining)
        {
            if (ModelState.IsValid)
            {
                _userTrainingService.Create(userTraining);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            //ViewData["TrainingId"] = new SelectList(_context.Trainings.Select(t => new SelectListItem
            //{ Text = t.Date.ToShortDateString() + " - " + t.Free.ToString(), Value = t.TrainingId.ToString()}).ToList());

            //ViewData["UserId"] = new SelectList(_context.Users.Select(u => new SelectListItem
            //{Text = u.Name + " - " + u.Address, Value = u.Id.ToString()}).ToList());

              ViewData["ErrorMessage"] = "Doslo je do greske.";
         

            return View(userTraining);
        }

        // GET: UserTrainings/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var userTraining = await _context.UserTrainings.FindAsync(id);
        //    if (userTraining == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["TrainingId"] = new SelectList(_context.Trainings, "TrainingId", "TrainingId", userTraining.TrainingId);
        //    ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", userTraining.UserId);
        //    return View(userTraining);
        //}

        // POST: UserTrainings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("UserId,TrainingId,Timestamp")] UserTraining userTraining)
        //{
        //    if (id != userTraining.UserId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(userTraining);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!UserTrainingExists(userTraining.UserId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["TrainingId"] = new SelectList(_context.Trainings, "TrainingId", "TrainingId", userTraining.TrainingId);
        //    ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", userTraining.UserId);
        //    return View(userTraining);
        //}

        // GET: UserTrainings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userTraining = _userTrainingService.tryFind(id);
            if (userTraining == null)
            {
                return NotFound();
            }

            return View(userTraining);
        }

        // POST: UserTrainings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            
            var userTraining = _userTrainingService.Find(id);
            _userTrainingService.Remove(userTraining);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserTrainingExists(int id)
        {
            return _userTrainingService.Exists(id);
        }
    }
}
