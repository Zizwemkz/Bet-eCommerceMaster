using System;
using BET_eCommerceAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BET_eCommerceAPI.Interface
{
    public interface IDepartmentService
    {
        Task<int> AddDepartmentAsync(Departmentmodel departmentmodel); 
         Task<Departmentmodel> GetDepartmentByIdAsync(int Departmentid);
        Task<List<Departmentmodel>> GetAllDepartmentAsync();
    }
}
