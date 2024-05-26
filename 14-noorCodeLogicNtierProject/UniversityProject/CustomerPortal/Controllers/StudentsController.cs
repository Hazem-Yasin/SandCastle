using Microsoft.AspNetCore.Mvc;

namespace CustomerPortal.Controllers
{
    public class StudentsController : Controller
    {
        [HttpGet]
        public IActionResult StudentsList()
        {

            //--get students List

            return View();
        }
    }
}
