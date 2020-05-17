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

        public void setTimer(float time)
        {
             int t = Convert.ToInt32(time/Time.fixedDeltaTime);
             if (t > timer)
             {
                 timer = t;
             }
        }

        public int Timer
        {
            get => timer;
            private set => timer = value;
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