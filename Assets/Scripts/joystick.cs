using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class joystick : MonoBehaviour,IPointerUpHandler, IPointerDownHandler
{
    private playercontroller player;
    public void OnPointerDown(PointerEventData eventData)
    {
      
        if (gameObject.name == "Left")
        {
            player.MoveLeft(true);
            //player.PlayerJoystick();
        }
        if (gameObject.name == "Right")
        {
            player.MoveLeft(false);
            //player.PlayerJoystick();
        }

        if (gameObject.name == "Jump")
        {
            player.Jump();
            //player.PlayerJoystick();
        }

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        player.StopMoving();
    }

    void Awake()
    {
       
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<playercontroller>();

    }

    // Update is called once per frame
    void Update()
    {

    }
}
