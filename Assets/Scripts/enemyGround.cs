using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyGround : MonoBehaviour
{


 
    //private Transform startPos, endPos;


    private bool collision;

    //private bool collision1;

    public float speed = 3f;


    private Rigidbody2D myBody;

    [SerializeField]
    private GameObject effect;
   

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        //ChangDirection();
    }
    void Move()
    {
        myBody.velocity = new Vector2(transform.localScale.x, 0) * -speed;
    }

    //void ChangDirection()
    //{
    //    collision = Physics2D.Linecast(startPos.position, endPos.position, 1 << LayerMask.NameToLayer("tree"));
    //    //collision1 = Physics2D.Linecast(startPos.position, endPos.position, 1 << LayerMask.NameToLayer("ground"));

    //    if (collision)
    //    {
    //        Vector2 temp = transform.localScale;
    //        if (temp.x == -1f)
    //        { temp.x = 1f; }
    //        transform.localScale = temp;
    //    }
    //    //if (!collision1)
    //    //{
    //    //    Vector3 temp = transform.localScale;
    //    //    if (temp.x == 1f) { temp.x = -1f; }
    //    //    else { temp.x = 1f; }
    //    //    transform.localScale = temp;
    //    //}
    //}

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
        { 
            Destroy(target.gameObject); 
        }


        if (target.tag == "GunBullet")
        {
            Destroy(gameObject);
            Destroy(Instantiate(effect, transform.position, this.transform.rotation),2);
        }    

    }
}
