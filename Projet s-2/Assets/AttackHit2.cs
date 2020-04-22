using System.Collections;
using System.Collections.Generic;
using Objets;
using UnityEngine;

public class AttackHit2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D other)    
    {
        
        other.gameObject.GetComponent<Controles>().j.estAttaque(20);
        
        //Debug.Log("WOW");
    }
}
