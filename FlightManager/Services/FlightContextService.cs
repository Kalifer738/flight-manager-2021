using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Data;
using Data.Entity;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace FlightManager.Services
{
    public class FlightContextService
    {
        public IWebHostEnvironment WebHostEnvironment { get; }
        public ConnectionDB context;

        public FlightContextService(IWebHostEnvironment webBuilderHost)
        {
            WebHostEnvironment = webBuilderHost;
            context = new ConnectionDB();
        }

        public Flight GetOne(int id)
        {
            return context.Flights.Find(id);
        }

        public async Task<Flight> GetOne(Expression<Func<Flight, bool>> predicate)
        {
            return await context.Flights.FindAsync(predicate);
        }

        public IQueryable<Flight> GetAll()
        {
            return context.Flights.AsQueryable();
        }

        public IQueryable<Flight> GetAll(Expression<Func<Flight, bool>> predicate)
        {
            return context.Flights.Where(predicate).AsQueryable();
        }

        public IQueryable<Flight> GetNPaged(int numberOfSkips, int numberOfElements)
        {
            return context.Flights.Skip(numberOfSkips).Take(numberOfElements).AsQueryable();
        }

        public void Add(Flight flight)
        {
            context.Flights.Add(flight);
            context.SaveChangesAsync();
        }

        public void Add(ICollection<Flight> flights)
        {
            context.Flights.AddRangeAsync(flights);
            context.SaveChangesAsync();
        }

        public void Update(Flight flight)
        {
            context.Entry(flight).State = EntityState.Modified;
            context.SaveChangesAsync();
        }

        public void Remove(Flight flight)
        {
            context.Flights.Remove(flight);
            context.SaveChangesAsync();
        }

        public void Remove(int id)
        {
            context.Flights.Remove(context.Flights.Find(id));
            context.SaveChangesAsync();
        }
    }
}
