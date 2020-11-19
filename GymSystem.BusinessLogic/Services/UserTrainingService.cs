using GymSystem.BusinessLogic.Interfaces;
using GymSystem.DBLayer;
using GymSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymSystem.BusinessLogic.Services
{
    public class UserTrainingService : IUserTrainingService
    {
        private readonly DbUserTraining dbUserTraining;
        private readonly ITrainingService _trainingService;

        public UserTrainingService(GymSystemDBContext context, ITrainingService trainingService)
        {
            dbUserTraining = new DbUserTraining(context);
            _trainingService = trainingService;
        }

        public List<UserTraining> getAll()
        {
            return dbUserTraining.getAll();
        }

        public List<DateTime> getDate(User user)
        {
            return dbUserTraining.getDate(user);
        }

        public UserTraining tryFind(int? id)
        {
            return dbUserTraining.tryFind(id);
        }

        public void Add(UserTraining userTraining)
        {
            dbUserTraining.Add(userTraining);
        }

        public void Update(UserTraining userTraining)
        {
            dbUserTraining.Update(userTraining);
        }

        public UserTraining Find(int? id)
        {
            return dbUserTraining.Find(id);
        }

        public void Remove(UserTraining userTraining)
        {
            dbUserTraining.Remove(userTraining);
            Training training = _trainingService.Find(userTraining.TrainingId);

            training.Free = true;

            _trainingService.Update(training);
        }

        public bool Exists(int id)
        {
            return dbUserTraining.Exists(id);
        }

        public void Create(UserTraining userTraining)
        {
            dbUserTraining.Add(userTraining);
            Training training = _trainingService.Find(userTraining.TrainingId);

            training.Free = false;

            _trainingService.Update(training);
        }

        

    }
}
