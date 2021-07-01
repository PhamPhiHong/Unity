using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class door : MonoBehaviour
{
   
    private Animator anim;
    private BoxCollider2D box;

    public Gamemaster gm;

    // Start is called before the first frame update
    void Start()
    {
        
        anim = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
        gm = GameObject.FindGameObjectWithTag("Gamemaster").GetComponent<Gamemaster>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator DoorOpen()
    {
        anim.Play("open");
        yield return new WaitForSeconds(0.8f);
        SceneManager.LoadScene("Scene2");
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            gm.Inputtext.text = ("Press E to Enter");
        }    
    }


    private void OnTriggerStay2D(Collider2D col)
    {
        if(Input.GetKey(KeyCode.E))
        {
            StartCoroutine(DoorOpen());
            
        }    
    }


    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            gm.Inputtext.text = ("");
        }
    }
}
