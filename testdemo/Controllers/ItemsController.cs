using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using testdemo.Data;
using testdemo.Models;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;


namespace testdemo.Controllers
{
    public class ItemsController : Controller
    {

        public ItemsController(AppDbContext db , IHostingEnvironment host)
        {    

            _db = db; 
            _host = host;   
        }   
        private readonly IHostingEnvironment _host; 

        private readonly AppDbContext _db; 
        
        
        public IActionResult Index()
        {   

            IEnumerable<Item> İtemsList = _db.Items.Include(c => c.Category).ToList();

            return View(İtemsList);
        }

        // GET : Items/New
        public IActionResult New()
            {   
            // Yeni bir Item oluştur ve View'a gönder
            createSelectList();
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
                string fileName = string.Empty;

                if (item.clientFile != null) {

                    // Eğer clientFile null değilse, yani bir dosya yüklenmişse
                    // Dosya adını oluştur ve item.imagePath'e ata
                    string  myUploads = Path.Combine(_host.WebRootPath, "images"); 

                    fileName = item.clientFile.FileName;
                    string fullPath = Path.Combine(myUploads, fileName);
                    item.clientFile.CopyTo(new FileStream(fullPath, FileMode.Create));  
                    item.imagePath=fileName; // Yüklenen dosyanın adını item.imagePath'e ata

                }
                _db.Items.Add(item);
               
                _db.SaveChanges();
                TempData["success"] = "Item created successfully";

                // Veritabanına kaydettikten sonra, kullanıcıyı listeleme sayfasına yönlendir
                return RedirectToAction("Index");
            }
            else
            {
              // Model geçerli değilse, hata mesajlarını göster
                return View(item);  
            }
        }

        public void createSelectList(int selectId =0)
        {
            //List<Category> categorys = new List<Category>
            //{
            //    new Category(){ Id = 0, Name = "Select Category" },
            //    new Category(){ Id = 1, Name = "Comuters" },
            //    new Category(){ Id = 2, Name = "Mobiles" },
            //    new Category(){ Id = 3, Name = "Electric machines" },

            //};  
     
            
            List<Category> categorys= _db.Categorys.ToList();
            
            // SelectList, Category listesini Id ve Name alanlarına göre oluşturur
            // ve seçili olan öğeyi belirlemek için selectId parametresini kullanır
            // Bu, Category listesini dropdown veya select elementinde kullanmak için uygundur

            SelectList ListItems = new SelectList(categorys, "Id", "Name", selectId);

            ViewBag.CategoryList = ListItems;

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
            createSelectList(item.CategoryId);

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
               
                _db.SaveChanges(); 
                TempData["success"] = "Item added successfully";  
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
            createSelectList(item.CategoryId);

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
                TempData["success"] = "Item deleted successfully";  
            // Veritabanına kaydettikten sonra, kullanıcıyı listeleme sayfasına yönlendir
            return RedirectToAction("Index");
           
        }

    }
}
