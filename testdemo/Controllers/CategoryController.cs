using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using testdemo.Models;
using testdemo.Repository.Base;

namespace TestCoreApp.Controllers
{
    public class CategoryController : Controller
    {
        public CategoryController(IUintOfWork _myUnit)
        {
           //_repository = repository; 

            myUnit = _myUnit;
        }

        //private IRepository<Category> _repository;

        private readonly IUintOfWork myUnit;

        //public IActionResult Index()
        //{
        //    return View(_repository.FindAll());
        //}

        public async Task<IActionResult> Index()
        {
            var oneCat = myUnit.categoryes.SelectOne(x => x.Name == "Computers");

            var allCat = await myUnit.categoryes.FindAllAsync("Items");

            return View(allCat);
        }


        //GET
        public IActionResult New()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(Category category)
        {
            if (ModelState.IsValid)
            {   
                myUnit.categoryes.AddOne(category);

                return RedirectToAction("Index");
            }
            else
            {
                return View(category);
            }
        }

        //GET
        public IActionResult Edit(int? Id)
        {


            if (Id == null || Id == 0)
            {
                return NotFound();
            }

            var category = myUnit.categoryes.FindById(Id.Value);  

            if (category== null) 
            {
                return NotFound();

            }

            return View(category); 
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {  

                myUnit.categoryes.UpdateOne(category);

                return RedirectToAction("Index");
            }
            else
            {
                return View(category);
            }
        }

        //GET
        public IActionResult Delete(int? Id)
        {

            if (Id == null || Id == 0)
            {
                return NotFound();
            }

            var category = myUnit.categoryes.FindById(Id.Value);

            if (category == null)
            {
                return NotFound();

            }


            return View(category); 
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Category category)
        {    
             myUnit.categoryes.DeleteOne(category);


            TempData["successData"] = "category has been deleted successfully";
            return RedirectToAction("Index");
        }
    }
}