using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gamemaster : MonoBehaviour
{
    // Start is called before the first frame update
    public int points = 0;


    public Text pointtext;

    public Text Inputtext;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pointtext.text = ("Points: " + points);
    }
}
