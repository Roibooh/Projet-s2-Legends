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
    private void OnTriggerEnter2D(Collider2D other)
    {
            Controles joueur2 = other.gameObject.GetComponent<Controles>();
            Controles2 joueur = gameObject.GetComponentInParent<Controles2>();
            if (joueur2 != null && !joueur2.j.etats[Joueur.invincibility].actif)
            {
                if (joueur2.j.position.x - joueur.j.position.x > 0)
                {
                    joueur2.j.directionProj = 1;
                }
                else
                {
                    joueur2.j.directionProj = -1;
                }
                joueur2.j.etats[Joueur.stunned].setTimer (0.5f);
                joueur2.j.etats[Joueur.knocked].setTimer (0.2f);
                joueur2.j.Vitesse = new Vector3(joueur2.j.Vitesse.x, joueur2.j.Vitesse.y >0.3f? joueur2.j.Vitesse.y:0.3f, 0);
                joueur2.j.estAttaque(20, 0.4f);
            }
    }
}
