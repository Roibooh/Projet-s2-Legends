using System.Security.Principal;
/* Author : Julien Lung Yut Fong
 *
 * Classe des attaques
 */
namespace Objets
{
    public class Attaque
    {
        #region Attributs

        private int directionProjection; //multipli a la force de l'attaque
        private int degatsAttaque;

        #endregion

        #region Constructeur

        public Attaque(int degatsAttaque, int directionProjection, int forceJoueur)
        {
            this.degatsAttaque = degatsAttaque;
            this.directionProjection = directionProjection;
        }

        #endregion

        #region Methodes

        protected internal void hit(Joueur cible)
        {
            cible.estAttaque(this.degatsAttaque);
        }

        #endregion
    }
}
    
