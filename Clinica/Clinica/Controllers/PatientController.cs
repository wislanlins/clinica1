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
                    maybe = new Patient();
                    isUpdate = false;
                }

                maybe.Cpf = Request.Form["Cpf"];
                maybe.Name = Request.Form["Name"];
                maybe.DtNascimento = Request.Form["DtNascimento"];
                maybe.Sexo = Request.Form["Sexo"];
                maybe.Profissao = Request.Form["Profissao"];
                maybe.Fixo = Request.Form["Fixo"];
                maybe.Celular = Request.Form["Celular"];
                maybe.Cep = Request.Form["Cep"];
                maybe.Estado = Request.Form["Estado"];
                maybe.Cidade = Request.Form["Cidade"];
                maybe.Logradouro = Request.Form["Logradouro"];
                maybe.NumEndereco = Request.Form["NumEndereco"];
                maybe.PlanoDeSaude = Request.Form["PlanoDeSaude"];
                maybe.Altura = int.Parse(Request.Form["Altura"]);
                maybe.Peso = int.Parse(Request.Form["Peso"]);
                maybe.Alergias = Request.Form["Alergias"];
                maybe.Medicamento = Request.Form["Medicamentos"];
                maybe.Abo = Request.Form["Abo"];
                maybe.Rh = Request.Form["Rh"];

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
