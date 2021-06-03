using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    GameObject Target;
    void Start()
    {
        Target = GameObject.Find("Player");
    }
    void Update()
    {
        Vector2 Direction = Target.GetComponent<Transform>().position - transform.position;
        float angle = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation =
        Quaternion.Slerp(transform.rotation, rotation, 2f * Time.deltaTime);
    }

}
