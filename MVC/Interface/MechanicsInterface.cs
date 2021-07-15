using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC.Models;

namespace MVC.Interface
{
    public interface MechanicsInterface
    {
        Task<List<Mechanics>> Get();
        Task<Mechanics> GetDetails(int id);
        Task<Mechanics> Create(Mechanics mechanics);
        Task Update(int id,Mechanics mechanics);
        Task Delete(int id);
    }
}
