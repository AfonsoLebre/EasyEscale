using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyEscale;

namespace EasyEscale
{
    public class Professor
    {
        public int Idprof { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }
        public string NProcesso { get; set; }

        public Professor()
        {

        }

        public Professor(int a,string b, string c, string d)
        {
            Idprof = a;
            NProcesso = b;
            Nome = c;
            Email = d;

        }

        public static List<Professor> Buscar()
        {
            List<Professor> profs = new List<Professor>();
            string conx = "server=localhost;user=root;password=root;database=easyescale";

            using (MySqlConnection con = new MySqlConnection(conx))
            {
                con.Open();
                string query = "SELECT * FROM professor";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                using (MySqlDataReader leitor = cmd.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        int IdProf = (int)leitor["IdProfessor"];
                        string Nproc = leitor["NProcesso"].ToString();
                        string Nome = leitor["Nome"].ToString();
                        string Email = leitor["Email"].ToString();

                        profs.Add(new Professor(IdProf, Nproc, Nome, Email));
                    }
                }
            }

            return profs;
        }

    }

        }

