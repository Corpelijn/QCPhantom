using QCPhantom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QCPhantom.Domain
{
    public class Data
    {
        public IEnumerable<Navbar> navbarItems()
        {
            var menu = new List<Navbar>();
            menu.Add(new Navbar { Id = 1, nameOption = "Dashboard", controller = "Home", action = "Index", imageClass = "fa fa-dashboard fa-fw", status = true, isParent = false, parentId = 0 });
            menu.Add(new Navbar { Id = 2, nameOption = "Results", imageClass = "fa fa-bar-chart-o fa-fw", status = true, isParent = true, parentId = 0 });
            menu.Add(new Navbar { Id = 3, nameOption = "Overview", controller = "Results", action = "Index", imageClass = "fa fa-bar-chart-o fa-fw", status = true, isParent = false, parentId = 2 });

            return menu.ToList();
        }
    }
}