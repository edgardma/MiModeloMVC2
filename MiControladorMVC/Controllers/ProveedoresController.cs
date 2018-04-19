using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiControladorMVC.Controllers
{
    public class ProveedoresController : Controller
    {
        // GET: Proveedores
        public string TodosLosProveedores()
        {
            return @"<ul>
                     <li>Alcampo</li>
                     <li>Carrefur</li>
                     <li>Mecadona</li>
                     <li>Gadis</li>
                     </ul>";
        }
    }
}