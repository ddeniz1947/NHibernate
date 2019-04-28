using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SBlogA.Infrastructure
{
    public class SelectedTabAttiribute : ActionFilterAttribute
    {
        private readonly string _selectedTab;
        public SelectedTabAttiribute(string selectedItem)
        {
            _selectedTab = selectedItem;
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.SelectedTab = _selectedTab;
        }
    }
}