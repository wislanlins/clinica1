using System;
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
                return _DtNascimento.Split(' ')[0];
            }
            set
            {
                _DtNascimento = value;
            }
        }
        public string Sexo;
        public string Profissao;
        public string Fixo;
        public string Celular;
        public string Cep;
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