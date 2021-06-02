using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField]
    public float movespeed = 1f;
    private Vector3 startPos, endPos;
    private Vector3 nextPos;
    [SerializeField]
    private Transform PosB;
    private Animator anim;
    [SerializeField]
    // Use this for initialization
    private float TimeAttack = 0;
    private bool normalAttack = true;
    [SerializeField]
    private GameObject zoombie;
    void Awake()
    {

    }
    void Start()
    {
        anim = GetComponent<Animator>();
        startPos = transform.localPosition;
        endPos = PosB.localPosition;
        nextPos = endPos;
        StartCoroutine(Spawner());
    }
    void Running()
    {
        //anim.SetTrigger("Move");
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, nextPos, movespeed *Time.deltaTime);
        if (Vector3.Distance(transform.localPosition, nextPos) <= 0.1)
        {
            ChangeDirection();
            Vector3 temp = transform.localScale;
            temp.x *= -1;
            transform.localScale = temp;
        }
    }
    void ChangeDirection()
    {
        nextPos = nextPos != startPos ? startPos : endPos;
    }
    void CheckAttack()
    {
        TimeAttack += Time.deltaTime;
        if (TimeAttack > 10f)
        {
            anim.SetTrigger("HeavyAtt");
            TimeAttack = 0;
            normalAttack = true;
        }
        if (TimeAttack > 5f && normalAttack)
        {
            anim.SetTrigger("NormalAtt");
            normalAttack = false;
        }
    }
    // Update is called once per frame
    void LateUpdate()
    {
        Running();
        CheckAttack();
    }

    IEnumerator Spawner()
    {
        yield return new WaitForSeconds(2f);
        Vector2 pos = transform.position;
        pos.x -= transform.localScale.x;
        Instantiate(zoombie, pos, transform.rotation);
        StartCoroutine(Spawner());
    }

}
