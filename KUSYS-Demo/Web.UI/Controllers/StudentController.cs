namespace Web.UI.Controllers
{
    public class StudentController : Controller
    {

        public IActionResult StudentList()
        {
            return View();
        }

        public IActionResult CreateStudent()
        {
            return View();
        }
        public IActionResult EditStudent()
        {
            return View();
        }
        public IActionResult StudentCourseList()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
