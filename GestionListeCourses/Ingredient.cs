using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionListeCourses
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







        public int GetIngredient() 
        {  
            return this.idIngredient;
        }
        public void SetIdIngredient(int id)
        {
            this.idIngredient = id;
        }


        public string GetNomIngredient()
        {
            return this.nomIngredient;
        }
        public void SetNomIngredient(string nomIngredient)
        {
            this.nomIngredient = nomIngredient;
        }

    }
}
