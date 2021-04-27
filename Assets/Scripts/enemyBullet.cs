using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour
{

    public float speed = 1f;

    [SerializeField]
    private GameObject effect;

    void Update()
    {
        //Move();
        //OntriggerEnter2D();
    }

    void Move()
    {
        Vector2 temp = transform.position;
        temp.x -= speed * Time.deltaTime;

        transform.position = temp;
    }

    private void OntriggerEnter2D(Collider2D collision)
    {
        //if(target.tag == "Player")
        //{
        //    Destroy(target.gameObject);
        //    Destroy(this.gameObject);
        //}
        if (collision.tag == "Player")
        {
            //Destroy(target.gameObject);
            Destroy(gameObject);
        }

        if(collision.tag=="floor")
        {
            Destroy(Instantiate(effect, transform.position, Quaternion.identity), 2);
            Destroy(this.gameObject);

        }    
    }

}
