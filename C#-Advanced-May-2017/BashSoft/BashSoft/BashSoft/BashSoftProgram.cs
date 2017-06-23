using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft
{
    class BashSoftProgram
    {
        static void Main()
        {
            StudentsRepository.InitialzeData();
            StudentsRepository.GetAllStudentsFromCourse("Unity");
            StudentsRepository.GetStudentFromCourse("Unity", "Ivan");
        }
    }
}
