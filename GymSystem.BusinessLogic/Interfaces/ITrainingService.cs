using GymSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymSystem.BusinessLogic.Interfaces
{
    public interface ITrainingService
    {

        List<Training> getAll();

        Training tryFind(int? id);

        Training Find(int? id);

        void Add(Training training);

        void Update(Training training);

        void Remove(Training training);

        bool Exists(int id);

        List<Training> GetAllAvailableTrainings();
    }
}
