using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    public class Grades
    {
        public int GradesId { get; set; }
        public int gr { get; set; }

        public Grades() { }
        public Grades(int gradesId,int gr)
        {
            GradesId = gradesId;
            gr = gr;
        }
    }
}
