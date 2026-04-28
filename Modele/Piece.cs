using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratego_TT_25_26.Modele
{
    public class Piece
    {
        public Grade GradePiece { get; private set; }//private pour que les grades soient définis à la création de la pièce et ne puissent pas être modifiés par la suite
        public Equipe EquipePiece { get; private set; }
        public bool EstDecouverte { get; set; } 

        public Piece (Grade grade, Equipe equipe)
        {
            GradePiece = grade;
            EquipePiece = equipe;
            EstDecouverte = false;
        }

        public bool PeutBouger()
        {
            if(GradePiece == Grade.Bombe || GradePiece == Grade.Drapeau)
            {
                return false;
            }
            return true;
        }
    }
}
