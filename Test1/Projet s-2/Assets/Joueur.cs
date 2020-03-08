using UnityEngine;

namespace Objets
{
    public class Joueur : ObjetsMovibles
    {
        #region Attributs
        
        private string nom;
        private int pv;
        private int pvMax;
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

        #region Constructeur

        public Joueur(string nom, int pv, float masse, Vector3 position) : base(position, masse)
        {
            this.isAlive = true;
            this.nom = nom;
            this.pv = pv;
            this.pvMax = pv;
        }
        
        #endregion

        #region Methodes

        protected internal void estAttaque(int degats)
        {
            Pv -= degats;
        }

        protected internal void Attaque(Joueur cible, Attaque nomattaque ) //TODO faire les attaques
        {
            nomattaque.hit(cible);
        }

        protected internal void updateJoueur()
        {
            this.UpdateObjetMovible();
        }
        #endregion
    }
}