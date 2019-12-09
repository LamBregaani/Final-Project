using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float speed;
    Transform myTrans;

    // Start is called before the first frame update
    void Start()
    {
        speed = 1;
    }

    
    void FixedUpdate()
    {
        transform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime);
    }



    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemylimits")
        {
            speed *= -1;
            Vector2 Scaler = transform.localScale;
            Scaler.x = Scaler.x * -1;
            transform.localScale = Scaler;

        }
    }

}
