using System;
using UnityEngine;

namespace Objets
{
    public class Joueur : ObjetsMovibles
    {
        #region Attributs

        private string nom;
        public int pv;
        private int pvMax;
        protected internal bool isAlive;
        protected internal int nbSauts;
        protected internal int nbSautsMax;
        
        protected internal Etats[] etats;
        protected internal const int invincibility = 0;
        protected internal const int stunned = 1;
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
                else
                {
                    pv = value;
                }
            }
        }

        #endregion

        #region Constructeur

        public Joueur(string nom, int pv,Vector3 position, float demiHauteur, float demiLargeur, int masse, int nbSauts = 1) : base(position, demiHauteur,demiLargeur,masse)
        {
            this.isAlive = true;
            this.nom = nom;
            this.pv = pv;
            this.pvMax = pv;
            this.nbSauts = nbSauts;
            this.nbSautsMax = nbSauts;
            
            Etats et0 = new Etats();
            Etats et1 = new Etats();
            etats = new Etats[]{et0, et1};
        }
        
        #endregion

        #region Methodes

        protected internal void estAttaque(int degats = 0, float dureeStun = 5)//durée en sec
        {
            if (!etats[invincibility].actif)
            {
                Pv -= degats;
                etats[invincibility].timer = Convert.ToInt32(dureeStun/Time.fixedDeltaTime);
            }
        }

        protected internal void Attaque(Joueur cible, Attaque nomattaque ) //TODO faire les attaques
        {
            nomattaque.hit(cible);
        }

        protected internal Vector2 UpdatePositionJoueur()
        {
            return this.UpdatePositionObjetMovible();
        }
        #endregion
    }
}