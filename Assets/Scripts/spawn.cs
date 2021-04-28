using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;

    public int a;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(CreateEnemy());
        StartCoroutine(CreateEnemy1());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CreateEnemy()
    {
        yield return new WaitForSeconds(1);

        Vector2 temp = transform.position;
        temp.y += Random.Range(-2, 2);

        Instantiate(enemy, temp, this.transform.rotation);

       
    }

    IEnumerator CreateEnemy1()
    {
        yield return new WaitForSeconds(a);

        Vector2 temp = transform.position;
        temp.y += Random.Range(-2, 2);

        Instantiate(enemy, temp, this.transform.rotation);

        StartCoroutine(CreateEnemy1());
    }
}
