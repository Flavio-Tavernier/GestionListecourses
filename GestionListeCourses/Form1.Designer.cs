namespace GestionListeCourses
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listeIngredients = new ListBox();
            listeCourses = new ListBox();
            labelListeIngredients = new Label();
            labelListeCourses = new Label();
            btnAjout = new Button();
            btnRetirer = new Button();
            SuspendLayout();
            // 
            // listeIngredients
            // 
            listeIngredients.FormattingEnabled = true;
            listeIngredients.ItemHeight = 15;
            listeIngredients.Location = new Point(81, 113);
            listeIngredients.Name = "listeIngredients";
            listeIngredients.Size = new Size(164, 214);
            listeIngredients.TabIndex = 0;
            listeIngredients.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // listeCourses
            // 
            listeCourses.FormattingEnabled = true;
            listeCourses.ItemHeight = 15;
            listeCourses.Location = new Point(543, 113);
            listeCourses.Name = "listeCourses";
            listeCourses.Size = new Size(164, 214);
            listeCourses.TabIndex = 1;
            // 
            // labelListeIngredients
            // 
            labelListeIngredients.AutoSize = true;
            labelListeIngredients.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            labelListeIngredients.Location = new Point(81, 70);
            labelListeIngredients.Name = "labelListeIngredients";
            labelListeIngredients.Size = new Size(210, 30);
            labelListeIngredients.TabIndex = 2;
            labelListeIngredients.Text = "Liste des ingrédients";
            labelListeIngredients.Click += label1_Click;
            // 
            // labelListeCourses
            // 
            labelListeCourses.AutoSize = true;
            labelListeCourses.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            labelListeCourses.Location = new Point(543, 70);
            labelListeCourses.Name = "labelListeCourses";
            labelListeCourses.Size = new Size(166, 30);
            labelListeCourses.TabIndex = 3;
            labelListeCourses.Text = "Liste de courses";
            labelListeCourses.Click += label2_Click;
            // 
            // btnAjout
            // 
            btnAjout.Location = new Point(325, 157);
            btnAjout.Name = "btnAjout";
            btnAjout.Size = new Size(128, 53);
            btnAjout.TabIndex = 4;
            btnAjout.Text = "----- >";
            btnAjout.UseVisualStyleBackColor = true;
            btnAjout.Click += btnAjout_Click;
            // 
            // btnRetirer
            // 
            btnRetirer.Location = new Point(325, 243);
            btnRetirer.Name = "btnRetirer";
            btnRetirer.Size = new Size(128, 53);
            btnRetirer.TabIndex = 5;
            btnRetirer.Text = "< -----";
            btnRetirer.UseVisualStyleBackColor = true;
            btnRetirer.Click += btnRetirer_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnRetirer);
            Controls.Add(btnAjout);
            Controls.Add(labelListeCourses);
            Controls.Add(labelListeIngredients);
            Controls.Add(listeCourses);
            Controls.Add(listeIngredients);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listeIngredients;
        private ListBox listeCourses;
        private Label labelListeIngredients;
        private Label labelListeCourses;
        private Button btnAjout;
        private Button btnRetirer;
    }
}