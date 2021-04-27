using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody2D myBody;


    //private Animator a;
    [SerializeField]
    private GameObject effect;

    void Start()
    {
        //a = gameObject.GetComponent<Animator>();
        myBody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //Attack();
        Move();
    }

    //void Attack()
    //{
    //    Vector2 temp = transform.position;
    //    temp.y += 20 * Time.deltaTime;
    //    transform.position = temp;

    //    if (temp.y > 6) Destroy(this.gameObject);
    //}

    void Move()
    {
        //Vector2 temp = transform.position;
        //temp.x -= speed * Time.deltaTime;

        //transform.position = temp;

        myBody.velocity = new Vector2(transform.localScale.x, 0) * speed;
    }

    public void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
        {
            //Destroy(target.gameObject);
            Destroy(gameObject);
            

        }
        if (target.tag == "Floor")
        {
            Destroy(Instantiate(effect, transform.position, Quaternion.identity),2);
            Destroy(gameObject);
        }

    }
}
