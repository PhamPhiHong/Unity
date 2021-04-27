using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = 3f;
    private float direction;
    private GameObject boss;
    void Awake()
    {
        boss = GameObject.Find("Boss");
        direction = -boss.transform.localScale.x;
        Vector2 scale = transform.localScale;
        scale.x = direction;
        transform.localScale = scale;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 pos = this.transform.position;
        pos.x += direction * speed * Time.deltaTime;
        transform.position = pos;
    }
   

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "GunBullet")
        {
            Destroy(gameObject);
        }
    }
}
