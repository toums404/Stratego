using Stratego_TT_25_26.Modele;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stratego_TT_25_26.Vue
{
    public partial class FenetreJeu : Form
    {
        private Manager jeu;
        private Button[,] boutonsGrille;
        private Point? caseSelectionnee = null;//? pour permettre null et Point
        public FenetreJeu(string cheminSauvegarde = "")
        {
            InitializeComponent();
            jeu = new Manager();
            if (!string.IsNullOrEmpty(cheminSauvegarde) && System.IO.File.Exists(cheminSauvegarde))
            {
                jeu.ChargerPartie(cheminSauvegarde);
            }
            else
            {
                jeu.InitialiserPartieAleatoire();
            }

            boutonsGrille = new Button[Plateau.TAILLE, Plateau.TAILLE];
            GenererBoutons();
            MajAffichage();
        }
        private void BoutonGrille_Click(object sender, EventArgs e)
        {
            Button btnClick = sender as Button;
            
            Point coordonnes = (Point)btnClick.Tag;
            int xClick = coordonnes.X;
            int yClick = coordonnes.Y;

            if(caseSelectionnee == null)
            {
                Piece piece = jeu.LePlateau.ObtenirPiece(xClick, yClick);
                if (piece != null && piece.EquipePiece == jeu.JoueurCourant && piece.PeutBouger())
                {
                    caseSelectionnee = coordonnes;
                    MajAffichage();

                    btnClick.FlatAppearance.BorderSize = 4;
                    btnClick.FlatAppearance.BorderColor = Color.Yellow;
                }
            }
            else
            {
                int xDepart = caseSelectionnee.Value.X;
                int yDepart = caseSelectionnee.Value.Y;

                if(xDepart == xClick && yDepart == yClick)
                {
                    caseSelectionnee = null;
                    MajAffichage();
                    return;
                }
                bool deplacementReussi = jeu.DeplacerPiece(xDepart, yDepart, xClick, yClick);

                caseSelectionnee = null;
                MajAffichage();
                if (deplacementReussi && jeu.EtatActuel != EtatJeu.Termine)
                {
                    if (jeu.JoueurCourant == Equipe.Rouge)
                    {
                        labelTransition.Text = "C'est au tour du joueur ROUGE !";
                        labelTransition.ForeColor = Color.Tomato;
                    }
                    else
                    {
                        labelTransition.Text = "C'est au tour du joueur BLEU !";
                        labelTransition.ForeColor = Color.CornflowerBlue;
                    }

                    panelTransition.Visible = true;
                    panelTransition.BringToFront();
                }

                MajAffichage();

                if (jeu.EtatActuel == EtatJeu.Termine)
                {
                    MessageBox.Show($"Fin de la partie ! L'équipe {jeu.Vainqueur} a gagné !", "Victoire");
                    this.Close();
                }
            }
        }
        
        private void GenererBoutons()
        {
            //----
            //config du tableLayoutPanel pour forcer les affichages correct
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.ColumnStyles.Clear();
            tableLayoutPanel1.RowStyles.Clear();
            tableLayoutPanel1.ColumnCount = Plateau.TAILLE;
            tableLayoutPanel1.RowCount = Plateau.TAILLE;
            for (int i = 0; i < Plateau.TAILLE; i++)
            {
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / Plateau.TAILLE));
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / Plateau.TAILLE));
            }
            //----

            for (int y = 0; y < Plateau.TAILLE; y++)
            {
                for (int x = 0; x < Plateau.TAILLE; x++)
                {
                    Button btn = new Button();
                    btn.Dock = DockStyle.Fill;
                    btn.Margin = new Padding(1);
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Click += BoutonGrille_Click;

                    btn.Tag = new Point(x, y);
                    boutonsGrille[x,y] = btn;

                    tableLayoutPanel1.Controls.Add(btn, x, y);
                }
            }
        }
        private void MajAffichage()
        {
            if (jeu.JoueurCourant == Equipe.Rouge)
            {
                labelTour.Text = "Tour du joueur : ROUGE";
                labelTour.ForeColor = Color.Tomato;
            }
            else
            {
                labelTour.Text = "Tour du joueur : BLEU";
                labelTour.ForeColor = Color.CornflowerBlue;
            }
            for (int y = 0; y < Plateau.TAILLE; y++)
            {
                for (int x = 0; x < Plateau.TAILLE; x++)
                {
                    Piece p = jeu.LePlateau.ObtenirPiece(x, y);
                    Button button = boutonsGrille[x, y];
                    button.FlatAppearance.BorderSize = 0;

                    if (p == null)
                    {
                        button.BackColor = Color.LightGray;
                        button.Text = "";
                    }
                    else
                    {
                        if (p.EquipePiece == Equipe.Rouge)
                        {
                            button.BackColor = Color.Tomato;
                        }
                        else
                        {
                            button.BackColor = Color.CornflowerBlue;
                        }
                        if(p.EquipePiece == jeu.JoueurCourant || p.EstDecouverte)
                        {
                            button.Text = p.GradePiece.ToString();
                        }
                        else
                        {
                            button.Text = "?";
                        }
                        button.Font = new Font("Segoe UI", 8, FontStyle.Bold);
                        button.ForeColor = Color.White;
                    }
                }
            }
        }

        private void boutonPret_Click(object sender, EventArgs e)
        {
            panelTransition.Visible = false;
        }

        private void btnRecommencer_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Voulez-vous vraiment quitter la partie en cours ?",
                                          "Recommencer",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Form accueil = Application.OpenForms["FenetreAccueil"];

                if (accueil != null)
                {
                    accueil.Show();
                }

                this.Close();
            }
        }

        private void FenetreJeu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form accueil = Application.OpenForms["FenetreAccueil"];
            if (accueil != null && !accueil.Visible)
            {
                Application.Exit();
            }
        }

        private void btnSauvegarder_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Fichier de sauvegarde Stratego (*.json)|*.json"; // On force le format .json
            sfd.Title = "Sauvegarder votre partie";
            sfd.FileName = "MaPartie.json"; // Nom par défaut

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                jeu.SauvegarderPartie(sfd.FileName);
                MessageBox.Show("La partie a été sauvegardée avec succès !", "Sauvegarde", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            ;
        }
    }
}
