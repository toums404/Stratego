using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratego_TT_25_26.Modele
{
    public class Plateau
    {
        public Piece[,] Grille { get; private set; }
        public const int TAILLE = 8;//8X8

        public Plateau()
        {
            Grille = new Piece[TAILLE, TAILLE];
        }

        public bool EstSurLePlateau(int x, int y)
        {
            return x >= 0 && x < TAILLE && y >= 0 && y < TAILLE;//vérifie que les coordonnées sont dans les limites du plateau
        }

        public Piece ObtenirPiece(int x, int y)
        {
            if (!EstSurLePlateau(x, y)) return null;//si les coordonnées ne sont pas sur le plateau, retourne null
            return Grille[x, y];
        }

        public void PlacerPiece(int x, int y, Piece piece)
        {
            if (EstSurLePlateau(x, y))
            {
                Grille[x, y] = piece;//place la pièce à la position spécifiée
            }
        }

        public void ViderCase(int x, int y)
        {
            if (EstSurLePlateau(x, y))
            {
                Grille[x, y] = null;//vide la case en mettant la référence à null
            }
        }

    }
}
