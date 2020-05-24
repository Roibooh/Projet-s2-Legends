using System.Collections;
using System.Collections.Generic;
using Objets;
using UnityEngine;
/* Author : Julien Lung Yut Fong
 *
 * Scripte de l'attaque vers le bas du joueur 1
 */
public class AttackHitSPIKE : MonoBehaviour
{
    private void Start()
    {
        transform.localScale = Personnages.Personnages.perso1.scaleHitUp;
    }
    private void OnTriggerEnter2D(Collider2D other)    
    {
        
        Controles2 joueur2 = other.gameObject.GetComponent<Controles2>();
        if (joueur2 != null)
        { 
            joueur2.j.Vitesse =  new Vector3(joueur2.j.Vitesse.x, -2,0);
            joueur2.j.estAttaque(joueur2.anim , joueur2.p,100,0.4f);
        }
    }
}
