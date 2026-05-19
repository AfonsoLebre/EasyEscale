using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyEscale
{
    public class Turma
    {
        public int IdTurma { get; set; }

        public int Ano { get; set; }

        public string Letra { get; set; }

        public string AnoLetivo { get; set; }

        public string Juncao { get; set; }
        public Turma()
        {

        }

        public Turma(int a, int b, string c, string d)
        {
            IdTurma = a;
            Ano = b;
            Letra = c;
            AnoLetivo = d;
        }

        public Turma(int a, int b, string c, string d,string e)
        {
            IdTurma = a;
            Ano = b;
            Letra = c;
            AnoLetivo = d;
            Juncao = e;
        }

        public static List<Turma> BuscarN()
        {
            List<Turma> Turmas = new List<Turma>();
            string conx = "server=localhost;user=root;password=root;database=easyescale";

            using (MySqlConnection con = new MySqlConnection(conx))
            {
                con.Open();
                string query = "SELECT * FROM turmas";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                using (MySqlDataReader leitor = cmd.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        int IdTurma = (int)leitor["IdTurma"];
                        int Ano = (int)leitor["Ano"];
                        string Letra = leitor["Letra"].ToString();
                        string AnoLetivo = leitor["AnoLetivo"].ToString();

                        Turmas.Add(new Turma(IdTurma, Ano, Letra, AnoLetivo));
                    }
                }
            }

            return Turmas;
        }
        public static List<Turma> BuscarJ()
        {
            List<Turma> Turmas = new List<Turma>();
            string conx = "server=localhost;user=root;password=root;database=easyescale";

            using (MySqlConnection con = new MySqlConnection(conx))
            {
                con.Open();
                string query = "SELECT * FROM turmas";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                using (MySqlDataReader leitor = cmd.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        int IdTurma = (int)leitor["IdTurma"];
                        int Ano = (int)leitor["Ano"];
                        string Letra = leitor["Letra"].ToString();
                        string AnoLetivo = leitor["AnoLetivo"].ToString();

                        string j = Ano + " " + Letra;

                        Turmas.Add(new Turma(IdTurma, Ano, Letra, AnoLetivo,j));
                    }
                }
            }

            return Turmas;
        }

    }
}
