using System.Collections;
using System.Collections.Generic;
using Objets;
using UnityEngine;
/* Author : Julien Lung Yut Fong
 * 
 * Scripte de l'attaque sur le bas du joueur 2
 */
public class AttackHitSPIKE2 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Controles joueur = other.gameObject.GetComponent<Controles>();
        Controles2 joueur2 = gameObject.GetComponentInParent<Controles2>();
        if (joueur != null)
        {
            joueur.j.etats[Joueur.knocked].setTimer(0.2f);
            joueur.j.Vitesse =
                new Vector3(joueur.j.Vitesse.x, joueur.j.Vitesse.y > 0.8f ? joueur.j.Vitesse.y : 0.8f, 0);
            joueur.j.etats[Joueur.stunned].setTimer(0.5f);
            joueur.j.estAttaque(joueur.anim, joueur.p, 10, 0.4f);
        }
    }
}
