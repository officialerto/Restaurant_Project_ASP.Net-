using Restaurant_Project_ASP.NET.Models;
using Restaurant_Project_ASP.NET.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant_Project_ASP.NET.Controllers
{
    public class HomeController : Controller
    {
        private RestaurantDBEntities objRestaurantDbEntities;
        public HomeController()
        {
            objRestaurantDbEntities = new RestaurantDBEntities();
        }

        // GET: Home
        public ActionResult Index()
        {
            CustomerRepository objCustomerRepository = new CustomerRepository();
            ItemRepository objItemRepository = new ItemRepository();
            PaymentTypeRepository objPaymentTypeRepository = new PaymentTypeRepository();

            var objMultipleModels = new Tuple<IEnumerable<SelectListItem>, IEnumerable<SelectListItem>, IEnumerable<SelectListItem>>
                (objCustomerRepository.GetAllCustomer(), objItemRepository.GetAllItems(), objPaymentTypeRepository.GetAllPaymentType());
            return View(objMultipleModels);
        }

        [HttpGet]
        public JsonResult getItemUnitPrice(int itemId)
        {
            decimal UnitPrice = objRestaurantDbEntities.Items.Single(model => model.ItemId == itemId).ItemPrice;

            return Json(UnitPrice, JsonRequestBehavior.AllowGet);
        }
    }
}