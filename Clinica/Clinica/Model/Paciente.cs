using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinica.Model
{
    public class Paciente
    {
        string Cpf;
        string Name;
        string DtNascimento;
        string Sexo;
        string Profissao;
        string Fixo;
        string Celular;
        string Cep;
        string Estado;
        string Cidade;
        string Logradouro;
        string NumeroEndereco;
        string PlanoDeSaude;
        int Altura;
        int Peso;
        string Alergias;
        string Medicamento;
        string Abo;
        string Rh;

        public string ToString()
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
                NumeroEndereco,
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