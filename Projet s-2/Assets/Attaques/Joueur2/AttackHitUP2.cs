using System.Collections;
using System.Collections.Generic;
using Objets;
using UnityEngine;
/* Author : Julien Lung Yut Fong
 *
 * Scripte de l'attaque sur le haut du joueur 2
 */
public class AttackHitUP2 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Controles joueur = other.gameObject.GetComponent<Controles>();
        if (joueur != null)
        {
            joueur.j.Vitesse = new Vector3(joueur.j.Vitesse.x, joueur.j.Vitesse.y + 1, 0);
            joueur.j.estAttaque(20,0.4f);
        }
    }
}
