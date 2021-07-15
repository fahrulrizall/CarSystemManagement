using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC.Models;

namespace MVC.Interface
{
    public interface OwnerInterface
    {
        Task<List<CarOwner>> Get();
        Task<CarOwner> GetDetails(int id);
        Task<CarOwner> Create(CarOwner ownerList);
        Task Update(int id,CarOwner ownerList);
        Task Delete(int id);
    }
}
