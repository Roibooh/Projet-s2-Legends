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
            new []{"u", "i", "q", "d", "z", "s","o"}, 
            new []{"Hit", "Hitup", "Spike","Projectile"},
            new Vector2 (0.5f,0.5f),
            new Vector2 (0.5f,0.5f),
            new Vector2 (0.5f,0.5f),
            new Vector2 (0.5f,0.5f)
            );
        
        public static readonly Personnage perso2 = new Personnage(
            new []{"[1]", "[2]", "left","right","up","down","[3]"}, 
            new []{"HitShort", "Hitup", "Spike","Projectile"},
            new Vector2 (1f,0.5f),
            new Vector2 (0.5f,1f),
            new Vector2 (0.5f,1f),
            new Vector2 (0.5f,0.5f)
            );
    }
}