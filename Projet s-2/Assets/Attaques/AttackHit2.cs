using System.Collections;
using System.Collections.Generic;
using Objets;
using UnityEngine;

public class AttackHit2 : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)    
    {
        
        Controles joueur = other.gameObject.GetComponent<Controles>();
        if (joueur != null)
        { 
            joueur.j.Vitesse =  new Vector3(0,joueur.j.Vitesse.y +1,0);
            joueur.j.estAttaque(20,1.5f);
        }
    }
}
