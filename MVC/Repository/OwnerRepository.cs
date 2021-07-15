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
    public class OwnerRepository : OwnerInterface
    {
        private readonly AppDBContext _db;
        public OwnerRepository(AppDBContext db)
        {
            _db = db;
        }

        public async Task<CarOwner> Create(CarOwner ownerList)
        {
            _db.CarOwner.Add(ownerList);
            await _db.SaveChangesAsync();
            return ownerList;
        }

        public async Task Delete(int id)
        {
            var result = _db.CarOwner.Find(id);
            _db.CarOwner.Remove(result);
            await _db.SaveChangesAsync();
        }

        public async Task<List<CarOwner>> Get()
        {
            return await _db.CarOwner.ToListAsync(); 
        }

        public async Task<CarOwner> GetDetails(int id)
        {
            return await _db.CarOwner.FindAsync(id);
        }

        public async Task Update(int id,CarOwner ownerList)
        {
            var result =  _db.CarOwner.Find(id);
            
            if (result != null)
            {
                result.Email = ownerList.Email;
                result.Name = ownerList.Name;
                result.Password = ownerList.Password;

                _db.Entry(result).State = EntityState.Modified;
                await _db.SaveChangesAsync();
            }
            await Task.FromResult(false);
            
        }
    }
}
