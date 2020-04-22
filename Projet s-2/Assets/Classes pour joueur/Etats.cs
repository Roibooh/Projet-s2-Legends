namespace Objets
{
    public class Etats
    {
        protected internal bool actif;
        protected internal int timer;

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