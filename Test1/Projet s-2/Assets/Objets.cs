using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Objets
{
    public abstract class Objets
    {
        #region Attributs
        protected internal Vector3 position;
        protected internal float demiHauteur;
        protected internal float demiLargeur;
        public Vector3 Position
        {
            get => position;
            private set => position = value;
        }
        #endregion
        #region Constructeur
        public Objets(Vector3 position, float demiHauteur,float demiLargeur)
        {
            this.position = position;
            this.demiLargeur = demiLargeur;// changer largeur et hauteur par demi hauteur et demi largeur
            this.demiHauteur = demiHauteur;
        }
        #endregion

        #region Methodes

        protected internal bool CollisionX(Objets obj2)
        {
            return ((this.position.x + this.demiLargeur >= obj2.position.x - obj2.demiLargeur ) &&
                    (this.position.x - this.demiLargeur <= obj2.position.x + obj2.demiLargeur ));
        }
        protected internal bool CollisionY(Objets obj2)
        {
            return ((this.position.y + this.demiHauteur >= obj2.position.y - obj2.demiHauteur ) &&
                    (this.position.y - this.demiHauteur <= obj2.position.y + obj2.demiHauteur ));
        }

        protected internal void Collision(Objets obj2)
        {
            if (CollisionX(obj2)&&CollisionY(obj2))
            {
                if (obj2.position.x - obj2.demiLargeur- this.position.x + this.demiLargeur >= 0)// check gauche
                {
                    this.position.x = obj2.position.x - this.demiLargeur - obj2.demiLargeur;
                }
                else if (obj2.position.x + obj2.demiLargeur - this.position.x + this.demiLargeur < 0)// check droit
                {
                    this.position.x = obj2.position.x + this.demiLargeur + obj2.demiLargeur;
                }
                if (obj2.position.y - obj2.demiHauteur - this.position.y + this.demiHauteur >= 0) // check bas 
                {
                    this.position.y = obj2.position.y - obj2.demiHauteur - this.demiHauteur;
                }
                else if (obj2.position.y + obj2.demiHauteur - this.position.y - this.demiHauteur < 0) // check haut
                {
                    this.position.y = obj2.demiHauteur + obj2.position.y + this.demiHauteur;
                }
            }
        }
        #endregion
    }
    
}
