using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gamemaster : MonoBehaviour
{
    // Start is called before the first frame update
    public int points = 0;

  

    public Text pointtext;

    public Text Inputtext;

    public GameObject pausePannel;


    public Button ButtonRestart;
   
    void Start()
    {
        pausePannel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        pointtext.text = ("Points: " + points);
    }


    public void PlayerDie()
    {
        pausePannel.SetActive(true);
    }
    public void ResumeGame()
    {
        pausePannel.SetActive(false);
        SceneManager.LoadScene("SampleScene 2");
    }


}
