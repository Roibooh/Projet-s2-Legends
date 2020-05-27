using UnityEngine;

namespace Personnages
{
    public class Personnages
    {
        public class Personnage
        {
            internal string[] keys;
            internal string[] anim;
            internal Vector2 scaleHit;
            internal Vector2 scaleHitUp;
            internal Vector2 scaleHitDown;
            internal Vector2 scaleProjectil;
            protected internal Personnage(string[] keys, string[] anim, Vector2 scaleHit,Vector2 scaleHitUp,Vector2 scaleHitDown,Vector2 scaleProjectil)
            {
                this.keys = keys;
                this.anim = anim;
                this.scaleHit = scaleHit;
                this.scaleProjectil = scaleProjectil;
                this.scaleHitDown = scaleHitDown;
                this.scaleHitUp = scaleHitUp;
            }
        }

        public static readonly Personnage perso1 = new Personnage(
            new []{"q", "d", "z", "s", "u", "i", "o"},
            new []{"Hit", "Kick", "Spike","Projectile","Jump","FlyingUp","FlyingDown","LowKick","Land","Blocking","Walking","GetHit","Crouching","Crouched","Decrouch","Mort"},
            new Vector2 (3f,0.5f),
            new Vector2 (3f,0.5f),
            new Vector2 (3f,0.5f),// corriger
            new Vector2 (0.5f,0.5f)
            );
        
        public static readonly Personnage perso2 = new Personnage(
            new []{"left","right","up","down","[1]", "[2]","[3]"}, 
            new []{"Hit", "Kick", "Spike","Projectile","Jump","FlyingUp","FlyingDown","LowKick","Land","Blocking","Walking","GetHit","Crouching","Crouched","Decrouch","Mort"},
            new Vector2 (3f,0.5f),
            new Vector2 (3f,0.5f),
            new Vector2 (3f,0.5f),// corriger
            new Vector2 (0.5f,0.5f)
            );
    }
}