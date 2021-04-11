using Data;
using FlightManager.Data;
using FlightManager.Data.Entity;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManager.Services
{
    /// <summary>
    /// A useless service, mdae for the user table that has been moved to the identity DB.
    /// </summary>
    /*public class UserContextService
    {
        public IWebHostEnvironment WebHostEnvironment { get; }
        public ConnectionDB context;

        public UserContextService(IWebHostEnvironment webBuilderHost)
        {
            WebHostEnvironment = webBuilderHost;
            context = new ApplicationDbContext();
        }

        public User GetOne(int id)
        {
            return context.Users.Find(id);
        }

        public async Task<User> GetOne(Expression<Func<User, bool>> predicate)
        {
            return await context.User.FindAsync(predicate);
        }

        public IQueryable<User> GetAll()
        {
            return context.Users.AsQueryable();
        }

        public IQueryable<User> GetAll(Expression<Func<User, bool>> predicate)
        {
            return context.Users.Where(predicate).AsQueryable();
        }

        public IQueryable<User> GetNPaged(int numberOfSkips, int numberOfElements)
        {
            return context.Users.Skip(numberOfSkips).Take(numberOfElements).AsQueryable();
        }

        public void Add(User flight)
        {
            context.Users.Add(flight);
            context.SaveChangesAsync();
        }

        public void Add(ICollection<User> flights)
        {
            context.Users.AddRangeAsync(flights);
            context.SaveChangesAsync();
        }

        public void Update(User flight)
        {
            context.Entry(flight).State = EntityState.Modified;
            context.SaveChangesAsync();
        }

        public void Remove(User flight)
        {
            context.Users.Remove(flight);
            context.SaveChangesAsync();
        }

        public void Remove(int id)
        {
            context.Users.Remove(context.Flights.Find(id));
            context.SaveChangesAsync();
        }
    }
        */
}
