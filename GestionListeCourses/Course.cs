using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionListeCourses
{
    internal class Course
    {
        private static ConnexionBDD cnn = new ConnexionBDD("server=localhost;Port=3306; database=gestion_courses;uid=root;pwd=\"\";");
        private int idCourse;
        private string nomCourse;
        private DateTime dateDuJour;

        public Course(int idCourse, string nomCourse, DateTime dateDujour) 
        {
            this.idCourse = idCourse;
            this.nomCourse = nomCourse;
            this.dateDuJour = dateDujour;
        }



        public static void RecupererListeCourse(string nom, DateTime dateDuJour)
        {
            if (cnn.RechercherListeCourse(nom))
            {

            }
        }








        public int GetIdCourse() 
        {
            return this.idCourse;
        }
        public void SetIdCourse(int idCourse)
        {
            this.idCourse = idCourse;
        }

        public string GetNomCourse() 
        {
            return this.nomCourse;
        }
        public void SetNomCourse(string nomCourse)
        {
            this.nomCourse = nomCourse;
        }

        public DateTime GetDateDuJour()
        {
            return this.dateDuJour;
        }
        public void SetDateDuJour(DateTime dateDuJour)
        {
            this.dateDuJour = dateDuJour;
        }
    }
}


















