using System.Collections.Generic;  

namespace Stratego_TT_25_26.Modele
{
    public class PieceSauvegarde
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Grade GradePiece { get; set; }
        public Equipe EquipePiece { get; set; }
        public bool EstDecouverte { get; set; }
    }
    public class DonneesSauvegarde
    {
        public Equipe JoueurCourant { get; set; }
        public EtatJeu EtatActuel { get; set; }
        public List<PieceSauvegarde> PiecesSurPlateau { get; set; } = new List<PieceSauvegarde>();
    }
}