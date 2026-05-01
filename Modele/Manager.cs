using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;


namespace Stratego_TT_25_26.Modele
{
    public class Manager
    {
        public Plateau LePlateau { get; private set; }
        public Equipe JoueurCourant { get; private set; }
        public EtatJeu EtatActuel { get; private set; }
        public Equipe Vainqueur { get; private set; }
        public List<Piece> PiecesEnAttente { get; private set; } = new List<Piece>();


        public Manager()
        {
            LePlateau = new Plateau();
            JoueurCourant = Equipe.Rouge;
            EtatActuel = EtatJeu.EnJeu;
            Vainqueur = Equipe.Aucune;
        }
        public void ChangerTour()
        {
            if (JoueurCourant == Equipe.Rouge)
                JoueurCourant = Equipe.Bleu;
            else
                JoueurCourant = Equipe.Rouge;
        }
        public Piece Combat(Piece Attaquant, Piece Defenseur)
        {
            //Attaquant.EstDecouverte = true;
            //Defenseur.EstDecouverte = true;

            if (Defenseur.GradePiece == Grade.Drapeau)
            {
                EtatActuel = EtatJeu.Termine;
                Vainqueur = Attaquant.EquipePiece;
                return Attaquant;
            }
            if (Attaquant.GradePiece == Grade.Demineur && Defenseur.GradePiece == Grade.Bombe)
            {
                return Attaquant;
            }
            if (Defenseur.GradePiece == Grade.Bombe)
            {
                return Defenseur;
            }
            if (Attaquant.GradePiece == Grade.Espion && Defenseur.GradePiece == Grade.Marechal)
            {
                return Attaquant;
            }
            if ((int)Attaquant.GradePiece > (int)Defenseur.GradePiece)
            {
                return Attaquant;
            }
            else if ((int)Attaquant.GradePiece < (int)Defenseur.GradePiece)
            {
                return Defenseur;
            }
            else
            {
                return null;//les deux pièces sont retirées du plateau si egalité
            }
        }
        public bool DeplacerPiece(int xDepart, int yDepart, int xArrive, int yArrive)
        {
            if (!LePlateau.EstSurLePlateau(xDepart, yDepart) || !LePlateau.EstSurLePlateau(xArrive, yArrive))
            {
                return false;//déplacement hors du plateau
            }
            Piece pieceDeplacee = LePlateau.ObtenirPiece(xDepart, yDepart);

            if (pieceDeplacee == null || pieceDeplacee.EquipePiece != JoueurCourant || !pieceDeplacee.PeutBouger())
            {
                return false;//verifie si la piece existe, appartient au bon joueuer et si elle peut bouger
            }
            int distanceX = Math.Abs(xDepart - xArrive);
            int distanceY = Math.Abs(yDepart - yArrive);


            if(pieceDeplacee.GradePiece == Grade.Eclaireur) 
            {
                if ( xDepart != xArrive && yDepart != yArrive)
                {
                    return false;//les eclaireurs ne peuvent pas se deplacer en diagonale
                }
                //boucle pour verif que il ne passe pas au dessus d'une piece
                //ca calcule le pas de déplacement en x et y (1, -1 ou 0) en fonction de la direction du déplacement
                //et il teste chaque case pour voir si elle est vide ou pas jusqu'à arriver à la destination
                int pasX = (xArrive > xDepart) ? 1 : (xArrive < xDepart) ? -1 : 0;
                int pasY = (yArrive > yDepart) ? 1 : (yArrive < yDepart) ? -1 : 0;

                int testX = xDepart + pasX;
                int testY = yDepart + pasY;

                while (testX != xArrive || testY != yArrive)
                {
                    if (LePlateau.ObtenirPiece(testX, testY) != null)
                    {
                        MessageBox.Show("L'éclaireur ne peut pas sauter par dessus une pièce !", "Déplacement invalide", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    testX += pasX;
                    testY += pasY;
                }
            }
            else 
            {
                if (distanceX + distanceY != 1)
                {
                    return false;//pour les deplacement en croix, la somme des distances doit être égale à 1
                }
            }
            Piece pieceCible = LePlateau.ObtenirPiece(xArrive, yArrive);
            if (pieceCible == null)
            {
                LePlateau.PlacerPiece(xArrive, yArrive, pieceDeplacee);
                LePlateau.ViderCase(xDepart, yDepart);
            }
            else
            {
                if (pieceCible.EquipePiece == pieceDeplacee.EquipePiece)
                {
                    return false;//ne peut pas attaquer une pièce de la même équipe
                }
                Piece vainqueur = Combat(pieceDeplacee, pieceCible);
                LePlateau.ViderCase(xDepart, yDepart);
                if (vainqueur == pieceDeplacee)
                {
                    LePlateau.PlacerPiece(xArrive, yArrive, pieceDeplacee);
                }
                else if (vainqueur == pieceCible)
                {
                    //le defenseur reste en place, l'attaquant est retiré du plateau
                }
                else
                {
                    LePlateau.ViderCase(xArrive, yArrive);//les deux pièces sont retirées du plateau en cas d'égalité
                }

            }
            if (EtatActuel != EtatJeu.Termine)
            {
                ChangerTour();
            }
            return true;


        }
        public void InitialiserPartieAleatoire()
        {
            LePlateau = new Plateau();
            EtatActuel = EtatJeu.EnJeu;
            JoueurCourant = Equipe.Rouge;
            Vainqueur = Equipe.Aucune;
            PlacerEquipeAleatoire(Equipe.Rouge, 0, 1, 0);
            PlacerEquipeAleatoire(Equipe.Bleu, 6, 7, 7);
        }
        public void InitialiserPartieManuelle()
        {
            LePlateau = new Plateau();
            EtatActuel = EtatJeu.Placement;
            JoueurCourant = Equipe.Rouge;
            Vainqueur = Equipe.Aucune;
            RemplirPiecesEnAttente(JoueurCourant);
        }
        private void RemplirPiecesEnAttente(Equipe equipe)
        {
            PiecesEnAttente.Clear();
            PiecesEnAttente.Add(new Piece(Grade.Drapeau, equipe));
            PiecesEnAttente.Add(new Piece(Grade.Marechal, equipe));
            PiecesEnAttente.Add(new Piece(Grade.General, equipe));
            PiecesEnAttente.Add(new Piece(Grade.Espion, equipe));

            for (int i = 0; i < 3; i++) PiecesEnAttente.Add(new Piece(Grade.Bombe, equipe));
            for (int i = 0; i < 3; i++) PiecesEnAttente.Add(new Piece(Grade.Demineur, equipe));
            for (int i = 0; i < 3; i++) PiecesEnAttente.Add(new Piece(Grade.Eclaireur, equipe));
            for (int i = 0; i < 3; i++) PiecesEnAttente.Add(new Piece(Grade.Soldat, equipe));
        }
        public bool PlacerPieceManuelle(int x, int y, Piece pieceAPlacer)
        {
            if (JoueurCourant == Equipe.Rouge && (y > 1)) return false; // rouges : lignes 0 et 1
            if (JoueurCourant == Equipe.Bleu && (y < 6)) return false;  // bleus : lignes 6 et 7

            if (LePlateau.ObtenirPiece(x, y) != null) return false;

            LePlateau.PlacerPiece(x, y, pieceAPlacer);
            PiecesEnAttente.Remove(pieceAPlacer);

            if (PiecesEnAttente.Count == 0)
            {
                if (JoueurCourant == Equipe.Rouge)
                {
                    JoueurCourant = Equipe.Bleu;
                    RemplirPiecesEnAttente(JoueurCourant);
                }
                else
                {
                    JoueurCourant = Equipe.Rouge; 
                    EtatActuel = EtatJeu.EnJeu;
                }
            }
            return true;
        }
        private void PlacerEquipeAleatoire(Equipe equipe, int ligneDebut, int ligneFin, int ligneFond)
        {
            //16 piece par equipe et on pplace le drapeau par defaut sur la ligne de fond de chaque equipe
            Random random = new Random();
            Piece drapeau = new Piece(Grade.Drapeau, equipe);
            int xDrapeau = random.Next(0, Plateau.TAILLE);
            LePlateau.PlacerPiece(xDrapeau, ligneFond, drapeau);

            List<Piece> piecesAPlacer = new List<Piece>
            {
            new Piece(Grade.Marechal, equipe),

            new Piece(Grade.General, equipe),

            new Piece(Grade.Espion, equipe),

            new Piece(Grade.Bombe, equipe),
            new Piece(Grade.Bombe, equipe),
            new Piece(Grade.Bombe, equipe),

            new Piece(Grade.Demineur, equipe),
            new Piece(Grade.Demineur, equipe),
            new Piece(Grade.Demineur, equipe),

            new Piece(Grade.Eclaireur, equipe),
            new Piece(Grade.Eclaireur, equipe),
            new Piece(Grade.Eclaireur, equipe),

            new Piece(Grade.Soldat, equipe),
            new Piece(Grade.Soldat, equipe),
            new Piece(Grade.Soldat, equipe)
            };
            List<(int x, int y)> casesDisponibles = new List<(int x, int y)>();// on liste les cases vide ( dispo ) dans la zone de chaque joueur 

            for (int x = 0; x < Plateau.TAILLE; x++)
            {
                for (int y = ligneDebut; y <= ligneFin; y++)
                {
                    //si la case n'est pas celle du drapeau 
                    if (LePlateau.ObtenirPiece(x, y) == null)
                    {
                        casesDisponibles.Add((x, y));
                    }
                }
            }
            foreach (Piece p in piecesAPlacer)
            {
                int indexAleatoire = random.Next(casesDisponibles.Count);
                var caseChoisie = casesDisponibles[indexAleatoire];

                LePlateau.PlacerPiece(caseChoisie.x, caseChoisie.y, p);

                casesDisponibles.RemoveAt(indexAleatoire);//retire la case choisie de la liste des cases disponibles 
            }
        }
        public void SauvegarderPartie(string cheminFichier)
        {
            DonneesSauvegarde data = new DonneesSauvegarde();
            data.JoueurCourant = this.JoueurCourant;
            data.EtatActuel = this.EtatActuel;

            for (int y = 0; y < Plateau.TAILLE; y++)
            {
                for (int x = 0; x < Plateau.TAILLE; x++)
                {
                    Piece p = LePlateau.ObtenirPiece(x, y);
                    if (p != null)
                    {
                        data.PiecesSurPlateau.Add(new PieceSauvegarde
                        {
                            X = x,
                            Y = y,
                            GradePiece = p.GradePiece,
                            EquipePiece = p.EquipePiece,
                            EstDecouverte = p.EstDecouverte
                        });
                    }
                }
            }
            string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(cheminFichier, json);
        }
        public void ChargerPartie(string cheminFichier)
        {
            if (!File.Exists(cheminFichier)) return;

            string json = File.ReadAllText(cheminFichier);
            DonneesSauvegarde data = JsonSerializer.Deserialize<DonneesSauvegarde>(json);

            this.JoueurCourant = data.JoueurCourant;
            this.EtatActuel = data.EtatActuel;
            this.Vainqueur = Equipe.Aucune;
            this.LePlateau = new Plateau();

            foreach (PieceSauvegarde ps in data.PiecesSurPlateau)
            {
                Piece p = new Piece(ps.GradePiece, ps.EquipePiece);
                p.EstDecouverte = ps.EstDecouverte;
                LePlateau.PlacerPiece(ps.X, ps.Y, p);
            }
        }
    }
}
