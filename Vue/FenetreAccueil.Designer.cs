namespace Stratego_TT_25_26
{
    partial class FenetreAccueil
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FenetreAccueil));
            this.bNouvellePartie = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxManuel = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // bNouvellePartie
            // 
            this.bNouvellePartie.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bNouvellePartie.BackColor = System.Drawing.Color.Maroon;
            this.bNouvellePartie.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.bNouvellePartie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bNouvellePartie.Font = new System.Drawing.Font("Orbitron", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bNouvellePartie.ForeColor = System.Drawing.Color.Gold;
            this.bNouvellePartie.Location = new System.Drawing.Point(459, 276);
            this.bNouvellePartie.Name = "bNouvellePartie";
            this.bNouvellePartie.Size = new System.Drawing.Size(258, 136);
            this.bNouvellePartie.TabIndex = 0;
            this.bNouvellePartie.Text = "Nouvelle partie";
            this.bNouvellePartie.UseVisualStyleBackColor = false;
            this.bNouvellePartie.Click += new System.EventHandler(this.bNouvellePartie_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Orbitron", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Gold;
            this.button1.Location = new System.Drawing.Point(459, 456);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(258, 136);
            this.button1.TabIndex = 1;
            this.button1.Text = "Charger une partie";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Blacklisted", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(342, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(506, 133);
            this.label1.TabIndex = 2;
            this.label1.Text = "Stratego ";
            // 
            // checkBoxManuel
            // 
            this.checkBoxManuel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBoxManuel.AutoSize = true;
            this.checkBoxManuel.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxManuel.Font = new System.Drawing.Font("Doctor Glitch", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxManuel.ForeColor = System.Drawing.SystemColors.Window;
            this.checkBoxManuel.Location = new System.Drawing.Point(346, 241);
            this.checkBoxManuel.Name = "checkBoxManuel";
            this.checkBoxManuel.Size = new System.Drawing.Size(502, 29);
            this.checkBoxManuel.TabIndex = 3;
            this.checkBoxManuel.Text = "Placement manuel des troupes";
            this.checkBoxManuel.UseVisualStyleBackColor = false;
            // 
            // FenetreAccueil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1220, 765);
            this.Controls.Add(this.checkBoxManuel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bNouvellePartie);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FenetreAccueil";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stratego -- Accueil";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bNouvellePartie;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxManuel;
    }
}

