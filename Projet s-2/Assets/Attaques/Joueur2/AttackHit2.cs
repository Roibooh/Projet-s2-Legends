using System.Collections;
using System.Collections.Generic;
using Objets;
using UnityEngine;

public class AttackHit2 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
            Controles2 joueur2 = other.gameObject.GetComponent<Controles2>();
            Controles joueur = gameObject.GetComponentInParent<Controles>();
            if (joueur2 != null)
            {
                if (joueur2.j.position.x - joueur.j.position.x > 0)
                {
                    joueur2.directionProj = 1;
                }
                else
                {
                    joueur2.directionProj = -1;
                }

                joueur2.j.etats[Joueur.knocked].timer = 56;
                joueur2.j.Vitesse = new Vector3(joueur2.j.Vitesse.x, joueur2.j.Vitesse.y + 1, 0);
                joueur2.j.estAttaque(20, 0.4f);
            }
    }
}
