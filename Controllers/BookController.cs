using AdoUsingCREDOperation.DAL;
using AdoUsingCRUDOperation.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdoUsingCRUDOperation.Controllers
{
    public class BookController : Controller
    {
        IConfiguration configuration;
        BookDAL bookDAL;
        public BookController(IConfiguration configuration)
        {
            this.configuration = configuration;
            bookDAL = new BookDAL(this.configuration);
        }
        // GET: BookController
        public ActionResult List()
        {
           ViewBag.BookList = bookDAL.GetAllBook();
            return View();
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            var model = bookDAL.GetbookById(id);
            return View(model);
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            try
            {
                int result = bookDAL.AddBook(book);
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

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {
            var modle = bookDAL.GetbookById(id);

            return View(modle);
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book book)
        {
            try
            {
                int result = bookDAL.UpdateBook( book);
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

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            var modle = bookDAL.GetbookById(id);
            return View(modle);
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result =bookDAL.DeleteBook(id);
                if (result == 1)
                    return RedirectToAction(nameof(List));
                else
                    return BadRequest();
            }
            catch
            {
                return BadRequest();
            }

        }

    }
}
