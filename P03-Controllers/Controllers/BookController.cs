using Microsoft.AspNetCore.Mvc;

namespace P03_Controllers.Controllers;

[Controller]
public class BookController : Controller
{
    [Route("book")]
    public IActionResult Index()
    {
        if (!Request.Query.ContainsKey("bookid"))
        {
            // Response.StatusCode = 400;
            // return Content("Book id should be supplied!");
            return BadRequest("Book id should be supplied!");
        }

        if (string.IsNullOrEmpty(Convert.ToString(Request.Query["bookid"])))
        {
            return BadRequest("Book id cannot be null or empty!");
        }

        var bookId = Convert.ToInt16(ControllerContext.HttpContext.Request.Query["bookid"]);
        if (bookId <= 0)
        {
            return BadRequest("Book id can not be less than 0");
        }

        if (bookId > 1000)
        {
            return BadRequest("Book id can not be greater than 1000");
        }

        // isLoggedin
        if (!Convert.ToBoolean(Request.Query["isloggedin"]))
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