using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GestionListeCourses.modele
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
            dateDuJour = dateDujour;
        }




        public static void AfficherListeCourse(string nomCourse, DataGridView dgvListeCourses)
        {
            int idCourse = cnn.SelectIdCoursesByNom(nomCourse);
            cnn.SelectIngredientsListeCoursesById(idCourse, dgvListeCourses);
        }




        public int GetIdCourse()
        {
            return idCourse;
        }
        public void SetIdCourse(int idCourse)
        {
            this.idCourse = idCourse;
        }

        public string GetNomCourse()
        {
            return nomCourse;
        }
        public void SetNomCourse(string nomCourse)
        {
            this.nomCourse = nomCourse;
        }

        public DateTime GetDateDuJour()
        {
            return dateDuJour;
        }
        public void SetDateDuJour(DateTime dateDuJour)
        {
            this.dateDuJour = dateDuJour;
        }
    }
}


















