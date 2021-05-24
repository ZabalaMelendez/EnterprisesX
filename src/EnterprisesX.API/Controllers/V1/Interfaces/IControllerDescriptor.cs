using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnterprisesX.API.Controllers.V1.Interfaces
{
    /// <summary>
    /// Inteface for basic crud operation over the controllers
    /// </summary>
    /// <typeparam name="T">DTO request with info or return data</typeparam>
    public interface IControllerDescriptor<T>
        where T: class
    {

        Task<IActionResult> Get();
        Task<IActionResult> Get(int Id);
        Task<IActionResult> Post(T request);
        Task<IActionResult> Put(int Id,T request);
        Task<IActionResult> Delete(int Id);
        
    }
}
