using System;
using UnityEngine;
/* Author : Guillaume MERCIER
 *
 * Classe des états
 */
namespace Objets
{
    public class Etats
    {
        protected internal bool actif;
        private int timer;

        public int Timer
        {
            get => timer;
            set => timer = Convert.ToInt32(value/Time.fixedDeltaTime);
        }

        public Etats()
        {
            this.actif = false;
            this.timer = 0;
        }

        public void update()
        {
            actif = true;
            timer--;
            if (timer <= 0)
            {
                timer = 0;
                actif = false;
            }
        }
    }
}