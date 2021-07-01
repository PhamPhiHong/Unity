using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerSword : MonoBehaviour
{
    public float MoveForce = 20f;
    public float MaxVelocity = 5f;
    public float Jumpforce = 220f;
    public bool grounded = true;
    //public AudioSource audioSource;
    //public AudioClip AudioJump;
    //public AudioClip AudioHit;

    private Rigidbody2D mybody;
    private Animator anim;

    public SpriteRenderer rend;

    [SerializeField]
    private GameObject Sword;

    //private bool moveLeft = false;
    //private bool moveRight = false;

  
    void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
        //audioSource = GetComponent<AudioSource>();
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
        anim.SetBool("Ground", grounded);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            if (grounded)
            {
                grounded = false;
                //audioSource.PlayOneShot(AudioJump,0.3f);
                mybody.AddForce(Vector2.up*Jumpforce);
                
            }
        }
        if (Input.GetKey("z"))
        {

            //audioSource.PlayOneShot(AudioHit);
            Destroy(Instantiate(Sword, new Vector2(transform.position.x + 0.57f, transform.position.y), Quaternion.identity), 1f);
            anim.SetBool("Hit", true);
        }
        else
        {
            anim.SetBool("Hit", false);
        }

        //PlayerJoystick();


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
                //audioSource.mute = false;
                //audioSource.Play();
                anim.SetBool("Move", true);
               


            }
            else if (h < 0)
            {
                temp.x = -1f;
                forceX = -MoveForce;
                //audioSource.mute = false;
                //audioSource.Play();
                anim.SetBool("Move", true);
               

            }
            else
            {
                anim.SetBool("Move", false);
               
            }
            transform.localScale = temp;
        }

        
       
        mybody.AddForce(new Vector2(forceX, forceY));
    }


    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "Floor")
        {
            grounded = true;
        }
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
     void OnTriggerExit2D(Collider2D collision)
    {
       
            //grounded = false;
        
    }

    IEnumerator Hurt()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

    //IEnumerator Faded()
    //{
    //    for (float f = 1f; f > -0.05f; f -= 0.05f)
    //    {
    //        Color color = rend.material.color;
    //        color.a = f;
    //        rend.material.color = color;
    //        yield return new WaitForSeconds(0.05f);
    //    }
    //}

    //public void StartFading()
    //{
    //    StartCoroutine(Faded());
    //}


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
