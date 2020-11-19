using GymSystem.Models;
using GymSystem.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GymSystem.DBLayer
{
    public class DbUserTraining
    {
        public GymSystemDBContext _context { get; set; }

        public DbUserTraining(GymSystemDBContext context)
        {
            _context = context;
        }

        public List<UserTraining> getAll()
        {
            return _context.UserTrainings.Include(ut => ut.user).Include(ut => ut.training).ToList();
        }

        public List<DateTime> getDate(User user)
        {
           return _context.UserTrainings.Where(ut => ut.UserId == user.Id).Include(t => t.training).Select(t => t.training.Date).ToList();
        }

        public UserTraining tryFind(int? id)
        {
            return _context.UserTrainings.Include(ut => ut.user).Include(ut => ut.training).FirstOrDefault(ut => ut.Id == id);
        }

        public void Add(UserTraining userTraining)
        {
            _context.UserTrainings.Add(userTraining);
        }

        public void Update(UserTraining userTraining)
        {
            _context.UserTrainings.Update(userTraining);
        }

        public UserTraining Find(int? id)
        {
            return _context.UserTrainings.Find(id);
        }

        public void Remove(UserTraining userTraining)
        {
            _context.UserTrainings.Remove(userTraining);
        }

        public bool Exists(int id)
        {
            return _context.UserTrainings.Any(e => e.Id == id);
        }

        public List<UserTrainingsViewModel> getViewModelList(FilterViewModel filter)
        {
            return _context.UserTrainings.Include(ut => ut.user).Include(ut => ut.training)
                .Where(ut => ut.user.Gender == filter.gender && ut.user.Address == filter.address
                && ut.training.Date > filter.date).Select(ut => new UserTrainingsViewModel
                {
                    Name = ut.user.Name,
                    Address = ut.user.Address,
                    Date = ut.training.Date
                }).ToList();
            
        }

    }
}
