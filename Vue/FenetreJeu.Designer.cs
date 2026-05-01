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
            this.boutonPret = new System.Windows.Forms.Button();
            this.labelTransition = new System.Windows.Forms.Label();
            this.btnRecommencer = new System.Windows.Forms.Button();
            this.btnSauvegarder = new System.Windows.Forms.Button();
            this.listBoxPieces = new System.Windows.Forms.ListBox();
            this.panelTransition.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(167, 105);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 800);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labelTour
            // 
            this.labelTour.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelTour.BackColor = System.Drawing.Color.Transparent;
            this.labelTour.Font = new System.Drawing.Font("Doctor Glitch", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTour.Location = new System.Drawing.Point(312, 9);
            this.labelTour.Name = "labelTour";
            this.labelTour.Size = new System.Drawing.Size(514, 93);
            this.labelTour.TabIndex = 1;
            this.labelTour.Text = "label1";
            this.labelTour.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelTransition
            // 
            this.panelTransition.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panelTransition.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelTransition.BackgroundImage")));
            this.panelTransition.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelTransition.Controls.Add(this.boutonPret);
            this.panelTransition.Controls.Add(this.labelTransition);
            this.panelTransition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTransition.Location = new System.Drawing.Point(0, 0);
            this.panelTransition.Name = "panelTransition";
            this.panelTransition.Size = new System.Drawing.Size(1280, 1144);
            this.panelTransition.TabIndex = 2;
            this.panelTransition.Visible = false;
            // 
            // boutonPret
            // 
            this.boutonPret.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.boutonPret.Font = new System.Drawing.Font("Orbitron", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boutonPret.Location = new System.Drawing.Point(439, 760);
            this.boutonPret.Name = "boutonPret";
            this.boutonPret.Size = new System.Drawing.Size(369, 145);
            this.boutonPret.TabIndex = 1;
            this.boutonPret.Text = "Je suis prêt !";
            this.boutonPret.UseVisualStyleBackColor = true;
            this.boutonPret.Click += new System.EventHandler(this.boutonPret_Click);
            // 
            // labelTransition
            // 
            this.labelTransition.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelTransition.BackColor = System.Drawing.Color.Transparent;
            this.labelTransition.Font = new System.Drawing.Font("Blacklisted", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTransition.Location = new System.Drawing.Point(346, 168);
            this.labelTransition.Name = "labelTransition";
            this.labelTransition.Size = new System.Drawing.Size(597, 404);
            this.labelTransition.TabIndex = 0;
            this.labelTransition.Text = "label1";
            this.labelTransition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRecommencer
            // 
            this.btnRecommencer.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnRecommencer.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnRecommencer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecommencer.Font = new System.Drawing.Font("Orbitron", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecommencer.Location = new System.Drawing.Point(167, 932);
            this.btnRecommencer.Name = "btnRecommencer";
            this.btnRecommencer.Size = new System.Drawing.Size(316, 77);
            this.btnRecommencer.TabIndex = 3;
            this.btnRecommencer.Text = "Recommencer la partie !";
            this.btnRecommencer.UseVisualStyleBackColor = false;
            this.btnRecommencer.Click += new System.EventHandler(this.btnRecommencer_Click);
            // 
            // btnSauvegarder
            // 
            this.btnSauvegarder.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSauvegarder.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnSauvegarder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSauvegarder.Font = new System.Drawing.Font("Orbitron", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSauvegarder.Location = new System.Drawing.Point(651, 932);
            this.btnSauvegarder.Name = "btnSauvegarder";
            this.btnSauvegarder.Size = new System.Drawing.Size(316, 77);
            this.btnSauvegarder.TabIndex = 4;
            this.btnSauvegarder.Text = "Sauvegarder la partie !";
            this.btnSauvegarder.UseVisualStyleBackColor = false;
            this.btnSauvegarder.Click += new System.EventHandler(this.btnSauvegarder_Click);
            // 
            // listBoxPieces
            // 
            this.listBoxPieces.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.listBoxPieces.FormattingEnabled = true;
            this.listBoxPieces.ItemHeight = 20;
            this.listBoxPieces.Location = new System.Drawing.Point(973, 105);
            this.listBoxPieces.Name = "listBoxPieces";
            this.listBoxPieces.Size = new System.Drawing.Size(273, 804);
            this.listBoxPieces.TabIndex = 5;
            // 
            // FenetreJeu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1280, 1144);
            this.Controls.Add(this.panelTransition);
            this.Controls.Add(this.listBoxPieces);
            this.Controls.Add(this.labelTour);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnRecommencer);
            this.Controls.Add(this.btnSauvegarder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "FenetreJeu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "-";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
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
        private System.Windows.Forms.ListBox listBoxPieces;
    }
}