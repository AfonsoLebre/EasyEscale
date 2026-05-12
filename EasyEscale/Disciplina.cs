using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyEscale
{
    public class Disciplina
    {
        public enum Curso {CientificoHumanistico,Profissional };
        public int IdD { get; set; }
        public Curso NCurso { get; set; }
        public string  Designacao { get; set; }



        public Disciplina()
        {
            
        }


        public Disciplina(int a, Curso b, string c)
        {
            IdD = a;
            NCurso = b;
            Designacao = c;
        }


        public Disciplina(int f)
        {
            IdD = f;
        }
    }
}
