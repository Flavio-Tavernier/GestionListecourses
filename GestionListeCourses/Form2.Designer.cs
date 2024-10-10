
namespace GestionListeCourses
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private DataGridView dgvIngredient;
        private DataGridView dgvListeCourses;
        private Button btnAjout;
        private Button btnSupprimer;
        private Label labelngredients;
        private Label labelListeDeCourses;
        private TextBox textBoxNomCourses;
        private Label labelInputNomListeCourses;
        private Label labelListeCoursesInconnue;
    }
}