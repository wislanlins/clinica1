using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Clinica.Model;

namespace Clinica
{
    public partial class Cadastro : System.Web.UI.Page
    {
        Paciente[] Banco = new Paciente[] {
            
        };

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string Pacientes(string cpf)
        {
            return "just a test";
        }
    }
}