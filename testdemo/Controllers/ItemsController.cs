using Microsoft.AspNetCore.Mvc;
using testdemo.Data;
using testdemo.Models;

namespace testdemo.Controllers
{
    public class ItemsController : Controller
    {

        public ItemsController(AppDbContext db)
        {
            _db = db;
        }   



        private readonly AppDbContext _db; 
        
        
      

        public IActionResult Index()
        {   

            IEnumerable<Item> İtemsList = _db.Items.ToList();

            return View(İtemsList);
        }
    }
}
