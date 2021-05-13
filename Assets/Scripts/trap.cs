using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap : MonoBehaviour
{
    public Rigidbody2D r2;
    public float timedeplay;
    // Start is called before the first frame update
    void Start()
    {
        r2 = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Player"))
        {
            StartCoroutine(fall());
        }
    }
    IEnumerator fall()
    {
        yield return new WaitForSeconds(timedeplay = 0);
        r2.bodyType = RigidbodyType2D.Dynamic;
        yield return 0;
    }
}