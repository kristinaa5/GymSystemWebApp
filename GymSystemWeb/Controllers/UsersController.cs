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
    public class UsersController : Controller
    {
        //await _context.Users.ToListAsync()

        private readonly GymSystemDBContext _context;
        private readonly IUserService _userService;
        private readonly IUserTrainingService _userTrainingService;

        public UsersController(GymSystemDBContext context, IUserService userService, IUserTrainingService userTrainingService)
        {
            _context = context;
            _userService = userService;
            _userTrainingService = userTrainingService;
        }

        public IActionResult UserFilter()
        {
            return View();
        }

        [HttpPost]

        public IActionResult UserFilter([FromForm] string name, [FromForm] string address, [FromForm] DateTime date)
        {
            var result = _context.Users.Where(u => u.Name == name && u.Address == address
            && u.DateOfBirth < date).ToList();

            return View(result);
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
           // DbUser dbUser = new DbUser(_context);

            // List<User> muskarci = _context.Users.Where(User => User.Gender == "m").ToList();
            // List<User> imena = _context.Users.Where(User => User.Name.Contains("r")).ToList();
            List<User> brojTel = _context.Users.Where(User => User.Phone.Contains("+")).ToList();
            List<User> godiste = _context.Users.Where(User => User.DateOfBirth.Year < 1996 && User.Gender == "z").ToList();

            return View(_userService.getAll());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _userService.tryFind(id);

            if (user == null)
            {
                return NotFound();
            }

            List<DateTime> date = _userTrainingService.getDate(user);
       
            if(date.Count != 0)
            {
                ViewData["TrainingStatus"] = date;
            }
            else
            {
                ViewData["TrainingStatus"] = null;
            }
 

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Phone,DateOfBirth,Address,Gender")] User user)
        {
            if (ModelState.IsValid)
            {
                _userService.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _userService.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Phone,DateOfBirth,Address,Gender")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _userService.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
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
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _userService.tryFind(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
     
            var user = _userService.Find(id);
            _userService.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _userService.Exists(id);
        }
    }
}
