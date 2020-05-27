
using System.Collections;
using System.Collections.Generic;
using Objets;
using UnityEngine;
/* Author : Julien Lung Yut Fong
 *
 * Scripte de l'attaque sur le coté du joueur 2
 */
public class AttackHit2 : MonoBehaviour
{
    private void Start()
    {
        transform.localScale = Personnages.Personnages.perso2.scaleHit;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Controles joueur = other.gameObject.GetComponent<Controles>();
        Controles2 joueur2 = gameObject.GetComponentInParent<Controles2>();
        if (joueur != null)
        {
            if (joueur.j.position.x - joueur2.j.position.x > 0)
            {
                joueur.j.directionProj = 1;
            }
            else
            {
                joueur.j.directionProj = -1;
            }
            
            joueur.j.etats[Joueur.knocked].setTimer(0.3f);
            joueur.j.Vitesse =
                new Vector3(joueur.j.Vitesse.x, joueur.j.Vitesse.y > 0.4f ? joueur.j.Vitesse.y : 0.4f, 0);
            if (!joueur.j.etats[Joueur.invincibility].actif)
            {
                joueur.j.etats[Joueur.stunned].setTimer(0.5f);
                joueur.j.estAttaque(joueur.anim, joueur.p, 10, 0.4f);
            }
        }
    }
}
