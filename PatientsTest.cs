using Clinica.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.Tests.Models
{
    [TestFixture]
    public class PatientsTest
    {
        [Test]
        public void PrimeiroTeste()
        {
            Assert.Pass();
        }

        [Test]
        public void TestaSeConsegueExecutarGetNoServidor()
        {
            Patient patient = Patients.Get("00000000000");
            Assert.IsNull(patient);
            
        }

        [Test]
        public void TestaSeConsegueExecutarGetValidoNoServidor()
        {
            Patient gotten = Patients.Get("70713702060"); // 707.137.020-60
            Patient expected = new Patient
            {
                Cpf = "70713702060",
                Name = "João da Silva",
                DtNascimento = "08/05/1995",
                Sexo = "m",
                Profissao = "Marceneiro",
                Fixo = "6134614066",
                Celular = "61996871312",
                Cep = "72420220",
                Estado = "al",
                Cidade = "maceio",
                Logradouro = "CH",
                NumEndereco = "15",
                PlanoDeSaude = "amil",
                Altura = 173,
                Peso = 46,
                Alergias = "dipirona",
                Medicamento = "rupinol",
                Abo = "o",
                Rh = "positivo"
            };
            Assert.IsNotNull(gotten);
            Assert.AreEqual(gotten.Cpf, expected.Cpf);
            Assert.AreEqual(gotten.Name, expected.Name);
            Assert.AreEqual(gotten.Fixo, expected.Fixo);
            Assert.AreEqual(gotten.Celular, expected.Celular);
            Assert.AreEqual(gotten.DtNascimento, expected.DtNascimento);
            Assert.AreEqual(gotten.Rh, expected.Rh);
        }
    }
}
