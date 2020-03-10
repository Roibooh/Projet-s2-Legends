using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Objets
{
    public class Controles : MonoBehaviour
    {
        private bool upKeyAlreadyPressed;
        private bool leftKeyAlreadyPressed;
        private bool rigthKeyAlreadyPressed;
        private bool downKeyAlreadyPressed;
        
        private Joueur j;
        // Start is called before the first frame update
        void Start()
        {
            j = new Joueur("test",100,transform.position,20,20,1);
            upKeyAlreadyPressed = false;
            leftKeyAlreadyPressed = false;
            rigthKeyAlreadyPressed = false;
            downKeyAlreadyPressed = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey("up"))
            {
                if (!upKeyAlreadyPressed)
                {
                    j.ChgAccel(0,(float)0.01);
                    upKeyAlreadyPressed = true;
                }
            } 
            else
            {
                if (upKeyAlreadyPressed)
                {
                    j.ChgAccel(0,(float)-0.01);
                    upKeyAlreadyPressed = false;
                }
            } //pour 1 ctrl..
            transform.position = j.UpdatePositionJoueur();
            
        }
    }
}