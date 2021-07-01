using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public float MoveForce = 20f;
    public float MaxVelocity = 5f;
    public float Jumpforce = 200f;
    public bool grounded = true;
    public bool spotted = false;
    public Transform startSight, endSight;
    private int numberBullet = 10;
    private float timeDelay = 0;


    private Rigidbody2D mybody;
    private Animator anim;

    public SpriteRenderer rend;

    //private bool moveLeft = false;
    //private bool moveRight = false;

    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private GameObject bullet1;



    void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();

       

    }
    // Start is called before the first frame update
    void Start()
    {

        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerWalkKeyboard();

        if (Input.GetKey("z"))
        {
            
            //anim.SetBool("Shoot", true);
            //Instantiate(bullet1,transform.position, Quaternion.identity);
            if (gameObject.transform.localScale.x > 0)
            {
                GameObject a1 = Instantiate(bullet1, new Vector2(gameObject.transform.position.x + 0.91f, gameObject.transform.position.y - 0.28f), Quaternion.identity);
                a1.GetComponent<GunBul2>().Shoot(1);
            }
            else
            {
                GameObject a1 = Instantiate(bullet1, new Vector2(gameObject.transform.position.x + 0.91f, gameObject.transform.position.y - 0.28f), Quaternion.identity);
                a1.GetComponent<GunBul2>().Shoot(-1);
            }
        }
        //PlayerJoystick();
        Debug.DrawLine(startSight.position, endSight.position, Color.red);
        spotted = Physics2D.Linecast(startSight.position, endSight.position, 1 <<
        LayerMask.NameToLayer("enemy"));
        timeDelay += Time.deltaTime;
        if (timeDelay > 0.5f && spotted && numberBullet > 0)
        {
            Attack();
            timeDelay = 0;
        }


    }
    void Attack()
    {
        numberBullet--;
        if (gameObject.transform.localScale.x > 0)
        {
          
            GameObject body = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            body.GetComponent<bulletGun>().Shoot(1);
        }
        else
        {
            GameObject body = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 180)));
            body.GetComponent<bulletGun>().Shoot(-1);
        }
    }

    void PlayerWalkKeyboard()
    {
        float forceX = 0;
        float forceY = 0;
        float vel = Mathf.Abs(mybody.velocity.x);

        float h = Input.GetAxisRaw("Horizontal");


        if (vel < MaxVelocity)
        {
            Vector3 temp = transform.localScale;
            if (h > 0)
            {
                temp.x = 1f;
                forceX = MoveForce;
                anim.SetBool("Move", true);
                anim.SetBool("Jump", false);


            }
            else if (h < 0)
            {
                temp.x = -1f;
                forceX = -MoveForce;
                anim.SetBool("Move", true);
                anim.SetBool("Jump", false);

            }
            else
            {
                anim.SetBool("Move", false);
                anim.SetBool("Jump", false);
            }
            transform.localScale = temp;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (grounded)
            {
                grounded = false;
                forceY = 100f;
                mybody.AddForce(new Vector2(0, forceY));
                anim.SetBool("Jump", true);
            }
            else
            {
                grounded = true;
                forceY = 0;
                mybody.AddForce(new Vector2(0, forceY));
                anim.SetBool("Jump", false);

            }
        }
        mybody.AddForce(new Vector2(forceX, forceY));
    }


    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Bullet")
        {
            anim.SetBool("Hurt", true);
            StartCoroutine(Hurt());
        }
        else
        {
            anim.SetBool("Hurt", false);
        }
    }

    IEnumerator Hurt()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

    IEnumerator Faded()
    {
        for (float f = 1f; f > -0.05f; f -= 0.05f)
        {
            Color color = rend.material.color;
            color.a = f;
            rend.material.color = color;
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void StartFading()
    {
        StartCoroutine(Faded());
    }










    //void PlayerJoystick()
    //{
    //    float forceX = 0;
    //    float forceY = 0;
    //    float vel = Mathf.Abs(mybody.velocity.x);

    //    if (vel < MaxVelocity)
    //    {
    //        Vector3 temp = transform.localScale;
    //        if (moveRight)
    //        {
    //            temp.x = 1f;
    //            forceX = MoveForce;
    //            anim.SetBool("Move", true);
    //            anim.SetBool("Jump", false);
    //        }
    //        else if (moveLeft)
    //        {
    //            temp.x = -1f;
    //            forceX = -MoveForce;
    //            anim.SetBool("Move", true);
    //            anim.SetBool("Jump", false);
    //        }
    //        else
    //        {
    //            anim.SetBool("Move", false);
    //            anim.SetBool("Jump", false);
    //        }
    //        transform.localScale = temp;
    //    }
    //    mybody.AddForce(new Vector2(forceX, forceY));
    //}

    //public void Jump()
    //{

    //    if (grounded)
    //    {
    //        grounded = false;
    //        mybody.AddForce(new Vector2(0, 500f));
    //        anim.SetBool("Jump", true);
    //    }
    //}
    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Floor")
        {
            grounded = true;
        }
    }
    //public void MoveLeft(bool left)
    //{
    //    moveLeft = left;
    //    moveRight = !left;
    //}
    //public void StopMoving()
    //{
    //    moveLeft = moveRight = false;
    //}
}
