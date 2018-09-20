using System;
using System.Data.SqlClient;
using System.IO;
namespace Clinica.Models
{
    public class AdicionarPaciente
    {
        public string Cpf;
        public string Name;
        public string DtNascimento;
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
        public string Rh;


        private void Cadastrar(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(GetConnection());
            string sql = "insert into paciente (cpf, name,dtNascimento,sexo,profissao,fixo,celular,cep,estado,cidade, "
                + "logradouro,numEndereco,planoDeSaude,altura,peso,alergias,medicamento,abo,rh)"
                + "values (@cpf, @name, @dtNascimento, @sexo, @profissao, @fixo, @celular, @cep, @estado, @cidade, "
                + "@logradouro, @numEndereco, @planoDeSaude, @altura,@peso, @alergias, @medicamento, @abo,@rh)";
            try
            {    SqlCommand comando = new SqlCommand(sql, conn);
                comando.Parameters.Add(new SqlParameter("@cpf", Cpf));
                comando.Parameters.Add(new SqlParameter("@nome", Name));
                comando.Parameters.Add(new SqlParameter("@dtNascimento", DtNascimento));
                comando.Parameters.Add(new SqlParameter("@sexo", Sexo));
                comando.Parameters.Add(new SqlParameter("@profissao", Profissao));
                comando.Parameters.Add(new SqlParameter("@fixo", Fixo));
                comando.Parameters.Add(new SqlParameter("@celular", Celular));
                comando.Parameters.Add(new SqlParameter("@cep", Cep));
                comando.Parameters.Add(new SqlParameter("@estado", Estado));
                comando.Parameters.Add(new SqlParameter("@cidade", Cidade));
                comando.Parameters.Add(new SqlParameter("@logradouro", Logradouro));
                comando.Parameters.Add(new SqlParameter("@numEndereco", NumEndereco));
                comando.Parameters.Add(new SqlParameter("@planoDeSaude", PlanoDeSaude));
                comando.Parameters.Add(new SqlParameter("@altura", Altura));
                comando.Parameters.Add(new SqlParameter("@peso", Peso));
                comando.Parameters.Add(new SqlParameter("@alergias", Alergias));
                comando.Parameters.Add(new SqlParameter("@medicamento", Medicamento));
                comando.Parameters.Add(new SqlParameter("@abo", Abo));
                comando.Parameters.Add(new SqlParameter("@rh", Rh));
                conn.Open();
                comando.ExecuteNonQuery();
                conn.Close();
            }catch
        {
            
        }
        finally
        {
            conn.Close();
        }
    }

        private void Atualizar(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(GetConnection());
            string sql = "update paciente set (cpf = @cpf, name=@name,dtNascimento=@dtNascimento,sexo=@sexo,profissao=@profissao,"
            + "fixo=@fixo,celular=@celular,cep=@cep,estado=@estado,cidade=@cidade,logradouro=@logradouro,numEndereco=@numEndereco,"
            + "planoDeSaude=@planoDeSaude,altura=@altura,peso=@peso,alergias=@alergias,medicamento=@medicamento,abo=@abo,rh=@rh where cpf= @cpf)";
            try
            {
                SqlCommand comando = new SqlCommand(sql, conn);
                comando.Parameters.Add(new SqlParameter("@cpf", Cpf));
                comando.Parameters.Add(new SqlParameter("@nome", Name));
                comando.Parameters.Add(new SqlParameter("@dtNascimento", DtNascimento));
                comando.Parameters.Add(new SqlParameter("@sexo", Sexo));
                comando.Parameters.Add(new SqlParameter("@profissao", Profissao));
                comando.Parameters.Add(new SqlParameter("@fixo", Fixo));
                comando.Parameters.Add(new SqlParameter("@celular", Celular));
                comando.Parameters.Add(new SqlParameter("@cep", Cep));
                comando.Parameters.Add(new SqlParameter("@estado", Estado));
                comando.Parameters.Add(new SqlParameter("@cidade", Cidade));
                comando.Parameters.Add(new SqlParameter("@logradouro", Logradouro));
                comando.Parameters.Add(new SqlParameter("@numEndereco", NumEndereco));
                comando.Parameters.Add(new SqlParameter("@planoDeSaude", PlanoDeSaude));
                comando.Parameters.Add(new SqlParameter("@altura", Altura));
                comando.Parameters.Add(new SqlParameter("@peso", Peso));
                comando.Parameters.Add(new SqlParameter("@alergias", Alergias));
                comando.Parameters.Add(new SqlParameter("@medicamento", Medicamento));
                comando.Parameters.Add(new SqlParameter("@abo", Abo));
                comando.Parameters.Add(new SqlParameter("@rh", Rh));
                conn.Open();
                comando.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {

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