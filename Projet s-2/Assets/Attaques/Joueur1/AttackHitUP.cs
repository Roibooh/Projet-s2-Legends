using System.Collections;
using System.Collections.Generic;
using Objets;
using UnityEngine;
/* Author : Julien Lung Yut Fong
 *
 * Scripte de l'attaque sur le haut du joueur 1
 */
public class AttackHitUP : MonoBehaviour
{
    private void Start()
    {
        transform.localScale = Personnages.Personnages.perso1.scaleHitDown;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Controles2 joueur2 = other.gameObject.GetComponent<Controles2>();
        if (joueur2 != null)
        {
            joueur2.j.Vitesse = new Vector3(joueur2.j.Vitesse.x, joueur2.j.Vitesse.y >0.4f? joueur2.j.Vitesse.y:0.4f, 0);
            joueur2.j.etats[Joueur.stunned].setTimer (0.5f);
            joueur2.j.estAttaque(10,0.4f);
        }
    }
}
