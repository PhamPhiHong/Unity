using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemycontroller : MonoBehaviour
{

    public float speed = 2f;
    //public GameObject bullet;
   
    //public GameObject effect;
    [SerializeField]
    private GameObject bullet;

    public Gamemaster gm;

    public GameObject pausePannel;

    void Start()
    {
        StartCoroutine(Attack());
        gm = GameObject.FindGameObjectWithTag("Gamemaster").GetComponent<Gamemaster>();
    }
    // Update is called once per frame
    void Update()
    {
        Move();
        Attack();
    }

    void Move()
    {
        Vector2 temp = transform.position;
        temp.x -= speed * Time.deltaTime;

        transform.position = temp;
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(Random.Range(1,5));
        Instantiate(bullet, transform.position, Quaternion.identity);
        StartCoroutine(Attack());
    }
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
        { 
            Destroy(target.gameObject);
            pausePannel.SetActive(true);
        }

       
        //if (target.tag == "GunBullet")
        //{
        //    Destroy(target.gameObject);
        //    Instantiate(effect, transform.position, Quaternion.identity);


        //}

    }

    //void Attack()
    //{

    //}
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "left")
    //    {

    //        speed = -speed;
    //        Vector2 scale = transform.localScale;
    //        scale.x = -1f;
    //        transform.localScale = scale;

    //    }
    //    if (collision.gameObject.tag == "right")
    //    {
    //        speed = -speed;
    //        Vector2 scale = transform.localScale;
    //        scale.x = 1f;
    //        transform.localScale = scale;

    //    }
    //    if (collision.gameObject.tag == "bullet")
    //    {
    //        Destroy(gameObject);
    //        Destroy(Instantiate(effect, transform.position, this.transform.rotation), 2);
    //    }

    //}

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "left")
    //    {

    //        speed = -speed;
    //        Vector2 scale = transform.localScale;
    //        scale.x = -1f;
    //        transform.localScale = scale;
    //        Debug.Log("Left");
    //    }
    //    if (collision.gameObject.tag == "right")
    //    {
    //        speed = -speed;
    //        Vector2 scale = transform.localScale;
    //        scale.x = 1f;
    //        transform.localScale = scale;
    //        Debug.Log("Left");
    //    }
    //}


}
