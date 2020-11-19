using GymSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GymSystem.DBLayer
{
  public  class DbUser
    {
        public GymSystemDBContext _context { get; set; }
        public DbUser(GymSystemDBContext context)
        {
            _context = context;
        }

        public List<User> getAll()
        {
            return _context.Users.ToList();
        }

        public User tryFind(int? id)
        {
            return _context.Users.FirstOrDefault(m => m.Id == id);
        }

        public User Find(int? id)
        {
            return _context.Users.Find(id);
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
        }

        public void Remove(User user)
        {
            _context.Users.Remove(user);
        }

        public bool Exists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
        
    }
}
