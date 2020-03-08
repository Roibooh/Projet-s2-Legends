using System.Security.Principal;

namespace Objets
{
    public class Attaque
    {
        #region Attributs

        private int directionProjection; //multipli a la force de l'attaque
        private int degatsAttaque;
        private int forceJoueur;

        #endregion

        #region Constructeur

        public Attaque(int degatsAttaque, int directionProjection, int forceJoueur)
        {
            this.degatsAttaque = degatsAttaque;
            this.directionProjection = directionProjection;
            this.forceJoueur = forceJoueur;
        }

        #endregion

        #region Methodes

        protected internal void hit(Joueur cible)
        {
            cible.estAttaque(this.degatsAttaque * this.forceJoueur);
        }

        #endregion
    }
}
    
