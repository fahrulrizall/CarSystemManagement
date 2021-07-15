using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC.Models;

namespace MVC.Interface
{
    public interface ServiceInterface
    {
        Task<List<CarServices>> Get();
        Task<CarServices> GetDetails(int id);
        Task<CarServices> Create(CarServices CarServices);
        Task Update(int id, CarServices CarServices);
        Task Delete(int id);
    }
}
