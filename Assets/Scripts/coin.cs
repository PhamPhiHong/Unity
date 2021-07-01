using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{

    public Gamemaster gm;
    public GameObject floatingPoints;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("Gamemaster").GetComponent<Gamemaster>();
    }

    // Update is called once per frame
    void Update()
    {
            
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            Instantiate(floatingPoints,transform.position,Quaternion.identity);
            Destroy(this.gameObject);
            gm.points += 1;
        }    
    }
}
