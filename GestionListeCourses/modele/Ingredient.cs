using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionListeCourses.modele
{
    internal class Ingredient
    {
        private static ConnexionBDD cnn = new ConnexionBDD("server=localhost;Port=3306; database=gestion_courses;uid=root;pwd=\"\";");
        private int idIngredient;
        private string nomIngredient;


        public Ingredient(int idIngredient, string nomIngredient)
        {
            this.idIngredient = idIngredient;
            this.nomIngredient = nomIngredient;
        }





        public static void AfficherListeIngredients(DataGridView dgvIngredient)
        {
            DataTable ingredients = cnn.ChercherIngredients();

            dgvIngredient.DataSource = ingredients;
            dgvIngredient.Columns[0].Visible = true;
        }



        public void miseAJourListeIngredients(DataTable listeCourse)
        {

        }



        public int GetIngredient()
        {
            return idIngredient;
        }
        public void SetIdIngredient(int id)
        {
            idIngredient = id;
        }


        public string GetNomIngredient()
        {
            return nomIngredient;
        }
        public void SetNomIngredient(string nomIngredient)
        {
            this.nomIngredient = nomIngredient;
        }

    }
}
