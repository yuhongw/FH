using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HtmlUI.Framework
{
    public class ControllerManager
    {

        static ControllerManager _Instance;
        public static ControllerManager Instance
        {
            get
            {
                if (_Instance==null)
                    _Instance = new ControllerManager();
                return _Instance;
            }
        }

        Dictionary<string, IDAController> controllers;

        public ControllerManager()
        {
            controllers = new Dictionary<string, IDAController>();
        }

        public IDAController GetByName(string controllerName)
        {
            string cName = System.IO.Path.GetFileNameWithoutExtension(controllerName);
            if (controllers.ContainsKey(cName))
            {
                return controllers[cName];
            }
            else
            {
                return null;
            }
        }

        public void InitControllers()
        {
            Assembly ass = Assembly.GetExecutingAssembly();
            foreach (Type t in ass.ExportedTypes)
            {
                if (t.GetInterfaces().Contains(typeof(IDAController)))
                {
                    controllers.Add(System.IO.Path.GetFileName(t.Name.Replace("Controller","")),(IDAController)System.Activator.CreateInstance(t));
                }
            }
        }
    }
}
