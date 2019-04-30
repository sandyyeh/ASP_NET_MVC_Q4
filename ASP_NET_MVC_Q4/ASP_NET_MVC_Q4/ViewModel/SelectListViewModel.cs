using ASP_NET_MVC_Q4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_NET_MVC_Q4.ViewModel
{
    public class SelectListViewModel
    {
        public Model1 Model1 { get; set; }
        public Model2 Model2 { get; set; }
        public string Id { get; set; }   
        public IEnumerable<SelectListItem> FirstselectListItem { get; set; }
        public IEnumerable<SelectListItem> SecondSelectListItem { get; set; }
      
    }


    public class Model2
    {
        public string ParentId { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
    }

}