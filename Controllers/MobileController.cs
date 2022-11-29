using AdoUsingCRUDOperation.DAL;
using AdoUsingCREDOperation.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdoUsingCRUDOperation.Controllers
{
    public class MobileController : Controller
    {
        IConfiguration configuration;
       MobileDAL mobileDAL;
        public MobileController(IConfiguration configuration)
        {
            this.configuration = configuration;
            mobileDAL = new MobileDAL(this.configuration);
        }
        // GET: MobileController
        public ActionResult List()
        {
            ViewBag.mobilelist = mobileDAL.GetAllMobile();
            return View();
        }

        // GET: MobileController/Details/5
        public ActionResult Details(int id)
        {
            var model = mobileDAL.GetMobileById(id);
            return View(model);
        }

        // GET: MobileController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MobileController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Mobile mobile)
        {
            try
            {
                int result = mobileDAL.AddMobile(mobile);
                if (result == 1)
                    return RedirectToAction(nameof(List));
                else
                {
                    return BadRequest();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: MobileController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = mobileDAL.GetMobileById(id);
            return View(model);
        }

        // POST: MobileController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Mobile mobile)
        {
            try
            {
                int result = mobileDAL.EditeMobile(mobile);
                if (result == 1)
                    return RedirectToAction(nameof(List));
                else{
                    return BadRequest();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: MobileController/Delete/5
        public ActionResult Delete(int id)
        {

            return View();
        }

        // POST: MobileController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
