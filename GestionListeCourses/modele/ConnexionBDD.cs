using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionListeCourses.modele
{
    internal class ConnexionBDD
    {
        private string connectionString;
        private MySqlConnection cnn;

        public ConnexionBDD(string connectionString)
        {
            this.connectionString = connectionString;
            cnn = GetCnnInstance();
        }


        private MySqlConnection GetCnnInstance()
        {
            if (cnn == null)
            {
                cnn = new MySqlConnection(connectionString);
            }

            return cnn;
        }



        public DataTable ChercherIngredients()
        {
            string query = "SELECT nom FROM ingredients";

            cnn.Open();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, cnn);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            cnn.Close();

            return dataTable;
        }




        public bool RechercherListeCourse(string nomCourse)
        {
            bool listeExiste = false;

            cnn.Open();

            string query = "SELECT id FROM courses " +
                "WHERE nom = @nomCourse";
            MySqlCommand command = new MySqlCommand(query, cnn);
            command.Parameters.AddWithValue("@nomCourse", nomCourse);
            MySqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                listeExiste = true;
            }

            cnn.Close();
            return listeExiste;
        }



        public DataTable RecupererListeCourse(string nomCourse)
        {
            string query = "SELECT ingredients.nom " +
                "FROM ingredients " +
                "inner join faire_ses_courses on faire_ses_courses.id_ingredient = ingredients.id_ingredient " +
                "inner join courses on courses.id_courses = faire_ses_courses.id_courses " +
                "WHERE faire_ses_courses.date_du_jour = CURDATE() " +
                "AND courses.nom = '" + nomCourse + "';";

            cnn.Open();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, cnn);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            cnn.Close();

            return dataTable;
        }






























        //public void SelectIngredients(DataGridView dgvIngredient)
        //{
        //    string query = "SELECT * FROM ingredients";

        //    this.cnn.Open();
        //    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, this.cnn);
        //    DataTable dataTable = new DataTable();
        //    dataAdapter.Fill(dataTable);

        //    dgvIngredient.DataSource = dataTable;

        //    dgvIngredient.Columns[0].Visible = false;
        //    dgvIngredient.Columns[1].Visible = false;

        //    this.cnn.Close();
        //}




        public void CreateNewListe(string nomCourses)
        {
            if (nomCourses != "")
            {
                DateTime dateDuJour = DateTime.Now;

                cnn.Open();

                string query = "INSERT INTO courses values ('', @nomCourses);";

                MySqlCommand command = new MySqlCommand(query, cnn);

                command.Parameters.AddWithValue("@nomCourses", nomCourses);
                command.ExecuteNonQuery();

                cnn.Close();

                //InsertIntoDateCourses(dateDuJour);
            }
            else
            {
                throw new Exception("Veuillez renseigner un nom de liste");
            }
        }


        public void InsertNewIngredientListeCourses(int idIngredient, int idCourses)
        {

            if (!CheckIfIngredientIsInListeCourses(idIngredient, idCourses))
            {
                DateTime dateDuJour = DateTime.Now;

                InsertIntoFaire(idIngredient, idCourses, dateDuJour);
            }
            else
            {
                MessageBox.Show("Aliment déjà présent");
            }
        }


        public bool CheckIfIngredientIsInListeCourses(int idIngredient, int idCourses)
        {
            bool isPresent = false;

            cnn.Open();

            string query = "SELECT id_ingredients FROM faire_ses_courses " +
                "WHERE id_ingredient = @idIngredient AND id_course = @idCourses";
            MySqlCommand command = new MySqlCommand(query, cnn);
            command.Parameters.AddWithValue("@idIngredient", idIngredient);
            command.Parameters.AddWithValue("@idCourses", idCourses);
            MySqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                isPresent = true;
            }

            cnn.Close();
            return isPresent;
        }


        public void InsertIntoFaire(int idIngredient, int idCourses, DateTime dateDuJour)
        {
            cnn.Open();

            string query = "INSERT INTO faire_ses_courses values (@idIngredient, @idCourses, @dateDuJour);";
            MySqlCommand command = new MySqlCommand(query, cnn);
            command.Parameters.AddWithValue("@idIngredient", idIngredient);
            command.Parameters.AddWithValue("@idCourses", idCourses);
            command.Parameters.AddWithValue("@dateDuJour", dateDuJour);
            command.ExecuteNonQuery();

            cnn.Close();
        }


        public void InsertIntoDateCourses(DateTime dateDuJour)
        {
            cnn.Open();

            string query = "INSERT INTO date_courses values (@dateDuJour);";
            MySqlCommand command = new MySqlCommand(query, cnn);
            command.Parameters.AddWithValue("@dateDuJour", dateDuJour);
            command.ExecuteNonQuery();

            cnn.Close();
        }

        public void DeleteIngredientListeCourses(int idIngredient, int idCourses)
        {
            cnn.Open();

            string query = "DELETE FROM faire_ses_courses WHERE id_ingredient = @idIngredient AND id_courses = @idCourses;";
            MySqlCommand command = new MySqlCommand(query, cnn);
            command.Parameters.AddWithValue("@idIngredient", idIngredient);
            command.Parameters.AddWithValue("@idCourses", idCourses);
            command.ExecuteNonQuery();

            cnn.Close();
        }


        public int SelectIdCoursesByNom(string nomCourse)
        {
            int idCourses = 0;

            cnn.Open();

            string query = "SELECT id_courses FROM courses where nom = @nomCourses;";
            MySqlCommand command = new MySqlCommand(query, cnn);
            command.Parameters.AddWithValue("@nomCourses", nomCourse);
            MySqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                idCourses = reader.GetInt32(0);
            }

            cnn.Close();

            return idCourses;
        }




        public int SelectIdIngredientByNom(string nomIngredient)
        {
            int idIngredient = 0;
            cnn.Open();

            string query = "SELECT id_ingredient FROM ingredients where nom = @nomIngredient;";
            MySqlCommand command = new MySqlCommand(query, cnn);
            command.Parameters.AddWithValue("@nomIngredient", nomIngredient);
            MySqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                idIngredient = reader.GetInt32(0);
            }

            cnn.Close();

            return idIngredient;
        }




        public void SelectIngredientsListeCoursesById(int idCourses, DataGridView dgvListeCourses)
        {
            string query = "SELECT nom FROM ingredients " +
                "inner join faire_ses_courses on ingredients.id_ingredient = faire_ses_courses.id_ingredient " +
                "where faire_ses_courses.id_courses = " + idCourses;

            cnn.Open();

            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, cnn);

            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dgvListeCourses.DataSource = dataTable;

            cnn.Close();
        }























    }
}