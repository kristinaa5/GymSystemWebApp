using GymSystem.BusinessLogic.Interfaces;
using GymSystem.DBLayer;
using GymSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymSystem.BusinessLogic.Services
{
   public class TrainingService : ITrainingService
    {
        private readonly DbTraining dbTraining;

        public TrainingService(GymSystemDBContext context)
        {
            dbTraining = new DbTraining(context);
        }

        public List<Training> getAll()
        {
            return dbTraining.getAll();

        }

        public Training tryFind(int? id)
        {
            return dbTraining.tryFind(id);
        }

        public Training Find(int? id)
        {
            return dbTraining.Find(id);
        }

        public void Add(Training training)
        {
            dbTraining.Add(training);
        }

        public void Update(Training training)
        {
            dbTraining.Update(training);
        }

        public void Remove(Training training)
        {
            dbTraining.Remove(training);
        }

        public bool Exists(int id)
        {
            return dbTraining.Exists(id);
        }

        public List<Training> GetAllAvailableTrainings()
        {
            return dbTraining.GetAllAvailableTrainings();
        }

    }
}
