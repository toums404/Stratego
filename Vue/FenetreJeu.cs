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
        public FenetreJeu(string cheminSauvegarde = "", bool placementManuel = false)
        {
            InitializeComponent();
            jeu = new Manager();
            if (!string.IsNullOrEmpty(cheminSauvegarde) && System.IO.File.Exists(cheminSauvegarde))
            {
                jeu.ChargerPartie(cheminSauvegarde);
            }
            else if (placementManuel)
            {
                jeu.InitialiserPartieManuelle();
            }
            else
            {
                jeu.InitialiserPartieAleatoire();
            }

            boutonsGrille = new Button[Plateau.TAILLE, Plateau.TAILLE];
            GenererBoutons();
            MajAffichage();
            MajInventaire();
        }
        private void BoutonGrille_Click(object sender, EventArgs e)
        {
            Button btnClick = sender as Button;
            
            Point coordonnes = (Point)btnClick.Tag;
            int xClick = coordonnes.X;
            int yClick = coordonnes.Y;

            if(jeu.EtatActuel == EtatJeu.Placement)
            {
                if (listBoxPieces.SelectedIndex != -1)
                {
                    Grade gradeChoisi = (Grade)listBoxPieces.SelectedItem;

                    Piece pieceAPlacer = null;
                    foreach (Piece p in jeu.PiecesEnAttente)
                    {
                        if (p.GradePiece == gradeChoisi)
                        {
                            pieceAPlacer = p;
                            break;
                        }
                    }
                    Equipe ancienJoueur = jeu.JoueurCourant;
                    bool placementReussi = jeu.PlacerPieceManuelle(xClick, yClick, pieceAPlacer);
                    if (placementReussi)
                    {
                        MajAffichage();
                        MajInventaire();
                        if (ancienJoueur == Equipe.Rouge && jeu.JoueurCourant == Equipe.Bleu)
                        {
                            labelTransition.Text = "Placement terminé pour ROUGE !\nAu tour du joueur BLEU de placer ses pièces.";
                            labelTransition.ForeColor = Color.CornflowerBlue;
                            panelTransition.Visible = true;
                            panelTransition.BringToFront();
                        }
                        else if (ancienJoueur == Equipe.Bleu && jeu.EtatActuel == EtatJeu.EnJeu)
                        {
                            labelTransition.Text = "La phase de préparation est terminée !\nLa partie commence, c'est au joueur ROUGE.";
                            labelTransition.ForeColor = Color.Tomato;
                            panelTransition.Visible = true;
                            panelTransition.BringToFront();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Placement impossible !\nRappel : Lignes 0-1 pour l'équipe Rouge, Lignes 6-7 pour l'équipe Bleue.\nLa case doit également être vide.", "Mouvement invalide", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Veuillez d'abord sélectionner une pièce dans la liste à droite avant de cliquer sur la grille !", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return;
            }


            if (caseSelectionnee == null)
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
                Piece attaquant = jeu.LePlateau.ObtenirPiece(xDepart, yDepart);
                Piece cible = jeu.LePlateau.ObtenirPiece(xClick, yClick);

                bool combat = (cible != null && cible.EquipePiece != attaquant.EquipePiece);
                string nomAttaquant = attaquant.GradePiece.ToString();
                string nomCible = combat ? cible.GradePiece.ToString() : "";


                bool deplacementReussi = jeu.DeplacerPiece(xDepart, yDepart, xClick, yClick);

                caseSelectionnee = null;
                MajAffichage();
                if (deplacementReussi && jeu.EtatActuel != EtatJeu.Termine)
                {
                    if (combat)
                    {
                        Piece gangant = jeu.LePlateau.ObtenirPiece(xClick, yClick);
                        string rapport = $"Votre {nomAttaquant} a attaqué un(e) {nomCible} adverse !\n\n";
                        if (gangant == null)
                        {
                            rapport += "Les deux pièces sont de force égale et se sont tuées mutuellement.";
                        }
                        else if (gangant.EquipePiece == attaquant.EquipePiece)
                        {
                            rapport += $"Votre {nomAttaquant} a gagné le combat et a pris la place du {nomCible} !";
                        }
                        else
                        {
                            rapport += $"Votre {nomAttaquant} a perdu le combat contre le {nomCible} adverse et a été retiré du plateau.";
                        }
                        MessageBox.Show(rapport, "Rapport de combat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }




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
                        button.Font = new Font("Segoe UI", 7, FontStyle.Bold);
                        button.ForeColor = Color.White;
                    }
                }
            }
        }
        private void MajInventaire()
        {
            listBoxPieces.Items.Clear();

            if (jeu.EtatActuel == EtatJeu.Placement)
            {
                listBoxPieces.Visible = true;

                
                foreach (Piece p in jeu.PiecesEnAttente)
                {
                    listBoxPieces.Items.Add(p.GradePiece);
                }
            }
            else
            {
                listBoxPieces.Visible = false;
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
