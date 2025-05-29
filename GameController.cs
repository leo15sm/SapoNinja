using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int totalScore;
    public Text scoreText;
    public Text timeText;
    public float time = 0f;
    public int tempo = 0;
    public static GameController instance;
    public GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
    }
    
    //Metodo que atualiza o Score
    public void UpdateScoreText()
    {
        scoreText.text = totalScore.ToString();
    }
    
    //Metodo que atualiza o Tempo
    public void UpdateTimeText()
    {
        tempo = Mathf.FloorToInt(time);
        timeText.text = tempo.ToString();
    }

    //Metodo que chama o Game Over
    public void ShowGameOver()
    {
        gameOver.SetActive(true);
    }

    //Método para Resetar o Jogo
    public void RestartGame(string lvlName)
    {
        SceneManager.LoadScene(lvlName);
    }
}