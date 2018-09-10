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
            return @"{
    cpf: " + Cpf + @"
}";
        }
    }
}