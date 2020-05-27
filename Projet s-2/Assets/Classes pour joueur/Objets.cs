using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
/* Author : Guillaume MERCIER et Julien Lung Yut Fong
 *
 * Classe des objets
 */
namespace Objets
{
    public abstract class Objets
    {
        #region Attributs
        protected internal Vector3 position;
        protected internal Vector3 localscale;
        protected internal Quaternion localrotate;
        protected internal float demiHauteur;
        protected internal float demiLargeur;
        protected internal Vector3 Position
        {
            set
            {
                position = value;
                if (position.y - demiHauteur <= 0)
                {
                    position = new Vector3(position.x,demiHauteur,position.z);
                }
                
            }
        }
        #endregion
        
        #region Constructeur
        public Objets(Vector3 position, float demiHauteur,float demiLargeur, Vector3 localscale, Quaternion localrotate)
        {
            this.position = position;
            this.demiLargeur = demiLargeur;// changer largeur et hauteur par demi hauteur et demi largeur
            this.demiHauteur = demiHauteur;
            this.localrotate = localrotate;
            this.localscale = localscale;
        }
        #endregion

        #region Methodes
        /*
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
        }*/
        #endregion
    }
    
}
