using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
   
    public int score;   
    public GameObject collected;
    private SpriteRenderer sr;
    private CircleCollider2D circle;

    // Start is called before the first frame update
    void Start()
    { 
        sr = GetComponent<SpriteRenderer>();
        circle = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Verifica colisão
    void OnTriggerEnter2D(Collider2D colidir)
    {
        if(colidir.gameObject.tag == "Player")
        {
            sr.enabled = false;
            circle.enabled = false;
            collected.SetActive(true);

            GameController.instance.totalScore += score;
            GameController.instance.UpdateScoreText();
            Player.instance.Escala();
            
            if(GameController.instance.totalScore == 100)
            {
                GameController.instance.RestartGame("EndGame");
            }

            Destroy(gameObject, .5f);
        }
    }  
}
