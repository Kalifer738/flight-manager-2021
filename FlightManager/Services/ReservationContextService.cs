using Data;
using Data.Entity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FlightManager.Services
{
    public class ReservationContextService
    {
        public IWebHostEnvironment WebHostEnvironment { get; }
        public ConnectionDB context;

        public ReservationContextService(IWebHostEnvironment webBuilderHost)
        {
            WebHostEnvironment = webBuilderHost;
            context = new ConnectionDB();
        }

        public Reservation GetOne(int id)
        {
            return context.Reservations.First(x => x.Id == id);
        }

        public Reservation GetOne(Expression<Func<Reservation, bool>> predicate)
        {
            return context.Reservations.First(predicate);
        }

        public IQueryable<Reservation> GetAll()
        {
            return context.Reservations.AsQueryable();
        }

        public IQueryable<Reservation> GetAll(Expression<Func<Reservation, bool>> predicate)
        {
            return context.Reservations.Where(predicate).AsQueryable();
        }

        public IQueryable<Reservation> GetNPaged(int numberOfSkips, int numberOfElements)
        {
            return context.Reservations.Skip(numberOfSkips).Take(numberOfElements).AsQueryable();
        }

        public void Add(Reservation flight)
        {
            context.Reservations.Add(flight);
            context.SaveChangesAsync();
        }

        public void Add(ICollection<Reservation> flights)
        {
            context.Reservations.AddRangeAsync(flights);
            context.SaveChangesAsync();
        }

        public void Update(Reservation flight)
        {
            context.Entry(flight).State = EntityState.Modified;
            context.SaveChangesAsync();
        }

        public void Remove(Reservation flight)
        {
            context.Reservations.Remove(flight);
            context.SaveChangesAsync();
        }

        public void Remove(int id)
        {
            context.Reservations.Remove(context.Reservations.Find(id));
            context.SaveChangesAsync();
        }
    }
}
