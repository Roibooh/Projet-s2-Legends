using UnityEngine;

namespace Objets
{
    public class Projectiles : MonoBehaviour
    {
        private ObjetsMovibles o;
        void Awake()
        {
            o = new ObjetsMovibles(
                new Vector3(0, 0, 0),
                new Vector3(0.5f, 0.5f),
                new Quaternion(0, 0, 0, 0),
                accelerationY: 0.01f);
            transform.position = o.position;
            transform.rotation = o.localrotate;
            transform.localScale = o.localscale;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            o.UpdatePositionObjetMovible();
            transform.position = o.position;
            
            if (o.position.y > 20)
            {
                transform.position = o.position;
                gameObject.SetActive(false);
            }
        }
    }
}

/*
public class Projectiles : ObjetsMovibles
{
    public Projectiles() : base(
        new Vector3(0, 0, 0),
        new Vector3(1, 1, 1),
        new Quaternion(0, 0, 0, 0),
        accelerationX: 0.5f)
    {
        
    }
}*/
