using Microsoft.AspNetCore.Mvc;
using webApp_Books.Repository;
using webApp_Books.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace webApp_Books.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [AllowAnonymous]
        public IActionResult Index([FromQuery] string filter)
        {
            ViewData["filter"] = filter;
            if (string.IsNullOrEmpty(filter))
            {
                return View(_bookRepository.GetAll());
            }
            else
            {
                return View(_bookRepository.GetWithFilter(filter));
            }

        }

        public IActionResult Details(int id)
        {
            var student = _bookRepository.GetSingle(id);
            if (student == null)
            {
                return RedirectToAction("Index");
            }
            
            return View(student);
        }

        public IActionResult Create()
        {
            return View("Edit", new Book());
        }

        public IActionResult Edit(int Id)
        {
            var s = _bookRepository.GetSingle(Id);
            if (s == null)
            {
                return RedirectToAction("Index");
            }
            return View(s);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Book book)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(book);
                }
                else
                {
                    _bookRepository.Save(book);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(book);
            }
        }

        public IActionResult Delete(int Id)
        {
            var book = _bookRepository.GetSingle(Id);
            if (book == null)
            {
                return RedirectToAction("Index");
            }
            _bookRepository.Delete(Id);
            return RedirectToAction("Index");
        }
    }
}
