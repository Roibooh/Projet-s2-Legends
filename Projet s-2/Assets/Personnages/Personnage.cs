using UnityEngine;

namespace Personnages
{
    public class Personnages
    {
        public class Personnage
        {
            internal KeyCode[] keys;
            internal string[] anim;
            internal Vector2 scaleHit;
            internal Vector2 scaleHitUp;
            internal Vector2 scaleHitDown;
            internal Vector2 scaleProjectil;
            protected internal Personnage(KeyCode[] keys, string[] anim, Vector2 scaleHit,Vector2 scaleHitUp,Vector2 scaleHitDown,Vector2 scaleProjectil)
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
            new []{KeyCode.Q, KeyCode.D, KeyCode.Z, KeyCode.S,KeyCode.U, KeyCode.I,KeyCode.O}, 
            new []{"Hit", "Kick", "Spike","Projectile","Jump","FlyingUp","FlyingDown","LowKick","Land","Blocking","Walking","GetHit","Crouching","Crouched","Decrouch"},
            new Vector2 (3f,0.5f),
            new Vector2 (3f,0.5f),
            new Vector2 (3f,0.5f),// corriger
            new Vector2 (0.5f,0.5f)
            );
        
        public static readonly Personnage perso2 = new Personnage(
            new []{KeyCode.LeftArrow,KeyCode.RightArrow,KeyCode.UpArrow,KeyCode.DownArrow,KeyCode.Keypad1, KeyCode.Keypad2,KeyCode.Keypad3}, 
            new []{"HitShort", "Hitup", "Spike","Projectile"},
            new Vector2 (1f,0.5f),
            new Vector2 (0.5f,1f),
            new Vector2 (0.5f,1f),
            new Vector2 (0.5f,0.5f)
            );
    }
}