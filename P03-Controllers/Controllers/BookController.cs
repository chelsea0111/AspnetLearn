using Microsoft.AspNetCore.Mvc;
using P03_Controllers.Models;

namespace P03_Controllers.Controllers;

[Controller]
public class BookController : Controller
{
    [Route("book/{bookid}/{isloggedin}")]
    public IActionResult Index(int? bookid, [FromRoute] bool? isloggedin, Book book)
    {
        if (!bookid.HasValue)
        {
            return BadRequest("Book id should be supplied or empty!");
        }

        if (bookid <= 0 || bookid > 1000)
        {
            return BadRequest("Book id can not be less than 0 or greater than 1000");
        }

        // isLoggedin
        if (isloggedin == false)
        {
            return Unauthorized("User must be authenticated!!!");
        }

        return Content($"Book id: {bookid}, Book: {book}");
    }

    [Route("bookstore")]
    public IActionResult Bookstore()
    {
        int p1 = Convert.ToInt16(Request.Query["p1"]);
        // return new RedirectToActionResult("Books", "Store", null);
        return RedirectToAction("Books", "Store", new { id = p1 });
    }
}