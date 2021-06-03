using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletGun : MonoBehaviour
{

    public float speed = 3f;
    private Rigidbody2D myBody;
    public int direction = 1;
    private bool shooted = false;
    GameObject Target;



    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        Target = GameObject.Find("Player");
        
       
    }

    // Update is called once per frame
    void Update()
    {
        //Move();
        if (shooted)
            Attack();


    }
    //void Move()
    //{

    //    myBody.velocity = new Vector2(transform.localScale.x, 0) * speed;
       
    //}
    public void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Enemy")
        {
            Destroy(target.gameObject);
            Destroy(gameObject);


        }
    }
    public void Shoot(int dir)
    {
        direction = dir;
        shooted = true;
    }
    void Attack()
    {
        Vector2 Direction = Target.GetComponent<Transform>().position - transform.position;
        float angle = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 2f * Time.deltaTime);

        Vector2 temp = transform.position;
        temp.x += direction * 5 * Time.deltaTime;
        transform.position = temp;
    }
}
