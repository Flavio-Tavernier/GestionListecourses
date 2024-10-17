using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace GestionListeCourses
{
    public partial class Form2 : Form
    {
        string connectioString;
        MySqlConnection cnn;
        public Form2()
        {
            InitializeComponent();
            

            try
            {
                string connectionString = "server=localhost;Port=3306; database=gestion_courses;uid=root;pwd=\"\";";
                MySqlConnection cnn = new MySqlConnection(connectionString);

                string query = "SELECT * FROM ingredients";

                cnn.Open();

                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, cnn);

                DataTable dataTable = new DataTable();

                dataAdapter.Fill(dataTable);

                dgvIngredient.DataSource = dataTable;

                dgvIngredient.Columns[0].Visible = false;
                dgvIngredient.Columns[1].Visible = false;

                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't open connection !" + ex);
            }

        }

        private void InitializeComponent()
        {
            dgvIngredient = new DataGridView();
            dgvListeCourses = new DataGridView();
            btnAjout = new Button();
            btnSupprimer = new Button();
            labelngredients = new Label();
            labelListeDeCourses = new Label();
            textBoxNomCourses = new TextBox();
            labelInputNomListeCourses = new Label();
            labelListeCoursesInconnue = new Label();
            ((ISupportInitialize)dgvIngredient).BeginInit();
            ((ISupportInitialize)dgvListeCourses).BeginInit();
            SuspendLayout();
            // 
            // dgvIngredient
            // 
            dgvIngredient.AllowUserToAddRows = false;
            dgvIngredient.AllowUserToDeleteRows = false;
            dgvIngredient.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvIngredient.Location = new Point(43, 133);
            dgvIngredient.Name = "dgvIngredient";
            dgvIngredient.ReadOnly = true;
            dgvIngredient.RowTemplate.Height = 25;
            dgvIngredient.Size = new Size(285, 314);
            dgvIngredient.TabIndex = 0;
            // 
            // dgvListeCourses
            // 
            dgvListeCourses.AllowUserToAddRows = false;
            dgvListeCourses.AllowUserToDeleteRows = false;
            dgvListeCourses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvListeCourses.Location = new Point(525, 133);
            dgvListeCourses.Name = "dgvListeCourses";
            dgvListeCourses.ReadOnly = true;
            dgvListeCourses.RowTemplate.Height = 25;
            dgvListeCourses.Size = new Size(285, 314);
            dgvListeCourses.TabIndex = 1;
            // 
            // btnAjout
            // 
            btnAjout.Location = new Point(392, 218);
            btnAjout.Name = "btnAjout";
            btnAjout.Size = new Size(75, 23);
            btnAjout.TabIndex = 2;
            btnAjout.Text = "----->";
            btnAjout.UseVisualStyleBackColor = true;
            btnAjout.Click += btnAjout_Click;
            // 
            // btnSupprimer
            // 
            btnSupprimer.Location = new Point(392, 317);
            btnSupprimer.Name = "btnSupprimer";
            btnSupprimer.Size = new Size(75, 23);
            btnSupprimer.TabIndex = 3;
            btnSupprimer.Text = "<-----";
            btnSupprimer.UseVisualStyleBackColor = true;
            btnSupprimer.Click += btnSupprimer_Click;
            // 
            // labelngredients
            // 
            labelngredients.AutoSize = true;
            labelngredients.Location = new Point(43, 99);
            labelngredients.Name = "labelngredients";
            labelngredients.Size = new Size(114, 15);
            labelngredients.TabIndex = 4;
            labelngredients.Text = "Liste des ingrédients";
            // 
            // labelListeDeCourses
            // 
            labelListeDeCourses.AutoSize = true;
            labelListeDeCourses.Location = new Point(525, 80);
            labelListeDeCourses.Name = "labelListeDeCourses";
            labelListeDeCourses.Size = new Size(90, 15);
            labelListeDeCourses.TabIndex = 5;
            labelListeDeCourses.Text = "Liste de courses";
            labelListeDeCourses.Click += label1_Click;
            // 
            // textBoxNomCourses
            // 
            textBoxNomCourses.Location = new Point(571, 104);
            textBoxNomCourses.Name = "textBoxNomCourses";
            textBoxNomCourses.Size = new Size(100, 23);
            textBoxNomCourses.TabIndex = 6;
            textBoxNomCourses.TextChanged += textBoxNomCourses_TextChanged;
            // 
            // labelInputNomListeCourses
            // 
            labelInputNomListeCourses.AutoSize = true;
            labelInputNomListeCourses.Location = new Point(525, 107);
            labelInputNomListeCourses.Name = "labelInputNomListeCourses";
            labelInputNomListeCourses.Size = new Size(40, 15);
            labelInputNomListeCourses.TabIndex = 7;
            labelInputNomListeCourses.Text = "Nom :";
            // 
            // labelListeCoursesInconnue
            // 
            labelListeCoursesInconnue.AutoSize = true;
            labelListeCoursesInconnue.Location = new Point(688, 107);
            labelListeCoursesInconnue.Name = "labelListeCoursesInconnue";
            labelListeCoursesInconnue.Size = new Size(0, 15);
            labelListeCoursesInconnue.TabIndex = 8;
            // 
            // Form2
            // 
            ClientSize = new Size(860, 512);
            Controls.Add(labelListeCoursesInconnue);
            Controls.Add(labelInputNomListeCourses);
            Controls.Add(textBoxNomCourses);
            Controls.Add(labelListeDeCourses);
            Controls.Add(labelngredients);
            Controls.Add(btnSupprimer);
            Controls.Add(btnAjout);
            Controls.Add(dgvListeCourses);
            Controls.Add(dgvIngredient);
            Name = "Form2";
            ((ISupportInitialize)dgvIngredient).EndInit();
            ((ISupportInitialize)dgvListeCourses).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAjout_Click(object sender, EventArgs e)
        {
            String nomCourse = textBoxNomCourses.Text;
            String nomIngredient = GetNomSelectedIngredient(dgvIngredient);

            if (getIsListeInconnue(nomCourse))
            {
                try
                {
                    createNewListe(nomCourse);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
                labelListeCoursesInconnue.Text = "";
            }

            if (!getIsListeInconnue(nomCourse))
            {
                int idCourses = getIdCourses(nomCourse);
                int idIngredient = getIdIngredient(nomIngredient);

                insertNewIngredientListeCourse(idIngredient, idCourses);
                displayIngredientsListeCourses(idCourses);
            } 
        }


        private void createNewListe(String nomCourse)
        {
            if (nomCourse != "")
            {
                MySqlConnection cnn = getCnn();
                DateTime dateDuJour = DateTime.Now;

                cnn.Open();

                string query = "INSERT INTO course values ('', @nomCourse);";
                MySqlCommand command = new MySqlCommand(query, cnn);
                command.Parameters.AddWithValue("@nomCourse", nomCourse);
                int rowsAffected = command.ExecuteNonQuery();

                cnn.Close();

                //insertIntoDateCourses(cnn, dateDuJour);
            }
            else
            {
                throw new Exception("Veuillez renseigner un nom de liste");
            }
        }


        private void insertNewIngredientListeCourse(int idIngredient, int idCourses)
        {

            if (!checkIfIngredientIsInListeCourses(idIngredient, idCourses))
            {
                MySqlConnection cnn = getCnn();
                DateTime dateDuJour = DateTime.Now;

                insertIntoFaire(cnn, idIngredient, idCourses, dateDuJour);
            } else
            {
                MessageBox.Show("Aliment déjà présent");
            }
        }

        private void insertIntoFaire(MySqlConnection cnn, int idIngredient, int idCourses, DateTime dateDuJour)
        {
            cnn.Open();

            string query = "INSERT INTO faire values (@idIngredient, @idCourses, @dateDuJour);";
            MySqlCommand command = new MySqlCommand(query, cnn);
            command.Parameters.AddWithValue("@idIngredient", idIngredient);
            command.Parameters.AddWithValue("@idCourses", idCourses);
            command.Parameters.AddWithValue("@dateDuJour", dateDuJour);
            int rowsAffected = command.ExecuteNonQuery();

            cnn.Close();
        }

        private void insertIntoDateCourses(MySqlConnection cnn, DateTime dateDuJour)
        {
            cnn.Open();

            string query = "INSERT INTO date_courses values (@dateDuJour);";
            MySqlCommand command = new MySqlCommand(query, cnn);
            command.Parameters.AddWithValue("@dateDuJour", dateDuJour);
            int rowsAffected = command.ExecuteNonQuery();

            cnn.Close();
        }

        private bool checkIfIngredientIsInListeCourses(int idIngredient, int idCourses)
        {
            MySqlConnection cnn = getCnn();
            bool isPresent = false;

            cnn.Open();


            string query = "SELECT id_ingredients FROM faire " +
                "WHERE id_ingredients = @idIngredient AND id_course = @idCourses";
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

        private void deleteIngredientListeCourse(int idIngredient, int idCourses)
        {
            MySqlConnection cnn = getCnn();

            cnn.Open();

            string query = "DELETE FROM faire WHERE id_ingredients = @idIngredient AND id_course = @idCourses;";
            MySqlCommand command = new MySqlCommand(query, cnn);
            command.Parameters.AddWithValue("@idIngredient", idIngredient);
            command.Parameters.AddWithValue("@idCourses", idCourses);
            int rowsAffected = command.ExecuteNonQuery();

            cnn.Close();

        }


        private static String GetNomSelectedIngredient(DataGridView dgv)
        {
            if (dgv.CurrentCell == null)
            {
                return null;
            }
            
            int rowIndex = dgv.CurrentCell.RowIndex;
            int columnIndex = dgv.CurrentCell.ColumnIndex;
            return dgv.Rows[rowIndex].Cells[columnIndex].Value.ToString();

        }


        private int getIdCourses(String nomCourse)
        {
            MySqlConnection cnn = getCnn();

            cnn.Open();

            string query = "SELECT id FROM course where nom = @nomCourses;";
            MySqlCommand command = new MySqlCommand(query, cnn);
            command.Parameters.AddWithValue("@nomCourses", nomCourse);
            MySqlDataReader reader = command.ExecuteReader();

            reader.Read();
            int idCourses = reader.GetInt32(0);

            cnn.Close();

            return idCourses;
        }




        private int getIdIngredient(String nomIngredient)
        {
            MySqlConnection cnn = getCnn();

            cnn.Open();

            string query = "SELECT id FROM ingredients where nom = @nomIngredient;";
            MySqlCommand command = new MySqlCommand(query, cnn);
            command.Parameters.AddWithValue("@nomIngredient", nomIngredient);
            MySqlDataReader reader = command.ExecuteReader();

            reader.Read();
            int idIngredient = reader.GetInt32(0);

            cnn.Close();

            return idIngredient;
        }


        private void displayIngredientsListeCourses(int idCourses)
        {
            MySqlConnection cnn = getCnn();

            string query = "SELECT nom FROM ingredients " +
                "inner join faire on ingredients.id = faire.id_ingredients " +
                "where faire.id_course = " + idCourses;

            cnn.Open();

            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, cnn);

            DataTable dataTable = new DataTable();

            dataAdapter.Fill(dataTable);

            dgvListeCourses.DataSource = dataTable;

            cnn.Close();
        }



        private MySqlConnection getCnn()
        {
            string connectionString = "server=localhost;Port=3306; database=gestion_courses;uid=root;pwd=\"\";";
            return new MySqlConnection(connectionString);
        }

        private void textBoxNomCourses_TextChanged(object sender, EventArgs e)
        {
            String nomCourse = textBoxNomCourses.Text;

            Boolean isListeInconnue = getIsListeInconnue(nomCourse);

            if (isListeInconnue)
            {
                labelListeCoursesInconnue.Text = "Liste Inconnue";
                dgvListeCourses.DataSource = "";
            }
            else
            {
                labelListeCoursesInconnue.Text = "";
                int idCourses = getIdCourses(nomCourse);
                displayIngredientsListeCourses(idCourses);

            }
        }



        private Boolean getIsListeInconnue(String nomCourse)
        {
            MySqlConnection cnn = getCnn();

            cnn.Open();

            string query = "SELECT id FROM course where nom = @nomCourses;";
            MySqlCommand command = new MySqlCommand(query, cnn);
            command.Parameters.AddWithValue("@nomCourses", nomCourse);
            MySqlDataReader reader = command.ExecuteReader();

            Boolean isListeInconnue = true;

            if (reader.Read())
            {
                isListeInconnue = reader.IsDBNull(0);
            }



            cnn.Close();

            return isListeInconnue;
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            String nomCourse = textBoxNomCourses.Text;
            String nomIngredient = GetNomSelectedIngredient(dgvListeCourses);

            int idCourses = getIdCourses(nomCourse);
            int idIngredient = getIdIngredient(nomIngredient);

            deleteIngredientListeCourse(idIngredient, idCourses);
            displayIngredientsListeCourses(idCourses);
        }
    }
}