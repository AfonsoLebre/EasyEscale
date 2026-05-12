using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyEscale
{
    public class Aula : Professor 
    {

       

        public int IdA { get; set; }

       public string HI { get; set; }
        public string Hf { get; set; }

        public string DSemana { get; set; }

        public int IdD { get; set; }

        public int IdT { get; set; }


        public Aula()
        {
            
        }

        public Aula(int idProf, string nProc, string nome, string email,
            int idAula, int idDisciplina, int idTurma, string horaIni, string horaFim, string diaSemana)
    : base(idProf, nProc, nome, email)
        {
            IdA = idAula;
            IdD = idDisciplina;
            IdT = idTurma;
            HI = horaIni;
            Hf = horaFim;
            DSemana = diaSemana;
        }


    }
}
