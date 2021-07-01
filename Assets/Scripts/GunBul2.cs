using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBul2 : MonoBehaviour
{
    public float speed = 3f;
    private Rigidbody2D myBody;
    public int direction = 1;
    private bool shooted = false;
    GameObject Target;
    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        Target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

        if (shooted)
            Move();
    }
    void Move()
    {
        //Vector2 temp = transform.position;
        //temp.x -= speed * Time.deltaTime;

        //transform.position = temp;
        //myBody.velocity = new Vector2(transform.localScale.x, 0) * speed;
        Vector2 temp = transform.position;
        temp.x += direction * 5 * Time.deltaTime;
        transform.position = temp;

    }
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
}
