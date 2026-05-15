using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Org.BouncyCastle.Crypto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.IO.Packaging;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows;

namespace EasyEscale
{
    internal class metodos
    {
        
        public static DataTable Disciplinas()
        {
            DataTable dt = new DataTable();
            string con = "server=localhost;user=root;password=root;database=easyescale";
            List<string> valor = new List<string>();
            using (MySqlConnection conx = new MySqlConnection(con))
            {
                try
                {
                    conx.Open();
                    string queryCombo = "Select IdDisciplina,Designacao from disciplina";

                    MySqlCommand cmd = new MySqlCommand(queryCombo, conx);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {

                        dt.Load(reader);

                    }
                   


                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
                return dt;



            }


        }

        public static string AddExame(DateTime a,string horai,string horaf,int idD, int CoDE,int es)
        {
            string sucesso = "";
            string con = "server=localhost;user=root;password=root;database=easyescale";
            using (MySqlConnection conx = new MySqlConnection(con))
            {
                conx.Open();
                MySqlTransaction tran = conx.BeginTransaction();
                string query = "Insert into exames(exames.`Data`,HoraInicial,HoraFinal,IdDisciplina,CodExame,ES) values(@Data,@HoraIni,@HoraFini,@Dis,@Cod,@ES);";
                MySqlCommand cmd = new MySqlCommand(query, conx);
                cmd.Parameters.AddWithValue("@Data", a);
                cmd.Parameters.AddWithValue("@HoraIni", horai);
                cmd.Parameters.AddWithValue("@HoraFini", horaf);
                cmd.Parameters.AddWithValue("@Dis", idD);
                cmd.Parameters.AddWithValue("@Cod", CoDE);
                cmd.Parameters.AddWithValue("@ES", es);

                try
                {
                  
                    cmd.ExecuteNonQuery();
                    sucesso = "Exame Adicinado com Sucesso";
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    sucesso = ex.Message;
                    tran.Rollback();
                }



            }
               

            


            return sucesso;





        }
        public static string AddREU(DateTime a, string horai, string horaf, int idD, int CoDE)
        {
            string sucesso = "";
            string con = "server=localhost;user=root;password=rootroot;database=easyescale";
            MySqlConnection conx = new MySqlConnection(con);
            string query = "START TRANSACTION;\r\n\r\nInsert into exames(exames.`Data`,HoraInicial,HoraFinal,IdDisciplina,CodExame) values(@Data,@HoraIni,@HoraFini,@Dis,@Cod);\r\nCOMMIT;";
            MySqlCommand cmd = new MySqlCommand(query, conx);
            cmd.Parameters.AddWithValue("@Data", a);
            cmd.Parameters.AddWithValue("@HoraIni", horai);
            cmd.Parameters.AddWithValue("@HoraFini", horaf);
            cmd.Parameters.AddWithValue("@Dis", idD);
            cmd.Parameters.AddWithValue("@Cod", CoDE);

            try
            {
                conx.Open();
                cmd.ExecuteNonQuery();
                sucesso = "Exame Adicinado com Sucesso";
            }
            catch (Exception ex)
            {
                sucesso = ex.Message;

            }




            return sucesso;





        }

        public static string AddTurmas(DateTime a, string horai, string horaf, int idD, int CoDE)
        {
            string sucesso = "";
            string con = "server=localhost;user=root;password=rootroot;database=easyescale";
            MySqlConnection conx = new MySqlConnection(con);
            string query = "START TRANSACTION;\r\n\r\nInsert into exames(exames.`Data`,HoraInicial,HoraFinal,IdDisciplina,CodExame) values(@Data,@HoraIni,@HoraFini,@Dis,@Cod);\r\nCOMMIT;";
            MySqlCommand cmd = new MySqlCommand(query, conx);
            cmd.Parameters.AddWithValue("@Data", a);
            cmd.Parameters.AddWithValue("@HoraIni", horai);
            cmd.Parameters.AddWithValue("@HoraFini", horaf);
            cmd.Parameters.AddWithValue("@Dis", idD);
            cmd.Parameters.AddWithValue("@Cod", CoDE);

            try
            {
                conx.Open();
                cmd.ExecuteNonQuery();
                sucesso = "Exame Adicinado com Sucesso";
            }
            catch (Exception ex)
            {
                sucesso = ex.Message;

            }




            return sucesso;





        }

        public static string AddTurmasP(int A, char L, string AL, List<int> Ids)
        {
            string sucesso = "";
            string con = "server=localhost;user=root;password=rootroot;database=easyescale";


            using(MySqlConnection conx = new MySqlConnection(con))
            {
                conx.Open();

                MySqlTransaction tran = conx.BeginTransaction();
                try
                { 

                string query = "Insert into turmas(Ano,Letra,AnoLetivo) values(@Ano,@Letra,@AL);";
               
                MySqlCommand cmd = new MySqlCommand(query, conx, tran);



                cmd.Parameters.AddWithValue("@Ano", A);
                cmd.Parameters.AddWithValue("@Letra", L);
                cmd.Parameters.AddWithValue("@AL", AL);

               

                

                

                    cmd.ExecuteNonQuery();
                    int id = (int)cmd.LastInsertedId;
                    string ids = id.ToString();

                    string query2 = "Insert into turmasprofessor(IdTurma, IdProfessor) values(@T, @P);";
                    MySqlCommand cmd2 = new MySqlCommand(query2, conx);
                    cmd2.Parameters.AddWithValue("@T", id);
                    cmd2.Parameters.Add("@P", MySqlDbType.Int32);
                    foreach (int i in Ids)
                    {

                        cmd2.Parameters["@P"].Value = i;
                        cmd2.ExecuteNonQuery();

                    }

                    tran.Commit();



                }
                catch (Exception ex)
                {
                    sucesso = ex.Message + "\n" + "id: " + Ids;
                    tran.Rollback();

                }

                


                return sucesso;





            }
        }

        public static string AddHora(int Idp,string HI,string Hf,string Ds,int IdD,int Idt)
        {
            string conx = "server=localhost;user=root;password=rootroot;database=easyescale";
            string sucesso = "";


            using (MySqlConnection con = new MySqlConnection(conx))
            {
                con.Open();

                MySqlTransaction tran = con.BeginTransaction();
                try
                {
                    string query = "Insert into aulas(IdProfessor,HoraInicial,HoraFinal,Dia_Semana,IdDisciplina,IdTurma) values (@Idp,@Hi,@Hf,@Ds,@IdD,@IdT)";

                    MySqlCommand cmd = new MySqlCommand(query, con, tran);



                    cmd.Parameters.AddWithValue("@Idp", Idp);
                    cmd.Parameters.AddWithValue("@Hi", HI);
                    cmd.Parameters.AddWithValue("@Hf", Hf);
                    cmd.Parameters.AddWithValue("@Ds", Ds);
                    cmd.Parameters.AddWithValue("@IdD", IdD);
                    cmd.Parameters.AddWithValue("@Idt", Idt);

                    cmd.ExecuteNonQuery();


                    sucesso = "Aula Adicionada com Sucesso";
                }
                catch (Exception ex)
                {
                    sucesso = ex.Message;
                    
                    tran.Rollback();
                    return sucesso;
                }
                
                tran.Commit();


                return sucesso;
            }



        }


        public static string AddP(string N, string E, string Np, List<int> Dis)
        {
            string conx = "server=localhost;user=root;password=rootroot;database=easyescale";

            string sucesso = "";


            using (MySqlConnection con = new MySqlConnection(conx))
            {
                {


                    con.Open();
                    MySqlTransaction tran = con.BeginTransaction();

                    try
                    {
                        string query = "Insert into professor(Nome,Email,NProcesso) values(@nome,@mail,@proce);";
                        MySqlCommand cmd = new MySqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@proce", Np);
                        cmd.Parameters.AddWithValue("@nome", N);
                        cmd.Parameters.AddWithValue("@mail", E);

                        cmd.ExecuteNonQuery();

                        int id = (int)cmd.LastInsertedId;

                        string query2 = "Insert into disciprofessor(IdProfessor, IdDisciplina) values(@T, @P);";
                        MySqlCommand cmd2 = new MySqlCommand(query2, con);

                        cmd2.Parameters.AddWithValue("@T", id);
                        cmd2.Parameters.Add("@P", MySqlDbType.Int32);
                        foreach (int i in Dis)
                        {

                            cmd2.Parameters["@P"].Value = i;
                            cmd2.ExecuteNonQuery();

                        }

                        tran.Commit();


                        sucesso = "Professor Adicionado";

                        return sucesso;


                    }
                    catch (Exception ex)
                    {
                        sucesso = ex.Message;
                        tran.Rollback();
                        return sucesso;
                    }



                }

            }



      

    }
        public static string DiaSenana(DayOfWeek dia)
        {
            switch (dia)
            {
                case DayOfWeek.Sunday: return "Domingo";
                case DayOfWeek.Monday: return "Segunda-Feira";
                case DayOfWeek.Tuesday: return "Terça-Feira";
                case DayOfWeek.Wednesday: return "Quarta-Feira";
                case DayOfWeek.Thursday: return "Quinta-Feira";
                case DayOfWeek.Friday: return "Sexta-Feira";
                case DayOfWeek.Saturday: return "Sabado";
                default: return "";
            }
        }

        
       public static Dictionary<int, string> GeradorEsCalasExames(Exame x)
{
    string conx = "server=localhost;user=root;password=root;database=easyescale";
     Dictionary<int, string> ProfsEscolhidos = new Dictionary<int, string>();
    List<Aula> aulas = new List<Aula>();
    Dictionary<int, int> escolhidos = new Dictionary<int, int>();
    Dictionary<int, string> professores = new Dictionary<int, string>();

    using (MySqlConnection con = new MySqlConnection(conx))
    {
        con.Open();
        string query = "SELECT * FROM professor LEFT JOIN aulas ON aulas.IdProfessor = professor.IdProfessor";
        MySqlCommand cmd = new MySqlCommand(query, con);

        using (MySqlDataReader leitor = cmd.ExecuteReader())
        {
            while (leitor.Read())
            {
                        int idaula;
                        int dis;
                        int T;
                        string hi;
                        string hf;
                        string ds;
                        if (leitor["IdAula"] == DBNull.Value)
                        {
                            idaula = 0;
                            dis = 0;
                            T = 0;
                            hi = "20:00";
                            hf = "21:00";
                            ds = "Sabado";
                        }
                        else
                        {
                            idaula = (int)leitor["IdAula"];
                            dis = (int)leitor["IdDisciplina"];
                            T = (int)leitor["IdTurma"];
                            hi = leitor["HoraInicial"].ToString();
                            hf = leitor["HoraFinal"].ToString();
                            ds = leitor["Dia_Semana"].ToString();




                        }

                        int idProf = (int)leitor["IdProfessor"];
                         string nome = leitor["Nome"].ToString();

               
                if (!professores.ContainsKey(idProf))
                {
                    professores.Add(idProf, nome);
                }
                   

                aulas.Add(new Aula(idProf, leitor["NProcesso"].ToString(), nome, leitor["Email"].ToString(),
                                   idaula, dis, T, hi, hf, ds));
            }
        }
                List<int> menores = new List<int>();
                List<string> profs = new List<string>();

        foreach (int idProf in professores.Keys)
        {
            escolhidos[idProf] = 0;
        }

                try
                {
                    if (!TimeSpan.TryParse(x.HoraIni, out TimeSpan HoraExIni))
                    {
                        throw new Exception("Erro a Carregar Horas de Exame");
                    }

                    if (!TimeSpan.TryParse(x.HoraFini, out TimeSpan HoraExFini))
                    {
                        throw new Exception("Erro a Carregar Horas de Exame");
                    }



                    foreach (Aula au in aulas)
                    {
                        if (au.DSemana == metodos.DiaSenana(x.Data.DayOfWeek))
                        {
                            if (TimeSpan.TryParse(au.HI, out TimeSpan HoraAulIni) && TimeSpan.TryParse(au.Hf, out TimeSpan HoraAulFini))
                            {
                                if (HoraExIni < HoraAulFini && HoraExFini > HoraAulIni)
                                {
                                    escolhidos[au.Idprof]+= 9999;
                                }

                            }
                        }
                        if(au.IdD == x.IdD)
                        {
                            escolhidos[au.Idprof] += 9999;
                        }
                    }


                     menores = escolhidos.OrderBy(kv => kv.Value)
                                            .Take(5)
                                            .Select(kv => kv.Key)
                                            .ToList();
                    profs = menores.Select(id => professores[id]).ToList();

                   foreach (int m in menores)
                    {
                        ProfsEscolhidos.Add(m, professores[m]);
                    }


                   


                }
                catch (Exception ex)
                {
                    profs.Clear();
                    profs.Add(ex.Message);
                    
                }

                return ProfsEscolhidos;


            }

        }

      


        public static Dictionary<int, string> GeradorEscalasReunioes(Reuniao r)
        {
            string conx = "server=localhost;user=root;password=root;database=easyescale";
            Dictionary<int, string> ProfsEscolhidos = new Dictionary<int, string>();
            List<Aula> aulas = new List<Aula>();

            Dictionary<int, int> sobreposicoes = new Dictionary<int, int>();
            Dictionary<int, string> professores = new Dictionary<int, string>();

            using (MySqlConnection con = new MySqlConnection(conx))
            {
                con.Open();

                string query = @"
                    SELECT p.IdProfessor, p.Nome, p.NProcesso, p.Email, a.IdAula, a.IdDisciplina, a.IdTurma, a.HoraInicial, a.HoraFinal, a.Dia_Semana
                    FROM professor p
                    INNER JOIN turmasprofessor tp ON p.IdProfessor = tp.IdProfessor
                    LEFT JOIN aulas a ON a.IdProfessor = p.IdProfessor
                    WHERE tp.IdTurma = @IdTurma";

                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@IdTurma", r.IdTurma);

                using (MySqlDataReader leitor = cmd.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        int idProf = (int)leitor["IdProfessor"];
                        string nome = leitor["Nome"].ToString();

                        if (!professores.ContainsKey(idProf))
                        {
                            professores.Add(idProf, nome);
                            sobreposicoes.Add(idProf, 0); 
                        }

                        if (leitor["IdAula"] != DBNull.Value)
                        {
                            int idaula = (int)leitor["IdAula"];
                            int dis = (int)leitor["IdDisciplina"];
                            int t = (int)leitor["IdTurma"];
                            string hi = leitor["HoraInicial"].ToString();
                            string hf = leitor["HoraFinal"].ToString();
                            string ds = leitor["Dia_Semana"].ToString();

                            aulas.Add(new Aula(idProf, leitor["NProcesso"].ToString(), nome, leitor["Email"].ToString(), idaula, dis, t, hi, hf, ds));
                        }
                    }
                }

                try
                {
                    TimeSpan HoraReuIni = TimeSpan.Parse(r.HoraIni);
                    TimeSpan HoraReuFini = TimeSpan.Parse(r.HoraFini);

                    Dictionary<int, int> pontos = new Dictionary<int, int>();
                    foreach (var id in professores.Keys) pontos.Add(id, 0);

                    foreach (Aula au in aulas)
                    {
                        if (au.DSemana == metodos.DiaSenana(r.Data.DayOfWeek))
                        {
                            if (TimeSpan.TryParse(au.HI, out TimeSpan HoraAulIni) && TimeSpan.TryParse(au.Hf, out TimeSpan HoraAulFini))
                            {
                                if (HoraReuIni < HoraAulFini && HoraReuFini > HoraAulIni)
                                {
                                    pontos[au.Idprof] += 9999;
                                }
                            }
                        }
                    }

                    
                    var ordenados = pontos.OrderBy(kv => kv.Value).Take(3).ToList();

                    foreach (var kvp in ordenados)
                    {
                        ProfsEscolhidos.Add(kvp.Key, professores[kvp.Key]);
                    }
                }
                catch (Exception ex)
                {
                    ProfsEscolhidos.Clear();
                    MessageBox.Show("Erro a Carregar Horas de Reunião: " + ex.Message);
                }

                return ProfsEscolhidos;
            }
        }

