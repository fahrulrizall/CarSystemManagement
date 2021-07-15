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
    public class SevicesRepository : ServiceInterface
    {
        private readonly AppDBContext _db;
        private readonly IEmailServices emailServices;
        public SevicesRepository(AppDBContext db, IEmailServices emailServices)
        {
            _db = db;
            this.emailServices = emailServices;
        }
        public async Task<CarServices> Create(CarServices CarServices)
        {
            _db.CarServices.Add(CarServices);
            await _db.SaveChangesAsync();

            var customer = _db.CarServices.Where(a => a.Id == CarServices.Id).Include(a => a.CarOwner).Include(a => a.Mechanics).Single();

            List<UserEmailOptions> userEmailOptions = new List<UserEmailOptions>();

            UserEmailOptions to_owner = new UserEmailOptions
            {
                Subject = "Notification - Car System Management",
                ToEmails = new List<string> { customer.CarOwner.Email },
                Body = $"Dear {customer.CarOwner.Name}" +
                $"We Have Update For Your Car " +
                $"- Service Name = {customer.ServiceName} " +
                $"- Price = {customer.Price} " +
                $"- Status = {customer.Status_Proses} " +
                $"- Mechanic Name = {customer.Mechanics.Name}",
            };

            UserEmailOptions to_mechanic = new UserEmailOptions
            {
                Subject = "Notification - Car System Management",
                ToEmails = new List<string> { customer.Mechanics.Email },
                Body = $"Hi {customer.Mechanics.Name}" +
                $"We Have Update For you Job Desc  " +
                $"- Service Name = {customer.ServiceName} " +
                $"- Status = {customer.Status_Proposal} "
            };

            userEmailOptions.Add(to_owner);
            userEmailOptions.Add(to_mechanic);

            await emailServices.SendTestEmail(userEmailOptions);

            return CarServices;
        }

        public async Task Delete(int id)
        {
            var result = _db.CarServices.Find(id);
            _db.CarServices.Remove(result);
            await _db.SaveChangesAsync();
        }

        public async Task<List<CarServices>> Get()
        {
            return await _db.CarServices.ToListAsync();
        }

        public async Task<CarServices> GetDetails(int id)
        {
            return await _db.CarServices.FindAsync(id);
        }

        public async Task Update(int id,CarServices CarServices)
        {
            var result = _db.CarServices.Find(id);

            if (result != null)
            {
                result.Id_CarOwner = CarServices.Id_CarOwner;
                result.Id_Mechanics = CarServices.Id_Mechanics;
                result.Price = CarServices.Price;
                result.ServiceName = CarServices.ServiceName;
                result.Status_Proposal = CarServices.Status_Proposal;
                result.Status_Proses = CarServices.Status_Proses;

                _db.Entry(result).State = EntityState.Modified;
                await _db.SaveChangesAsync();
            }
            await Task.FromResult(false);

            var customer = _db.CarServices.Where(a => a.Id == id).Include(a=>a.CarOwner).Include(a=>a.Mechanics).Single();

            List<UserEmailOptions> userEmailOptions = new List<UserEmailOptions>();

            UserEmailOptions to_owner = new UserEmailOptions
            {
                Subject = "Notification - Car System Management",
                ToEmails = new List<string> { customer.CarOwner.Email },
                Body  = $"Dear {customer.CarOwner.Name}"+
                $"We Have Update For Your Car " + 
                $"- Service Name = {customer.ServiceName} " + 
                $"- Price = {customer.Price} " +
                $"- Status = {customer.Status_Proses} " + 
                $"- Mechanic Name = {customer.Mechanics.Name}",
            };

            UserEmailOptions to_mechanic = new UserEmailOptions
            {
                Subject = "Notification - Car System Management",
                ToEmails = new List<string> { customer.Mechanics.Email },
                Body = $"Hi {customer.Mechanics.Name}" +
                $"We Have Update For you Job Desc  " +
                $"- Service Name = {customer.ServiceName} " +
                $"- Status = {customer.Status_Proposal} " 
            };

            userEmailOptions.Add(to_owner);
            userEmailOptions.Add(to_mechanic);

            await emailServices.SendTestEmail(userEmailOptions);

        }
    }
}
