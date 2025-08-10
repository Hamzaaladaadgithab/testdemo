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

        // GET : Items/New
        public IActionResult New()
        {
            return View(); 
            
            }

        // POST : Items/New
        [HttpPost] 
        [ValidateAntiForgeryToken]
        public IActionResult New(Item item)
        {     
            if (item.Name== "100")
            {
                ModelState.AddModelError("CustomError", "Name cannot be 100");
            }

            if (ModelState.IsValid)
            {
                // ModelState kontrol

                _db.Items.Add(item);
                // Eğer model geçerliyse veritabanına ekle
                _db.SaveChanges();
                // Veritabanına kaydettikten sonra, kullanıcıyı listeleme sayfasına yönlendir
                return RedirectToAction("Index");
            }
            else
            {
              // Model geçerli değilse, hata mesajlarını göster
                return View(item);  
            }
        }



        // GET : Items/New
        public IActionResult Edit(int? Id){ 

            if(Id == null || Id == 0)
            {
                return NotFound();
            } 
            
            var item = _db.Items.Find(Id);

            if (item == null)
            {
                return NotFound();

            }

            return View(item);

        }



        // POST : Items/New
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Item item)
        {
            if (item.Name == "100")
            {
                ModelState.AddModelError("CustomError", "Name cannot be 100");
            }

            if (ModelState.IsValid)
            {
                // ModelState kontrol

                _db.Items.Update(item);
                // Eğer model geçerliyse veritabanına ekle
                _db.SaveChanges();
                // Veritabanına kaydettikten sonra, kullanıcıyı listeleme sayfasına yönlendir
                return RedirectToAction("Index");
            }
            else
            {
                // Model geçerli değilse, hata mesajlarını göster
                return View(item);
            }
             
        }


        // GET : Items/New
        public IActionResult Delete(int? Id)
        {   

            if (Id == null || Id == 0)
            {
                return NotFound();
            }

            var item = _db.Items.Find(Id);

            if (item == null)
            {
                return NotFound();

            }

            return View(item);

        }



        // POST : Items/New
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteItem(int? Id)
        {
            var item = _db.Items.Find(Id);
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
                _db.Items.Remove(item);
                
                _db.SaveChanges();
                // Veritabanına kaydettikten sonra, kullanıcıyı listeleme sayfasına yönlendir
                return RedirectToAction("Index");
           
        }

    }
}
