using Restaurant_Project_ASP.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant_Project_ASP.NET.Repositories
{
    public class ItemRepository
    {
        private RestaurantDBEntities objRestaurantDbEntities;
        public ItemRepository()
        {
            objRestaurantDbEntities = new RestaurantDBEntities();
        }

        public IEnumerable<SelectListItem> GetAllItems()
        {
            var objSelectListItem = new List<SelectListItem>();
            objSelectListItem = (from obj in objRestaurantDbEntities.Items
                                 select new SelectListItem()
                                 {
                                     Text = obj.ItemName,
                                     Value = obj.ItemId.ToString(),
                                     Selected = true
                                 }).ToList();
            return objSelectListItem;
        }

    }
}