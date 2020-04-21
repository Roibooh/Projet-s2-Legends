using System.Collections;
using System.Collections.Generic;
using Objets;
using UnityEngine;

public class AttackHit : MonoBehaviour
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
        other.gameObject.GetComponent<Controles2>().j.estAttaque(10);
        
        Debug.Log("WOW");
    }
}
