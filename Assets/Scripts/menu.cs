using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
  

    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene 2");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        { SceneManager.LoadScene("Scene2"); }    
     
    }


}
