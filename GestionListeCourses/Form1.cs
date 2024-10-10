namespace GestionListeCourses
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listeIngredients.Items.Add("Riz");
            listeIngredients.Items.Add("Dinde");
            listeIngredients.Items.Add("Banane");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAjout_Click(object sender, EventArgs e)
        {
            moveIngredient(listeCourses, listeIngredients);
        }

        private void btnRetirer_Click(object sender, EventArgs e)
        {
            moveIngredient(listeIngredients, listeCourses);
        }



        private void moveIngredient(ListBox listBoxAdd, ListBox listBoxRemove)
        {
            if (listBoxRemove.SelectedIndex != -1)
            {
                string ingredient = listBoxRemove.SelectedItem.ToString();

                listBoxAdd.Items.Add(ingredient);
                listBoxRemove.Items.Remove(ingredient);
            }
        }





    }
}


