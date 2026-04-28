namespace Stratego_TT_25_26.Vue
{
    partial class FenetreJeu
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FenetreJeu));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelTour = new System.Windows.Forms.Label();
            this.panelTransition = new System.Windows.Forms.Panel();
            this.labelTransition = new System.Windows.Forms.Label();
            this.boutonPret = new System.Windows.Forms.Button();
            this.btnRecommencer = new System.Windows.Forms.Button();
            this.btnSauvegarder = new System.Windows.Forms.Button();
            this.panelTransition.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(70, 121);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(833, 663);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labelTour
            // 
            this.labelTour.Location = new System.Drawing.Point(225, 9);
            this.labelTour.Name = "labelTour";
            this.labelTour.Size = new System.Drawing.Size(514, 93);
            this.labelTour.TabIndex = 1;
            this.labelTour.Text = "label1";
            this.labelTour.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelTransition
            // 
            this.panelTransition.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panelTransition.Controls.Add(this.boutonPret);
            this.panelTransition.Controls.Add(this.labelTransition);
            this.panelTransition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTransition.Location = new System.Drawing.Point(0, 0);
            this.panelTransition.Name = "panelTransition";
            this.panelTransition.Size = new System.Drawing.Size(978, 1144);
            this.panelTransition.TabIndex = 2;
            this.panelTransition.Visible = false;
            // 
            // labelTransition
            // 
            this.labelTransition.Location = new System.Drawing.Point(200, 162);
            this.labelTransition.Name = "labelTransition";
            this.labelTransition.Size = new System.Drawing.Size(597, 404);
            this.labelTransition.TabIndex = 0;
            this.labelTransition.Text = "label1";
            this.labelTransition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // boutonPret
            // 
            this.boutonPret.Location = new System.Drawing.Point(319, 596);
            this.boutonPret.Name = "boutonPret";
            this.boutonPret.Size = new System.Drawing.Size(369, 145);
            this.boutonPret.TabIndex = 1;
            this.boutonPret.Text = "Je suis prêt !";
            this.boutonPret.UseVisualStyleBackColor = true;
            this.boutonPret.Click += new System.EventHandler(this.boutonPret_Click);
            // 
            // btnRecommencer
            // 
            this.btnRecommencer.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnRecommencer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecommencer.Font = new System.Drawing.Font("Orbitron", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecommencer.Location = new System.Drawing.Point(167, 807);
            this.btnRecommencer.Name = "btnRecommencer";
            this.btnRecommencer.Size = new System.Drawing.Size(316, 77);
            this.btnRecommencer.TabIndex = 3;
            this.btnRecommencer.Text = "Recommencer la partie !";
            this.btnRecommencer.UseVisualStyleBackColor = false;
            this.btnRecommencer.Click += new System.EventHandler(this.btnRecommencer_Click);
            // 
            // btnSauvegarder
            // 
            this.btnSauvegarder.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnSauvegarder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSauvegarder.Font = new System.Drawing.Font("Orbitron", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSauvegarder.Location = new System.Drawing.Point(489, 807);
            this.btnSauvegarder.Name = "btnSauvegarder";
            this.btnSauvegarder.Size = new System.Drawing.Size(316, 77);
            this.btnSauvegarder.TabIndex = 4;
            this.btnSauvegarder.Text = "Sauvegarder la partie !";
            this.btnSauvegarder.UseVisualStyleBackColor = false;
            this.btnSauvegarder.Click += new System.EventHandler(this.btnSauvegarder_Click);
            // 
            // FenetreJeu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(978, 1144);
            this.Controls.Add(this.panelTransition);
            this.Controls.Add(this.labelTour);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnRecommencer);
            this.Controls.Add(this.btnSauvegarder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FenetreJeu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Partie";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FenetreJeu_FormClosed);
            this.panelTransition.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelTour;
        private System.Windows.Forms.Panel panelTransition;
        private System.Windows.Forms.Button boutonPret;
        private System.Windows.Forms.Label labelTransition;
        private System.Windows.Forms.Button btnRecommencer;
        private System.Windows.Forms.Button btnSauvegarder;
    }
}