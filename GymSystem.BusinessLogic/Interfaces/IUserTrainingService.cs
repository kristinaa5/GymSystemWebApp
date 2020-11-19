using GymSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymSystem.BusinessLogic.Interfaces
{
    public interface IUserTrainingService
    {

       List<UserTraining> getAll();

        List<DateTime> getDate(User user);

        UserTraining tryFind(int? id);

        void Add(UserTraining userTraining);

        void Update(UserTraining userTraining);

        UserTraining Find(int? id);

        void Remove(UserTraining userTraining);

        bool Exists(int id);

        void Create(UserTraining userTraining);
    }
}
