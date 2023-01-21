using Restaurant_Project_ASP.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant_Project_ASP.NET.Repositories
{
    public class PaymentTypeRepository
    {
        private RestaurantDBEntities objRestaurantDbEntities;
        public PaymentTypeRepository()
        {
            objRestaurantDbEntities = new RestaurantDBEntities();
        }

        public IEnumerable<SelectListItem> GetAllPaymentType()
        {
            var  objSelectListItem = new List<SelectListItem>();
            objSelectListItem = (from obj in objRestaurantDbEntities.PaymentTypes
                                 select new SelectListItem()
                                 {
                                     Text = obj.PaymentTypeName,
                                     Value= obj.PaymentTypeId.ToString(),
                                     Selected=true
                                 }).ToList();
            return objSelectListItem;
        }

    }
}