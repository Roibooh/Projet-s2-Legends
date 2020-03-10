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
        private float hauteur;
        private float largeur;
        public Vector3 Position
        {
            get => position;
            private set => position = value;
        }
        #endregion
        #region Constructeur
        public Objets(Vector3 position, float hauteur,float largeur)
        {
            this.position = position;
            this.largeur = largeur;// changer largeur et hauteur par demi hauteur et demi largeur
            this.hauteur = hauteur;
        }
        #endregion

        #region Methodes

        protected internal void CollisionX(Objets obj2)
        {
            if ((this.position.x + this.largeur / 2 > obj2.position.x-obj2.largeur/2) && (this.position.x - this.largeur/2 < obj2.position.x+obj2.largeur/2))
            { 
                this.position.x = 0;
            }
        }
        protected internal void CollisionY(Objets obj2)
        {
            if ((this.position.y + this.hauteur / 2 > obj2.position.y-obj2.hauteur/2) && (this.position.y - this.hauteur/2 < obj2.position.y+obj2.hauteur/2))
            { 
                this.position.y = 0; 
            }
        }

        protected internal void Collision(Objets obj2)
        {
            CollisionX(obj2);
            CollisionY(obj2);
        }
        #endregion
    }
    
}
