using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyGround : MonoBehaviour
{

    //[SerializeField]
    //Transform player;

    //[SerializeField]
    //float argoRange;
 
    //private Transform startPos, endPos;


    private bool collision;

    //private bool collision1;

    public float speed = 3f;


    private Rigidbody2D myBody;

    public GameObject pausePannel;
    //private Gamemaster a;

    [SerializeField]
    private GameObject effect;

    public Gamemaster gm;
    void Awake()
    {
        //a = GetComponent<Gamemaster>();
        myBody = GetComponent<Rigidbody2D>();
        gm = GameObject.FindGameObjectWithTag("Gamemaster").GetComponent<Gamemaster>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        //float distToPlayer = Vector2.Distance(transform.position, player.position);
       
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
        if (target.tag == "Sw")
        {
            gm.points += 1;
            Destroy(this.gameObject);
            Destroy(Instantiate(effect, transform.position, this.transform.rotation), 2);
        }
        if (target.tag == "Player")
        {
            Destroy(target.gameObject);

            pausePannel.SetActive(true);
        }
        if (target.tag == "GunBullet")
        {
            gm.points += 1;
            Destroy(gameObject);
            Destroy(Instantiate(effect, transform.position, this.transform.rotation),2);
        }
       

    }
}
