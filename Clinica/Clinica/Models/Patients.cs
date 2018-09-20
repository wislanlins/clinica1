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

        public static void Create(Patient patient)
        {
            SqlConnection conn = new SqlConnection(GetConnection());
            string sql = "insert into paciente (cpf, name,dtNascimento,sexo,profissao,fixo,celular,cep,estado,cidade, "
                + "logradouro,numEndereco,planoDeSaude,altura,peso,alergias,medicamento,abo,rh)"
                + "values (@cpf, @name, @dtNascimento, @sexo, @profissao, @fixo, @celular, @cep, @estado, @cidade, "
                + "@logradouro, @numEndereco, @planoDeSaude, @altura,@peso, @alergias, @medicamento, @abo,@rh)";
            try
            {
                SqlCommand comando = new SqlCommand(sql, conn);
                comando.Parameters.Add(new SqlParameter("@cpf", patient.Cpf));
                comando.Parameters.Add(new SqlParameter("@name", patient.Name));
                comando.Parameters.Add(new SqlParameter("@dtNascimento", patient.DtNascimento));
                comando.Parameters.Add(new SqlParameter("@sexo", patient.Sexo));
                comando.Parameters.Add(new SqlParameter("@profissao", patient.Profissao));
                comando.Parameters.Add(new SqlParameter("@fixo", patient.Fixo));
                comando.Parameters.Add(new SqlParameter("@celular", patient.Celular));
                comando.Parameters.Add(new SqlParameter("@cep", patient.Cep));
                comando.Parameters.Add(new SqlParameter("@estado", patient.Estado));
                comando.Parameters.Add(new SqlParameter("@cidade", patient.Cidade));
                comando.Parameters.Add(new SqlParameter("@logradouro", patient.Logradouro));
                comando.Parameters.Add(new SqlParameter("@numEndereco", patient.NumEndereco));
                comando.Parameters.Add(new SqlParameter("@planoDeSaude", patient.PlanoDeSaude));
                comando.Parameters.Add(new SqlParameter("@altura", patient.Altura));
                comando.Parameters.Add(new SqlParameter("@peso", patient.Peso));
                comando.Parameters.Add(new SqlParameter("@alergias", patient.Alergias));
                comando.Parameters.Add(new SqlParameter("@medicamento", patient.Medicamento));
                comando.Parameters.Add(new SqlParameter("@abo", patient.Abo));
                comando.Parameters.Add(new SqlParameter("@rh", patient.Rh));
                conn.Open();
                comando.ExecuteNonQuery();
            }
            catch
            {

            }
            finally
            {
                conn.Close();
            }
        }

        public static void Update(Patient patient)
        {
            SqlConnection conn = new SqlConnection(GetConnection());
            string sql = "update paciente set (cpf = @cpf, name=@name,dtNascimento=@dtNascimento,sexo=@sexo,profissao=@profissao,"
            + "fixo=@fixo,celular=@celular,cep=@cep,estado=@estado,cidade=@cidade,logradouro=@logradouro,numEndereco=@numEndereco,"
            + "planoDeSaude=@planoDeSaude,altura=@altura,peso=@peso,alergias=@alergias,medicamento=@medicamento,abo=@abo,rh=@rh) where cpf= @cpf;";
            try
            {
                SqlCommand comando = new SqlCommand(sql, conn);
                comando.Parameters.Add(new SqlParameter("@cpf", patient.Cpf));
                comando.Parameters.Add(new SqlParameter("@name", patient.Name));
                comando.Parameters.Add(new SqlParameter("@dtNascimento", patient.DtNascimento));
                comando.Parameters.Add(new SqlParameter("@sexo", patient.Sexo));
                comando.Parameters.Add(new SqlParameter("@profissao", patient.Profissao));
                comando.Parameters.Add(new SqlParameter("@fixo", patient.Fixo));
                comando.Parameters.Add(new SqlParameter("@celular", patient.Celular));
                comando.Parameters.Add(new SqlParameter("@cep", patient.Cep));
                comando.Parameters.Add(new SqlParameter("@estado", patient.Estado));
                comando.Parameters.Add(new SqlParameter("@cidade", patient.Cidade));
                comando.Parameters.Add(new SqlParameter("@logradouro", patient.Logradouro));
                comando.Parameters.Add(new SqlParameter("@numEndereco", patient.NumEndereco));
                comando.Parameters.Add(new SqlParameter("@planoDeSaude", patient.PlanoDeSaude));
                comando.Parameters.Add(new SqlParameter("@altura", patient.Altura));
                comando.Parameters.Add(new SqlParameter("@peso", patient.Peso));
                comando.Parameters.Add(new SqlParameter("@alergias", patient.Alergias));
                comando.Parameters.Add(new SqlParameter("@medicamento", patient.Medicamento));
                comando.Parameters.Add(new SqlParameter("@abo", patient.Abo));
                comando.Parameters.Add(new SqlParameter("@rh", patient.Rh));
                conn.Open();
                comando.ExecuteNonQuery();
                
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                conn.Close();
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
