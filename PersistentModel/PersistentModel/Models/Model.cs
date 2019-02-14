using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace PersistentModel.Models
{
    public class MyModel : PageModel
    {
        public string Message { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int NumChildren { get; set; }
        public List<Child> Children { get; set; }

        public MyModel()
        {
            Children = new List<Child>();
        }
    }

    public class Child
    {
        public string Name { get; set; }
    }
}
