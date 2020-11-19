using GymSystem.BusinessLogic.Interfaces;
using GymSystem.DBLayer;
using GymSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace GymSystem.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly DbUser dbUser;

        public UserService(GymSystemDBContext context)
        {
            dbUser = new DbUser(context);
        }

        public List<User> getAll()
        {
            return dbUser.getAll();
        }

        public User tryFind(int? id)
        {
            return dbUser.tryFind(id);
        }

        public User Find(int? id)
        {
            return dbUser.Find(id);
        }

        public void Add(User user)
        {
            dbUser.Add(user);
        }

        public void Update(User user)
        {
            dbUser.Update(user);
        }

        public void Remove(User user)
        {
            dbUser.Remove(user);
        }

        public bool Exists(int id)
        {
            return dbUser.Exists(id);
        }
    }
}
