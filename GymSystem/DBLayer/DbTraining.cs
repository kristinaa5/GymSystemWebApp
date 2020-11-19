using GymSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GymSystem.DBLayer
{
    public class DbTraining
    {
        public GymSystemDBContext _context { get; set; }

        public DbTraining(GymSystemDBContext context)
        {
            _context = context;
        }

        public List<Training> getAll()
        {
            return _context.Trainings.ToList();

       }

        public Training tryFind(int? id)
        {
            return _context.Trainings.FirstOrDefault(m => m.TrainingId == id);
        }

        public Training Find(int? id)
        {
            return _context.Trainings.Find(id);
        }

        public void Add(Training training)
        {
            _context.Trainings.Add(training);
        }

        public void Update(Training training)
        {
            _context.Trainings.Update(training);
        }

        public void Remove(Training training)
        {
            _context.Trainings.Remove(training);
        }

        public bool Exists(int id)
        {
            return _context.Trainings.Any(e => e.TrainingId == id);
        }

        public List<Training> GetAllAvailableTrainings()
        {
            return _context.Trainings.Where(t => t.Free == true).ToList();
        }


    }
}
