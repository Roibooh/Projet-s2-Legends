using System;
using System.Diagnostics.Tracing;
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
        protected internal const int knocked = 2;
        protected internal const int crouched = 3;
        protected internal const int flying = 4;
        protected internal const int attacking = 5;
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
            Etats et2 = new Etats();
            Etats et3 = new Etats();
            Etats et4 = new Etats();
            Etats et5 = new Etats();

            etats = new Etats[]{et0, et1, et2, et3, et4, et5};
        }
        
        #endregion

        #region Methodes

        protected internal void estAttaque(int degats = 0, float dureeInv = 5)//durée en sec
        {
            if (!etats[invincibility].actif)
            {
                etats[1].timer = 35;
                Pv -= degats;
                etats[invincibility].timer = Convert.ToInt32(dureeInv/Time.fixedDeltaTime);
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