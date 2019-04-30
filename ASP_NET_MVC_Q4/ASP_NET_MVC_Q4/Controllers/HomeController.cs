using ASP_NET_MVC_Q4.Models;
using ASP_NET_MVC_Q4.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_NET_MVC_Q4.Controllers
{
    public class HomeController : Controller
    {


        public ActionResult Index()
        {

            string file1 = Server.MapPath("~/App_Data/department.json");
            string json1 = System.IO.File.ReadAllText(file1);
            List<Model1> _list1 = JsonConvert.DeserializeObject<List<Model1>>(json1);
            List<SelectListItem> selectList1 = new List<SelectListItem>();

            foreach (var item in _list1)
            {
                selectList1.Add(new SelectListItem() { Text = item.Name, Value = item.Id });

            }


            SelectListViewModel viewModel = new SelectListViewModel()
            {
                FirstselectListItem = selectList1
            };


            return View(viewModel);
        }


        [HttpPost]
        public ActionResult Index(string department,string group)
        {
            return View();
        }
       
        [HttpPost]
        public JsonResult GetDepartment(string id)
        {
            List<KeyValuePair<string, string>> items = new List<KeyValuePair<string,string>>();

            if (!string.IsNullOrWhiteSpace(id))
            {
                string file2 = Server.MapPath("~/App_Data/sub_department.json");
                string json2 = System.IO.File.ReadAllText(file2);
                List<Model2> _list2 = JsonConvert.DeserializeObject<List<Model2>>(json2);
                List<SelectListItem> selectList2 = new List<SelectListItem>();

                foreach (var item2 in _list2)
                {
                    selectList2.Add(new SelectListItem() { Text = item2.Name, Value = item2.ParentId });
                }


                var query = selectList2.Where(x => x.Value == id).ToList();
                if (query.Count() > 0)
                {
                    foreach (var order in query)
                    {
                        items.Add(new KeyValuePair<string, string>(
                            order.Value.ToString(),
                            order.Text));
                    }
                }
            }
            return this.Json(items);
        }

      
        }
    
}