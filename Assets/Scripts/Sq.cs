using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sq : MonoBehaviour
{
    // Start is called before the first frame update

    public Gamemaster gm;
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("Gamemaster").GetComponent<Gamemaster>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Enemy")
        {
            gm.points += 1;
            Destroy(target.gameObject);
            Destroy(gameObject);
        }
    }
}
