using Stratego_TT_25_26.Vue;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stratego_TT_25_26
{
    public partial class FenetreAccueil : Form
    {
        public FenetreAccueil()
        {
            InitializeComponent();
        }

        private void bNouvellePartie_Click(object sender, EventArgs e)
        {
            FenetreJeu fenetreJeu= new FenetreJeu();
            fenetreJeu.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Fichier de sauvegarde Stratego (*.json)|*.json";
            ofd.Title = "Choisissez une partie à charger";

            // Si le joueur sélectionne un fichier et clique sur "Ouvrir"
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // On crée le jeu en lui envoyant le chemin du fichier choisi !
                FenetreJeu ecranJeu = new FenetreJeu(ofd.FileName);
                ecranJeu.Show();
                this.Hide();
            }
        }
    }
}
