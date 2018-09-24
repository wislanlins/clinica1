using System;
using System.Web;
using System.Linq;

namespace Clinica.Models
{
    public class Patient
    {
        public string Cpf;
        public string Name;
        private string _DtNascimento;
        public string DtNascimento
        {
            get
            {
                if (_DtNascimento.Contains("/"))
                {
                    return _DtNascimento.Split(' ')[0].Split('/').Reverse().Aggregate("", (box, it) => box + it + "-").TrimEnd('-');
                }
                else
                {
                    return _DtNascimento;
                }
            }
            set
            {
                _DtNascimento = value;
            }
        }
        public string Sexo;
        public string Profissao;
        private string _Fixo;
        public string Fixo
        {
            get
            {
                return _Fixo.Replace(" ", "").Replace("(", "").Replace(")", "").Replace("-", "");
            }
            set
            {
                _Fixo = value;
            }
        }
        private string _Celular;
        public string Celular
        {
            get
            {
                return _Celular.Replace(" ", "").Replace("(", "").Replace(")", "").Replace("-", "");
            }
            set
            {
                _Celular = value;
            }
        }
        public string _Cep;
        public string Cep
        {
            get
            {
                return _Cep.Replace("-", "");
            }
            set
            {
                _Cep = value;
            }
        }
        public string Estado;
        public string Cidade;
        public string Logradouro;
        public string NumEndereco;
        public string PlanoDeSaude;
        public int Altura;
        public int Peso;
        public string Alergias;
        public string Medicamento;
        public string Abo;
        private string _Rh;
        public string Rh
        {
            get
            {
                if (_Rh == "+")
                {
                    return "positivo";
                }
                else if (_Rh == "-")
                {
                    return "negativo";
                }
                else
                {
                    return _Rh;
                }
            }
            set
            {
                _Rh = value;
            }
        }

        public Patient()
        {

        }

        public Patient(HttpRequestBase request)
        {
            Cpf = request.Form["Cpf"];
            Name = request.Form["Name"];
            DtNascimento = request.Form["DtNascimento"];
            Sexo = request.Form["Sexo"];
            Profissao = request.Form["Profissao"];
            Fixo = request.Form["Fixo"];
            Celular = request.Form["Celular"];
            Cep = request.Form["Cep"];
            Estado = request.Form["Estado"];
            Cidade = request.Form["Cidade"];
            Logradouro = request.Form["Logradouro"];
            NumEndereco = request.Form["NumEndereco"];
            PlanoDeSaude = request.Form["PlanoDeSaude"];
            Altura = int.Parse(request.Form["Altura"]);
            Peso = int.Parse(request.Form["Peso"]);
            Alergias = request.Form["Alergias"];
            Medicamento = request.Form["Medicamentos"];
            Abo = request.Form["Abo"];
            Rh = request.Form["Rh"];
        }

        public override string ToString()
        {
            return string.Format(
                "{cpf: \"{0}\", " +
                "name: \"{1}\", " +
                "dtNascimento: \"{2}\", " +
                "sexo: \"{3}\", " +
                "profissao: \"{4}\", " +
                "fixo: \"{5}\", " +
                "celular: \"{6}\"," +
                "cep: \"{7}\", " +
                "estado: \"{8}\", " +
                "cidade: \"{9}\"" +
                "logradouro: \"{10}\", " +
                "numEndereco: \"{11}\", " +
                "planoDeSaude: \"{12}\", " +
                "altura: \"{13}\", " +
                "peso: \"{14}\", " +
                "alergias: \"{15}\", " +
                "medicamento: \"{16}\", " +
                "abo: \"{17}\", " +
                "rh: \"{18}\" } ",
                Cpf,
                Name,
                DtNascimento,
                Sexo,
                Profissao,
                Fixo,
                Celular,
                Cep,
                Estado,
                Cidade,
                Logradouro,
                NumEndereco,
                PlanoDeSaude,
                Altura,
                Peso,
                Alergias,
                Medicamento,
                Abo,
                Rh);
        }
    }
}