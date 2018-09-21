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
using System.IO;

namespace Clinica.Controllers
{
    public class PatientController : Controller
    {


        public ActionResult Cadastro(string cpf)
        {
            Patient maybe;

            if (Request.HttpMethod == "GET")
            {
                if (cpf != null)
                {
                    maybe = Patients.Read(cpf);
                    if (maybe != null)
                    {
                        return Json(maybe, JsonRequestBehavior.AllowGet);
                    }
                }

            }
            else if (Request.HttpMethod == "POST")
            {
                cpf = Request.Form["Cpf"];
                bool isUpdate = true;
                maybe = Patients.Read(cpf);
                if (maybe == null)
                {
                    isUpdate = false;
                }
                maybe = new Patient(Request);

                bool completed = (isUpdate)? Patients.Update(maybe) : Patients.Create(maybe);
                if (completed)
                {
                    return Json(new { success = true });
                }
            }
            return Json(new { status = "error" }, JsonRequestBehavior.AllowGet);
        }
    }
}
