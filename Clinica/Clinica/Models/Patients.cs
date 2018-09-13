using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace Clinica.Models
{
    public class Patients
    {
        public static Patient Get(string cpf)
        {
            Patient patient = null;
            string connectionString = GetConnection();
            string queryString = string.Format("SELECT * FROM paciente WHERE cpf='{0}';", cpf);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    reader.Read();
                    patient = new Patient
                    {
                        Cpf = reader[1].ToString(),
                        Name = reader[2].ToString(),
                        DtNascimento = reader[3].ToString(),
                        Sexo = reader[4].ToString(),
                        Profissao = reader[5].ToString(),
                        Fixo = reader[6].ToString(),
                        Celular = reader[7].ToString(),
                        Cep = reader[8].ToString(),
                        Estado = reader[9].ToString(),
                        Cidade = reader[10].ToString(),
                        Logradouro = reader[11].ToString(),
                        NumEndereco = reader[12].ToString(),
                        PlanoDeSaude = reader[13].ToString(),
                        Altura = int.Parse(reader[14].ToString()),
                        Peso = int.Parse(reader[15].ToString()),
                        Alergias = reader[16].ToString(),
                        Medicamento = reader[17].ToString(),
                        Abo = reader[18].ToString(),
                        Rh = reader[19].ToString()
                    };
                    // XXX What if there are more than one person with a CPF?
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
                finally
                {
                    reader.Close();
                }
            }
            return patient;
        }

        private static string GetConnection()
        {
            string text = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\config\conexao.txt";
            FileStream fs = File.OpenRead(text.ToString());
            string read = System.IO.File.ReadAllText(text.ToString());
            return read;
        }

    }
}
