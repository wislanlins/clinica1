using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Clinica.Models;

namespace Clinica.Controllers
{
    public class PatientController : Controller
    {


        public ActionResult Cadastro(string cpf)
        {
            if (cpf != null)
            {
                Patient maybe = Patients.Get(cpf);
                if (maybe != null)
                {
                    return Json(maybe, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { status = "error" }, JsonRequestBehavior.AllowGet);
        }
    }
}
