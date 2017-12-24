using HtmlUI.Framework;
using HtmlUI.Model;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HtmlUI.Controller
{
    [ComVisible(true)]
    public class HelloController : IDAController
    {

        public void Post(string data)
        {
            MessageBox.Show("In Hello post:" + data);
        }

        public string ModelJson()
        {
            dynamic ViewBag;
            ViewBag = new ExpandoObject();

            ViewBag.Students = new Student[] {
                new Student { Id=1, Name = "Bruce Yu", Age = 40, Phone = "88822888" } ,
                new Student { Id=2, Name = "Jack", Age = 42, Phone = "88822000" } ,
                new Student { Id=3, Name = "Tom", Age = 43, Phone = "88822111" }
            };

            ViewBag.Course = new Course { Name = "C++ Essentials", Desc = "C++ Essentials" };
            string jsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(ViewBag);//"{'a':'abc','b':'123','c':1001}";
            return jsonStr;
        }
    }
}
