using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public float MoveForce = 20f;
    public float MaxVelocity = 5f;
    public float Jumpforce = 200f;
    public bool grounded = true;

    private Rigidbody2D mybody;
    private Animator anim;

    public SpriteRenderer rend;

    private bool moveLeft = false;
    private bool moveRight = false;

    [SerializeField]
    private GameObject bullet;



    void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();

        //GameObject.Find("Jump").GetComponent<Button>().onClick.AddListener(() => Jump());
        //GameObject.Find("Jump").GetComponent<Button>().onClick.AddListener(Jump);

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
            Instantiate(bullet, transform.position, Quaternion.identity);

        }
        PlayerJoystick();

       
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
                anim.SetBool("Move",true);
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
        if(target.tag == "Bullet")
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
        for (float f = 1f; f > -0.05f; f-=0.05f)
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










    void PlayerJoystick()
    {
        float forceX = 0;
        float forceY = 0;
        float vel = Mathf.Abs(mybody.velocity.x);

        if (vel < MaxVelocity)
        {
            Vector3 temp = transform.localScale;
            if (moveRight)
            {
                temp.x = 1f;
                forceX = MoveForce;
                anim.SetBool("Move", true);
                anim.SetBool("Jump", false);
            }
            else if (moveLeft)
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
        mybody.AddForce(new Vector2(forceX, forceY));
    }

    public void Jump()
    {
        
        if (grounded)
        {
            grounded = false;
            mybody.AddForce(new Vector2(0, 500f));
            anim.SetBool("Jump", true);
        }
    }
    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Floor")
        {
            grounded = true;
        }
    }
    public void MoveLeft(bool left)
    {
        moveLeft = left;
        moveRight = !left;
    }
    public void StopMoving()
    {
        moveLeft = moveRight = false;
    }
}
