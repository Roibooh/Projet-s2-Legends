using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Objets
{
    public abstract class Objets
    {
        protected internal Vector3 position;

        public Vector3 Position
        {
            get => position;
            private set => position = value;
        }

        public Objets(Vector3 position)
        {
            this.position = position;
        }
        
    }
    
}
