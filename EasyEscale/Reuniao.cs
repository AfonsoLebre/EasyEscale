using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyEscale
{
    public class Reuniao:Turma
    {
        public int IdRe { get; set; }
        public DateTime Data { get; set; }

        public string HoraIni { get; set; }
        public string HoraFini { get; set; }

        public int sala { get; set; }

        public string juncao { get; set; }
        public Reuniao()
        {

        }

        public Reuniao(int idTurma, int ano, string letra, string anoLetivo, int a, DateTime b, string c, string d, int e) : base(idTurma, ano, letra,anoLetivo)
        {
            IdRe = a;
            Data = b;
            HoraIni= c;
            HoraFini= d;
            sala = e;
        }
        public Reuniao(int idTurma, int ano, string letra, string anoLetivo, int a, DateTime b, string c, string d, int e,string f) : base(idTurma, ano, letra, anoLetivo)
        {
            IdRe = a;
            Data = b;
            HoraIni = c;
            HoraFini = d;
            sala = e;
            juncao = f;
        }

        public static List<Reuniao> Buscar()
        {
            List<Reuniao> Reu = new List<Reuniao>();
            string conx = "server=localhost;user=root;password=root;database=easyescale";

            using (MySqlConnection con = new MySqlConnection(conx))
            {
                con.Open();
                string query = "SELECT reuniao.IdReuniao, reuniao.HoraInicial, reuniao.HoraFinal, reuniao.`Data`,\r\n     reuniao.IdTurma, reuniao.sala, turmas.Letra, turmas.Ano, turmas.AnoLetivo FROM reuniao INNER JOIN turmas ON\r\n     reuniao.IdTurma = turmas.IdTurma";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                using (MySqlDataReader leitor = cmd.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        int IdReu = (int)leitor["IdReuniao"];
                        string Horaini = leitor["HoraInicial"].ToString();
                        string Horafini = leitor["HoraFinal"].ToString();
                        DateTime Data = Convert.ToDateTime(leitor["Data"]);
                        int IdTurma = (int)leitor["IdTurma"];
                        int sala = (int)leitor["sala"];
                       string Letra = leitor["Letra"].ToString();
                        int ano = (int)leitor["Ano"];
                        string anoLetivo = leitor["AnoLetivo"].ToString();
                        string Jucao ="Reunião" + "   " + ano + "  " + Letra;

                        Reu.Add(new Reuniao(IdTurma,ano,Letra,anoLetivo,IdReu,Data,Horaini,Horafini,sala,Jucao));
                    }
                }
            }

            return Reu;
        }

    }
}
