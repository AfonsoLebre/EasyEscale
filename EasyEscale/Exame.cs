using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyEscale
{
    public class Exame : Disciplina
    {
        public int Idxa { get; set; }
        public DateTime Data { get; set; }

        public string HoraIni { get; set; }
        public string HoraFini { get; set; }

        public int CodExa { get; set; }

        public string Juncao { get; set; }

        public Exame()
        {

        }

        public Exame(int idDisciplina, Curso curso, string designacao,
           int idExame, DateTime data, string horaIni, string horaFini, int codExa)
         : base(idDisciplina, curso, designacao)
        {
            Idxa = idExame;
            Data = data;
            HoraIni = horaIni;
            HoraFini = horaFini;
            CodExa = codExa;
        }

        public Exame(int idDisciplina, Curso curso, string designacao,
          int idExame, DateTime data, string horaIni, string horaFini, int codExa,string juncao)
        : base(idDisciplina, curso, designacao)
        {
            Idxa = idExame;
            Data = data;
            HoraIni = horaIni;
            HoraFini = horaFini;
            CodExa = codExa;
            Juncao = juncao;
        }

        public static List<Exame> Buscar()
        {
            List<Exame> exames = new List<Exame>();
            string conx = "server=localhost;user=root;password=root;database=easyescale";

            using (MySqlConnection con = new MySqlConnection(conx))
            {
                con.Open();
                string query = "SELECT * FROM exames INNER JOIN disciplina ON exames.IdDisciplina = disciplina.IdDisciplina WHERE YEAR(exames.Data) = YEAR(CURDATE()) ";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                using (MySqlDataReader leitor = cmd.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        int IdExa = (int)leitor["IdExame"];
                        DateTime Data = Convert.ToDateTime(leitor["Data"]);
                        string Horaini = leitor["HoraInicial"].ToString();
                        string Horafini = leitor["HoraFinal"].ToString();
                        int IdDisc = (int)leitor["IdDisciplina"];
                        int Codexa = (int)leitor["CodExame"];
                        Disciplina.Curso Cur = Enum.Parse<Disciplina.Curso>(leitor["Curso"].ToString());
                        string Designa = leitor["Designacao"].ToString();

                        exames.Add(new Exame(IdDisc,Cur,Designa,IdExa, Data, Horaini, Horafini, Codexa));
                    }
                }
            }

            return exames;
        }
        public static List<Exame> BuscarJ(bool todosAnos = false)
        {
            List<Exame> exames = new List<Exame>();
            string conx = "server=localhost;user=root;password=root;database=easyescale";

            using (MySqlConnection con = new MySqlConnection(conx))
            {
                con.Open();
                string query = "  SELECT * FROM exames INNER JOIN disciplina ON exames.IdDisciplina = disciplina.IdDisciplina WHERE exames.ES = 0 ";
                if (!todosAnos)
                {
                    query += " AND YEAR(exames.Data) = YEAR(CURDATE()) ";
                }
                query += ";";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                using (MySqlDataReader leitor = cmd.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        int IdExa = (int)leitor["IdExame"];
                        DateTime Data = Convert.ToDateTime(leitor["Data"]);
                        string Horaini = leitor["HoraInicial"].ToString();
                        string Horafini = leitor["HoraFinal"].ToString();
                        int IdDisc = (int)leitor["IdDisciplina"];
                        int Codexa = (int)leitor["CodExame"];
                        Disciplina.Curso Cur = Enum.Parse<Disciplina.Curso>(leitor["Curso"].ToString());
                        string Designa = leitor["Designacao"].ToString();

                        string Jucao = Designa + "   " + Codexa;

                        exames.Add(new Exame(IdDisc, Cur, Designa, IdExa, Data, Horaini, Horafini, Codexa, Jucao));
                    }
                }
            }

            return exames;
        }

        public static List<Exame> BuscarSE(bool todosAnos = false)
        {
            List<Exame> exames = new List<Exame>();
            string conx = "server=localhost;user=root;password=root;database=easyescale";

            using (MySqlConnection con = new MySqlConnection(conx))
            {
                con.Open();
                string query = "  SELECT * FROM exames INNER JOIN disciplina ON exames.IdDisciplina = disciplina.IdDisciplina WHERE exames.ES = 1 ";
                if (!todosAnos)
                {
                    query += " AND YEAR(exames.Data) = YEAR(CURDATE()) ";
                }
                query += ";";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                using (MySqlDataReader leitor = cmd.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        int IdExa = (int)leitor["IdExame"];
                        DateTime Data = Convert.ToDateTime(leitor["Data"]);
                        string Horaini = leitor["HoraInicial"].ToString();
                        string Horafini = leitor["HoraFinal"].ToString();
                        int IdDisc = (int)leitor["IdDisciplina"];
                        int Codexa = (int)leitor["CodExame"];
                        Disciplina.Curso Cur = Enum.Parse<Disciplina.Curso>(leitor["Curso"].ToString());
                        string Designa = leitor["Designacao"].ToString();

                        string Jucao = Designa + "   " + Codexa;

                        exames.Add(new Exame(IdDisc, Cur, Designa, IdExa, Data, Horaini, Horafini, Codexa, Jucao));
                    }
                }
            }

            return exames;
        }

        public static Exame BuscarEspecifico(int id)
        {

            string conx = "server=localhost;user=root;password=root;database=easyescale";
            Exame x = new Exame();
            using (MySqlConnection con = new MySqlConnection(conx))
            {

                con.Open();
                string query = " SELECT * FROM exames INNER JOIN disciplina ON exames.IdDisciplina = disciplina.IdDisciplina WHERE exames.IdExame = @ID; ";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    using (MySqlDataReader leitor = cmd.ExecuteReader())
                    {
                        while (leitor.Read())
                        {
                            int IdExa = (int)leitor["IdExame"];
                            DateTime Data = Convert.ToDateTime(leitor["Data"]);
                            string Horaini = leitor["HoraInicial"].ToString();
                            string Horafini = leitor["HoraFinal"].ToString();
                            int IdDisc = (int)leitor["IdDisciplina"];
                            int Codexa = (int)leitor["CodExame"];
                            Disciplina.Curso Cur = Enum.Parse<Disciplina.Curso>(leitor["Curso"].ToString());
                            string Designa = leitor["Designacao"].ToString();

                            string Jucao = Designa + "   " + Codexa;

                            x = new Exame(IdDisc, Cur, Designa, IdExa, Data, Horaini, Horafini, Codexa, Jucao);
                        }
                    }
                }
            }

            return x;
        }
    }
}
