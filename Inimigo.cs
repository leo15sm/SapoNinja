using UnityEngine;



public class Inimigo : MonoBehaviour
{
    private Rigidbody2D rig;
    private Animator anim;

    public float speed; // Velocidade do inimigo
    public Transform rightCol;
    public Transform leftCol;
    public Transform headPoint; // Ponto de verificação para colisão com a cabeça

    private bool colliding;
    public LayerMask layer; // Camada para verificar colisões

    public BoxCollider2D boxCollider; // Collider do inimigo
    public CircleCollider2D circleCollider; // Collider do inimigo

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rig.linearVelocity = new Vector2(speed, rig.linearVelocity.y);

        colliding = Physics2D.Linecast(rightCol.position, leftCol.position, layer);

        if (colliding)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y); // Inverte a escala do inimigo
            speed *= -1f; // Inverte a direção do inimigo
        }
    }
    
    void OnCollisionEnter2D(Collision2D colidir)
    {
        if (colidir.gameObject.tag == "Player")
        {
            float height = colidir.contacts[0].point.y - headPoint.position.y; // Calcula a altura do contato

            if (height > 0f)
            {
                colidir.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10, ForceMode2D.Impulse); // Aplica uma força de impulso para cima no jogador
                speed = 0;
                anim.SetTrigger("die"); // Ativa a animação de morte do inimigo
                boxCollider.enabled = false; // Desabilita o BoxCollider do inimigo
                circleCollider.enabled = false; // Desabilita o CircleCollider do inimigo
                rig.bodyType = RigidbodyType2D.Kinematic; // Define o Rigidbody do inimigo como estático
                Destroy(gameObject, 0.33f); // Destroi o inimigo após 0.33 segundos
            }
            else
            {
                GameController.instance.ShowGameOver();
                Destroy(colidir.gameObject);
            }
        }
    }
}
