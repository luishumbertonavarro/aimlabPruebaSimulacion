using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag=="target"){
            GameObject e = Instantiate(explosion) as GameObject;
            e.transform.position=transform.position;
            PointShoot.contador++;
            Destroy(other.gameObject);
            Destroy(e,1);
            //Debug.Log(PointShoot.contador);
            
            
        }
    }
}
