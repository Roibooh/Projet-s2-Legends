using UnityEngine;

namespace Objets
{
    public abstract class ObjetsMovibles : Objets
    {
        private Vector2 vitesse;
        private Vector2 acceleration;
        private float poids;
        
        public Vector2 Acceleration
        {
            get => acceleration;
            protected set => acceleration = 
                new Vector2(value.x/poids,value.y/poids);
        }
        

        public ObjetsMovibles(float vitesseX = 0, float vitesseY = 0, float accelerationX = 0, float accelerationY = 0)
        {
            this.vitesse = new Vector2(vitesseX,vitesseY);
            this.acceleration = new Vector2(accelerationX, accelerationY);
        }
            
        
            
        protected void Deplace() //Deplace de X et Y
        {
            position.x += vitesse.x;
            position.y += vitesse.y;
        }

        protected void Accelere()//applique acceleration
        {
            vitesse.x += acceleration.x;
            vitesse.y += acceleration.y;
        }
        
        
    }
}