        public static string GuardaEscala(Dictionary<int,string> x, int z, bool eReuniao = false)
        {
            string conx = "server=localhost;user=root;password=root;database=easyescale";
            int contador = 0;
            try
            {
                using (MySqlConnection con = new MySqlConnection(conx))
                {
                    con.Open();
                    MySqlTransaction tran = con.BeginTransaction();

                   
                    string queryDel = "DELETE FROM vigiasexames WHERE IdExame = @P;";
                    MySqlCommand cmdDel = new MySqlCommand(queryDel, con, tran);
                    cmdDel.Parameters.AddWithValue("@P", z);
                    cmdDel.ExecuteNonQuery();

                    string query = "Insert into vigiasexames(IdProfessor, IdExame, Estado) values(@T, @P, @E);";
                    MySqlCommand cmd = new MySqlCommand(query, con, tran);

                    cmd.Parameters.AddWithValue("@P", z);
                    cmd.Parameters.AddWithValue("@T", 0);
                    cmd.Parameters.AddWithValue("@E", "efetivo");
                    foreach (int m in x.Keys)
                    {
                        contador++;
                        
                        if (eReuniao)
                        {
                            cmd.Parameters["@E"].Value = "efetivo";
                        }
                        else
                        {
                            if (contador <= 3)
                            {
                                cmd.Parameters["@E"].Value = "efetivo";
                            }
                            else
                            { 
                                cmd.Parameters["@E"].Value = "suplente";
                            }
                        }
                        cmd.Parameters["@T"].Value = m;
                        cmd.ExecuteNonQuery();
                    }


                    tran.Commit();

                }


                return "Escala Guardada com Sucesso";
            }
            catch (Exception A)
            {
                return "Erro a Guardar Escala: " + A.Message;
            }
        }

        public static Dictionary<string, string> BuscaGuardados(int id)
        {
            string conx = "server=localhost;user=root;password=root;database=easyescale";
            Dictionary<string, string> Escala = new Dictionary<string, string>();
            using (MySqlConnection con = new MySqlConnection(conx))
            {
                con.Open();
                string query = "SELECT DISTINCT professor.Nome, professor.NProcesso, vigiasexames.Estado FROM professor INNER JOIN vigiasexames ON professor.IdProfessor = vigiasexames.IdProfessor WHERE vigiasexames.IdExame = @id ORDER BY vigiasexames.Estado ASC";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);
                using (MySqlDataReader leitor = cmd.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        string nProcesso = leitor["NProcesso"].ToString();
                        string nome = leitor["Nome"].ToString();
                        
                       
                        if (!Escala.ContainsKey(nProcesso))
                        {
                            Escala.Add(nProcesso, nome);
                        }
                    }
                }
                return Escala;
            }
        }
       
    }
}
