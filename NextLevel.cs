using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public string nextLevelName;

    void OnCollisionEnter2D(Collision2D colidir)
    {
        if(colidir.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(nextLevelName);
        }
    }  
}
