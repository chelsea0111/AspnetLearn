using Microsoft.AspNetCore.Mvc;

namespace P03_Controllers.Controllers;

[Controller]
public class BookController : Controller
{
    [Route("book/{bookid}/{isloggedin}")]
    public IActionResult Index([FromQuery] int? bookid, bool? isloggedin)
    {
        if (!bookid.HasValue)
        {
            return BadRequest("Book id should be supplied or empty!");
        }

        if (bookid <= 0)
        {
            return BadRequest("Book id can not be less than 0");
        }

        if (bookid > 1000)
        {
            return BadRequest("Book id can not be greater than 1000");
        }

        // isLoggedin
        if (isloggedin == false)
        {
            return Unauthorized("User must be authenticated!!!");
        }

        return File("/carr.png", "image/png");
    }

    [Route("bookstore")]
    public IActionResult Bookstore()
    {
        int p1 = Convert.ToInt16(Request.Query["p1"]);
        // return new RedirectToActionResult("Books", "Store", null);
        return RedirectToAction("Books", "Store", new { id = p1 });
    }
}