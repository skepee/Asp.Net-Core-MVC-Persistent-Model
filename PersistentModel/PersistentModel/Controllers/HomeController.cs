using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PersistentModel.Models;

namespace PersistentModel.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Step1()
        {
            Helper.Init();
            MyModel model = new MyModel
            {
                Message = "Step 1 OK!"
            };

            return View(model.Sync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult OnStep1([Bind("Name, Surname")] MyModel model)
        {
            if (ModelState.IsValid)
            {
                return View("Step2", model.Sync());
            }
            return View("Step2");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult OnStep2([Bind("NumChildren")] MyModel model)
        {
            if (ModelState.IsValid)
            {
                model.Message = "Step 2 OK!";

                for (int i = 0; i < model.NumChildren; i++)
                    model.Children.Add(new Child {Name="Child " + (i + 1).ToString() });

                return View("Result", model.Sync());
            }
            return View("Result");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
