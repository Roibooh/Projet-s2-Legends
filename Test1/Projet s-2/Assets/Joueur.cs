using UnityEngine;

namespace Objets
{
    public class Joueur : ObjetsMovibles
    {
        #region Attributs
        
        private string nom;
        private int pv;
        private int pvMax;
        private int force;//potentielment useless a cause de la force des attaques
        private bool isAlive;

        public int Pv
        {
            get => pv;
            private set
            {
                if (value > pvMax)
                {
                    pv = pvMax;
                }
                else if(value < 1)
                {
                    pv = 0;
                    isAlive = false;
                }
            }
        }

        #endregion
        
        
        #region Constructor

        public Joueur(string nom, int pv, int force, float poids, Vector3 position) : base(position, poids)
        {
            this.isAlive = true;
            this.nom = nom;
            this.pv = pv;
            this.pvMax = pv;
            this.force = force;
        }
        
        #endregion

        #region Methodes

        protected internal void estAttaque(int degats)
        {
            Pv -= degats;
        }

        protected internal void attaque(Joueur cible/*, Attaque attaque*/ ) //TODO faire les attaques
        {
            cible.estAttaque(/* attaque.degats * */ force);//TODO 
            //attaque.direction //TODO
            if (cible.position.x - this.position.x > 0)
            {
                
            }
        }
        
        #endregion
    }
}