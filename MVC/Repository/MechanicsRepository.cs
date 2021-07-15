using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC.Interface;
using MVC.Models;
using MVC.Data;
using Microsoft.EntityFrameworkCore;


namespace MVC.Repository
{
    public class MechanicsRepository : MechanicsInterface
    {
        private readonly AppDBContext _db;
        public MechanicsRepository(AppDBContext db)
        {
            _db = db;
        }

        public async Task<Mechanics> Create(Mechanics mechanics)
        {
            _db.Mechanics.Add(mechanics);
            await _db.SaveChangesAsync();
            return mechanics;
        }

        public async Task Delete(int id)
        {
            var result = _db.Mechanics.Find(id);
            _db.Mechanics.Remove(result);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Mechanics>> Get()
        {
            return await _db.Mechanics.ToListAsync();
        }

        public async Task<Mechanics> GetDetails(int id)
        {
            return await _db.Mechanics.FindAsync(id);
        }

        public async Task Update(int id,Mechanics mechanics)
        {
            var result = _db.Mechanics.Find(id);

            if (result != null)
            {
                result.Email = mechanics.Email;
                result.Name = mechanics.Name;
                result.Password = mechanics.Password;

                _db.Entry(result).State = EntityState.Modified;
                await _db.SaveChangesAsync();
            }
            await Task.FromResult(false);
        }
    }
}
