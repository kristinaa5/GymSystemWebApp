using GymSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymSystem.BusinessLogic.Interfaces
{
   public interface IUserService
    {
       List <User> getAll();

        User tryFind(int? id);

        User Find(int? id);

        void Add(User user);

        void Update(User user);

        void Remove(User user);

        bool Exists(int id);
    }


}
