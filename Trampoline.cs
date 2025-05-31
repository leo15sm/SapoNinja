using UnityEngine;

public class trampoline : MonoBehaviour
{
    public float jumpForce; // Força do pulo do trampolim
    private Animator anim;

    void Start()
    {
        // Obtém o componente Animator do objeto
        anim = GetComponent<Animator>();
    }
    
    void OnCollisionEnter2D(Collision2D colidir)
    {
        //Checar se o objeto colidido é o Player
        if (colidir.gameObject.tag == "Player")
        {
            colidir.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            anim.SetTrigger("jump"); // Ativa a animação de pulo do trampolim
        }
    }   
    
}
