using BET_eCommerceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BET_eCommerceAPI.Interface
{
    public interface IAuthService
    {
        Task<Response> RegisterAsync(RegisterModel registerModel);
        Task<Response> LogInAsync(LoginModel loginmodel);
        Task<RegisterModel> GetApplicationuser(RegisterModel loginmodel);
    }
}
