using AdoUsingCREDOperation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Security.Cryptography;

namespace AdoUsingCREDOperation.Controllers
{
    public class CustomersController : Controller
    {
        private readonly IConfiguration configuration;
        CustomersDal CustomersDal;
        public CustomersController(IConfiguration configuration)
        {
            this.configuration = configuration;
            CustomersDal =new CustomersDal(this.configuration);
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(Customers cust)
        {
            try
            {
                int res=CustomersDal.CustomerRegister(cust);
                if(res==1)
                {
                    return Register(cust);
                }
            }
            catch(Exception ex)
            {
                return View();
            }
            return View();
        }
        public IActionResult Loin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Loin(Customers cust)
        {
            Customers c = CustomersDal.CustomersLogin(cust);
            if (c != null)
            {
                return View();
            }
            else
            {
                return View();
            }

            return View();
        }
    }
}
