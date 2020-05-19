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
    private void Start()
    {
        transform.localScale = Personnages.Personnages.perso2.scaleHitDown;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Controles joueur = other.gameObject.GetComponent<Controles>();
        if (joueur != null)
        {
            joueur.j.etats[Joueur.stunned].setTimer(0.6f);
            joueur.j.Vitesse = new Vector3(joueur.j.Vitesse.x, joueur.j.Vitesse.y >0.4f? joueur.j.Vitesse.y:0.4f, 0);
            joueur.j.estAttaque(20,0.4f);
        }
    }
}
