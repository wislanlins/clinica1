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
        public static Patient Read(string cpf)
        {
            Patient patient = null;
            string connectionString = GetConnection();
            string queryString = string.Format("SELECT * FROM paciente WHERE cpf={0};", cpf);
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

        public static bool Create(Patient patient)
        {
            bool ok = true;
            using (SqlConnection conn = new SqlConnection(GetConnection()))
            {
                string sql = string.Format(
                    "insert into paciente  (cpf, name,dtNascimento,sexo,profissao,fixo,celular,cep,estado,cidade,logradouro,numEndereco,planoDeSaude,altura,peso,alergias,medicamento,abo,rh) values ('{0}', '{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}',{13},{14},'{15}','{16}','{17}','{18}');",
                    patient.Cpf,
                    patient.Name,
                    patient.DtNascimento,
                    patient.Sexo,
                    patient.Profissao,
                    patient.Fixo,
                    patient.Celular,
                    patient.Cep,
                    patient.Estado,
                    patient.Cidade,
                    patient.Logradouro,
                    patient.NumEndereco,
                    patient.PlanoDeSaude,
                    patient.Altura,
                    patient.Peso,
                    patient.Alergias,
                    patient.Medicamento,
                    patient.Abo,
                    (patient.Rh == "positivo") ? "+" : "-"
                );
                conn.Open();
                using (SqlCommand comando = new SqlCommand(sql, conn))
                {
                    try
                    {
                        comando.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                        ok = false;
                    }

                }
                return ok;
            }
        }

        public static bool Update(Patient patient)
        {
            bool ok = true;
            using (SqlConnection conn = new SqlConnection(GetConnection()))
            {
                string sql = string.Format(
                    "update paciente set cpf = '{0}', name='{1}',dtNascimento='{2}',sexo='{3}',profissao='{4}',"
                    + "fixo='{5}',celular='{6}',cep='{7}',estado='{8}',cidade='{9}',logradouro='{10}',numEndereco='{11}',"
                    + "planoDeSaude='{12}',altura={13},peso={14},alergias='{15}',medicamento='{16}',abo='{17}',rh='{18}' where cpf='{0}';",
                    patient.Cpf,
                    patient.Name,
                    patient.DtNascimento,
                    patient.Sexo,
                    patient.Profissao,
                    patient.Fixo,
                    patient.Celular,
                    patient.Cep,
                    patient.Estado,
                    patient.Cidade,
                    patient.Logradouro,
                    patient.NumEndereco,
                    patient.PlanoDeSaude,
                    patient.Altura,
                    patient.Peso,
                    patient.Alergias,
                    patient.Medicamento,
                    patient.Abo,
                    (patient.Rh == "positivo")? "+" : "-"
                );
                conn.Open();
                using (SqlCommand comando = new SqlCommand(sql, conn))
                {
                    Console.WriteLine(comando);
                    try
                    {
                        ok = comando.ExecuteNonQuery() == 1;
                    }
                    catch (Exception e)
                    {
                        ok = false;
                    }

                }
                return ok;
            }
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
