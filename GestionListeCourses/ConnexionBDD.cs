using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionListeCourses
{
    internal class ConnexionBDD
    {
        private string connectionString;
        private MySqlConnection cnn;

        public ConnexionBDD(String connectionString)
        {
            this.connectionString = connectionString;
            this.cnn = this.GetCnnInstance();
        }


        private MySqlConnection GetCnnInstance()
        {
            if (cnn == null)
            {
                this.cnn = new MySqlConnection(connectionString);
            }

            return this.cnn;
        }


        public void SelectIngredients(DataGridView dgvIngredient)
        {
            string query = "SELECT * FROM ingredients";

            this.cnn.Open();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, this.cnn);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            dgvIngredient.DataSource = dataTable;

            dgvIngredient.Columns[0].Visible = false;
            dgvIngredient.Columns[1].Visible = false;

            this.cnn.Close();
        }




        public void CreateNewListe(String nomCourses)
        {
            if (nomCourses != "")
            {
                DateTime dateDuJour = DateTime.Now;

                this.cnn.Open();

                string query = "INSERT INTO courses values ('', @nomCourses);";

                MySqlCommand command = new MySqlCommand(query, this.cnn);
                
                command.Parameters.AddWithValue("@nomCourses", nomCourses);
                command.ExecuteNonQuery();

                this.cnn.Close();

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

            this.cnn.Open();

            string query = "SELECT id_ingredients FROM faire_ses_courses " +
                "WHERE id_ingredient = @idIngredient AND id_course = @idCourses";
            MySqlCommand command = new MySqlCommand(query, this.cnn);
            command.Parameters.AddWithValue("@idIngredient", idIngredient);
            command.Parameters.AddWithValue("@idCourses", idCourses);
            MySqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                isPresent = true;
            }

            this.cnn.Close();
            return isPresent;
        }


        public void InsertIntoFaire(int idIngredient, int idCourses, DateTime dateDuJour)
        {
            this.cnn.Open();

            string query = "INSERT INTO faire_ses_courses values (@idIngredient, @idCourses, @dateDuJour);";
            MySqlCommand command = new MySqlCommand(query, this.cnn);
            command.Parameters.AddWithValue("@idIngredient", idIngredient);
            command.Parameters.AddWithValue("@idCourses", idCourses);
            command.Parameters.AddWithValue("@dateDuJour", dateDuJour);
            command.ExecuteNonQuery();

            this.cnn.Close();
        }


        public void InsertIntoDateCourses(DateTime dateDuJour)
        {
            this.cnn.Open();

            string query = "INSERT INTO date_courses values (@dateDuJour);";
            MySqlCommand command = new MySqlCommand(query, this.cnn);
            command.Parameters.AddWithValue("@dateDuJour", dateDuJour);
            command.ExecuteNonQuery();

            this.cnn.Close();
        }

        public void DeleteIngredientListeCourses(int idIngredient, int idCourses)
        {
            this.cnn.Open();

            string query = "DELETE FROM faire_ses_courses WHERE id_ingredient = @idIngredient AND id_courses = @idCourses;";
            MySqlCommand command = new MySqlCommand(query, this.cnn);
            command.Parameters.AddWithValue("@idIngredient", idIngredient);
            command.Parameters.AddWithValue("@idCourses", idCourses);
            command.ExecuteNonQuery();

            this.cnn.Close();
        }


        public int SelectIdCoursesByNom(String nomCourse)
        {
            int idCourses = 0;

            this.cnn.Open();

            string query = "SELECT id_courses FROM courses where nom = @nomCourses;";
            MySqlCommand command = new MySqlCommand(query, this.cnn);
            command.Parameters.AddWithValue("@nomCourses", nomCourse);
            MySqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                idCourses = reader.GetInt32(0);
            }
                
            this.cnn.Close();

            return idCourses;
        }




        public int SelectIdIngredientByNom(String nomIngredient)
        {
            int idIngredient = 0;
            this.cnn.Open();

            string query = "SELECT id_ingredient FROM ingredients where nom = @nomIngredient;";
            MySqlCommand command = new MySqlCommand(query, this.cnn);
            command.Parameters.AddWithValue("@nomIngredient", nomIngredient);
            MySqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                idIngredient = reader.GetInt32(0);
            }

            this.cnn.Close();

            return idIngredient;
        }




        public void SelectIngredientsListeCoursesById(int idCourses, DataGridView dgvListeCourses)
        {
            string query = "SELECT nom FROM ingredients " +
                "inner join faire_ses_courses on ingredients.id_ingredient = faire_ses_courses.id_ingredient " +
                "where faire_ses_courses.id_courses = " + idCourses;

            this.cnn.Open();

            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, this.cnn);

            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dgvListeCourses.DataSource = dataTable;

            this.cnn.Close();
        }




        


















    }
}