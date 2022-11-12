using crud_app_lab3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace crud_app_lab3.Controllers
{
    public class BookController : Controller
    {
        /*
        public static Dictionary<int, Book> books = new Dictionary<int, Book>
        {
            { 1, new Book(){ Id = 1, Author = "AAAAA", Title ="BBBB", IsAvailable = true, CreatedDate = DateTime.Now} },
            { 2, new Book(){ Id = 2, Author = "CCCCC", Title ="DDDD", IsAvailable = true, CreatedDate = DateTime.Now} },
            { 3, new Book(){ Id = 3, Author = "NNNNN", Title ="BBBB", IsAvailable = true, CreatedDate = DateTime.Now} },
            { 4, new Book(){ Id = 4, Author = "YYYYY", Title ="GGGG", IsAvailable = false, CreatedDate = DateTime.Now} }
        };
        */
        public static AppDbContext context = new AppDbContext();
        

        public static int counter = 4;
        public IActionResult Index()
        {
            return View(context.Books.ToList());
        }
        //TODO zaprojektu formularz do edycji z polami Title i Author
        //TODO w formularz kieruj dane do akcji Edit (metoda post)
        //TODO w akcji Edit zamień tylko tytuł i autora ksiązki
        //TODO Zdefiniować model EditBook z polami Id, Title i Author
        //TODO w akcji edit [HttpPost] zmienić argument z Book na EditBook
        //TODO w akcji Edit [HttpPost] przeprowadzić standardową walidację
        //TODO w widoku Edit dodać wyświetlania błędów podobnie jak w CreateForm
        public IActionResult Edit([FromRoute] int id)
        {
            //return View(books[id]);
            return View(context.Books.Find(id));
        }

        [HttpPost]
        public IActionResult Edit([FromForm]Book editedBook)
        {
            /*
            if (editedBook.Title != null && editedBook.Title.Length >= 3)
            {
                books[editedBook.Id].Title = editedBook.Title;
                return RedirectToAction(nameof(Index));
            }
            */

            
            Book? book = context.Books.Find(editedBook.Id);
            book.Title = editedBook.Title;
            context.Books.Update(book);
            context.SaveChanges();

            return View();
        }
        

        public IActionResult Delete([FromRoute] int id)
        {
            /*
            books.Remove(id);
            return View("Index", books);
            */

            context.Books.Remove(context.Books.Find(id));
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details()
        {
            return View();
        }

        public IActionResult CreateForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromForm] Book bookFromForm)
        {
            /*
            if (ModelState.IsValid)
            {
                books[++counter] = bookFromForm;
                return View("Index", books);
            }
            */
            if(ModelState.IsValid)
            {
                context.Books.Add(bookFromForm);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View("CreateForm");
            //TODO odebranie danych z formularza, zapianie obiektu do books
            
        }    
    }
}
