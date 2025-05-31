using UnityEngine;

public class Saw : MonoBehaviour
{
    public float speed; // Velocidade de movimento da serra
    public float distance; // Distância máxima que a serra pode se mover
    public bool move; // Direção do movimento (true = direita, false = esquerda)
    private float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        timer += Time.deltaTime;
        if (timer >= distance)
        {
            move = !move; // Inverte a direção do movimento
            timer = 0f; // Reseta o timer
        }
    }
}
