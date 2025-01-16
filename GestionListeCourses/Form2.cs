using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestionListeCourses.modele;
using MySql.Data.MySqlClient;
namespace GestionListeCourses
{
    public partial class Form2 : Form
    {
        private ConnexionBDD cnn = new ConnexionBDD("server=localhost;Port=3306; database=gestion_courses;uid=root;pwd=\"\";");
        public Form2()
        {
            InitializeComponent();

            Ingredient.AfficherListeIngredients(dgvIngredient);



        }

        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Form2));
            dgvIngredient = new DataGridView();
            dgvListeCourses = new DataGridView();
            btnAjout = new Button();
            btnSupprimer = new Button();
            labelngredients = new Label();
            labelListeDeCourses = new Label();
            textBoxNomCourses = new TextBox();
            labelInputNomListeCourses = new Label();
            labelListeCoursesInconnue = new Label();
            btnRecherche = new Button();
            this.btnSupprIngredientsListecourses = new Button();
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
            btnAjout.BackgroundImage = (Image)resources.GetObject("btnAjout.BackgroundImage");
            btnAjout.Location = new Point(392, 218);
            btnAjout.Name = "btnAjout";
            btnAjout.Size = new Size(75, 23);
            btnAjout.TabIndex = 2;
            btnAjout.UseVisualStyleBackColor = true;
            btnAjout.Click += btnAjout_Click;
            // 
            // btnSupprimer
            // 
            btnSupprimer.BackgroundImage = (Image)resources.GetObject("btnSupprimer.BackgroundImage");
            btnSupprimer.Location = new Point(392, 317);
            btnSupprimer.Name = "btnSupprimer";
            btnSupprimer.Size = new Size(75, 23);
            btnSupprimer.TabIndex = 3;
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
            // btnRecherche
            // 
            btnRecherche.BackgroundImage = (Image)resources.GetObject("btnRecherche.BackgroundImage");
            btnRecherche.Location = new Point(735, 107);
            btnRecherche.Name = "btnRecherche";
            btnRecherche.Size = new Size(75, 23);
            btnRecherche.TabIndex = 9;
            btnRecherche.UseVisualStyleBackColor = true;
            btnRecherche.Click += btnRecherche_Click;
            // 
            // btnSupprIngredientsListecourses
            // 
            this.btnSupprIngredientsListecourses.BackgroundImage = (Image)resources.GetObject("btnSupprIngredientsListecourses.BackgroundImage");
            this.btnSupprIngredientsListecourses.Location = new Point(404, 133);
            this.btnSupprIngredientsListecourses.Name = "btnSupprIngredientsListecourses";
            this.btnSupprIngredientsListecourses.Size = new Size(50, 53);
            this.btnSupprIngredientsListecourses.TabIndex = 10;
            this.btnSupprIngredientsListecourses.UseVisualStyleBackColor = true;
            this.btnSupprIngredientsListecourses.Click += this.btnSupprIngredientsListecourses_Click;
            // 
            // Form2
            // 
            ClientSize = new Size(860, 512);
            Controls.Add(this.btnSupprIngredientsListecourses);
            Controls.Add(btnRecherche);
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

            if (this.GetIsListeInconnue(nomCourse))
            {
                try
                {
                    cnn.CreateNewListe(nomCourse);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                labelListeCoursesInconnue.Text = "";
            }


            int idCourses = cnn.SelectIdCoursesByNom(nomCourse);
            int idIngredient = cnn.SelectIdIngredientByNom(nomIngredient);

            cnn.InsertNewIngredientListeCourses(idIngredient, idCourses);
            cnn.SelectIngredientsListeCoursesById(idCourses, dgvListeCourses);
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

        private void textBoxNomCourses_TextChanged(object sender, EventArgs e)
        {
            //String nomCourse = textBoxNomCourses.Text;

            //Boolean isListeInconnue = GetIsListeInconnue(nomCourse);

            //if (isListeInconnue)
            //{
            //    labelListeCoursesInconnue.Text = "Liste Inconnue";
            //    dgvListeCourses.DataSource = "";
            //}
            //else
            //{
            //    labelListeCoursesInconnue.Text = "";
            //    int idCourses = cnn.SelectIdCoursesByNom(nomCourse);
            //    cnn.SelectIngredientsListeCoursesById(idCourses, dgvListeCourses);
            //}
        }

        private Boolean GetIsListeInconnue(String nomCourse)
        {
            return cnn.SelectIdCoursesByNom(nomCourse) == 0;
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            String nomCourse = textBoxNomCourses.Text;
            String nomIngredient = GetNomSelectedIngredient(dgvListeCourses);

            int idCourses = cnn.SelectIdCoursesByNom(nomCourse);
            int idIngredient = cnn.SelectIdIngredientByNom(nomIngredient);

            cnn.DeleteIngredientListeCourses(idIngredient, idCourses);
            cnn.SelectIngredientsListeCoursesById(idCourses, dgvListeCourses);
        }

        private void btnRecherche_Click(object sender, EventArgs e)
        {
            String nomCourse = textBoxNomCourses.Text;

            Course.AfficherListeCourse(nomCourse, dgvListeCourses);
        }

        private void btnSupprIngredientsListecourses_Click(object sender, EventArgs e)
        {
            String nomCourse = textBoxNomCourses.Text;
            int idCourses = cnn.SelectIdCoursesByNom(nomCourse);

            cnn.DeleteIngredientsListeCourses(idCourses);
            Course.AfficherListeCourse(nomCourse, dgvListeCourses);
        }
    }
}