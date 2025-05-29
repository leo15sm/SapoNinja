using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jump;
    public bool isJump;
    public bool doubleJump;
    public float sleep=0;
    public float rl=0;
   
    private bool expandido = false;
    private Vector3 escalaOriginal;
    private Rigidbody2D rig;
    private Animator anim;
    public static Player instance;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        escalaOriginal = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        GameController.instance.UpdateTimeText();
    }

    //Função de movimentação
    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * speed;
        
        if(Input.GetAxis("Horizontal") > 0f) //andando para direita
        {
            rl=0;
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, rl, 0f);
        }
        
        if(Input.GetAxis("Horizontal") < 0f) //andando para esquerda
        {
            rl=180;
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, rl, 0f);
        }
        
        if(Input.GetAxis("Horizontal") == 0f) //parado
        {
            anim.SetBool("walk", false);
        }
        
        if(Input.GetKeyDown ( KeyCode.Alpha0) && !isJump) //dormindo
        {
            sleep += 90;
            transform.eulerAngles = new Vector3(0f, rl, sleep);
        }
    }

    //Função de pulo e pulo duplo
    void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            sleep=0;
            transform.eulerAngles = new Vector3(0f, rl, 0f);
            if(!isJump)
            {
                rig.AddForce(new Vector2(0f, jump), ForceMode2D.Impulse);
                doubleJump = true;
                anim.SetBool("jump", true);
            }
            else if(doubleJump)
            {
                rig.AddForce(new Vector2(0f, jump), ForceMode2D.Impulse);
                doubleJump = false;
                anim.SetBool("jumpx2", true);
            }
        }
    }

    //Verifica se esta tocando o layer solo
    void OnCollisionEnter2D(Collision2D colidir)
    {
        if(colidir.gameObject.layer == 6)
        {
            isJump = false; 
            anim.SetBool("jump", false);
            anim.SetBool("jumpx2", false);
        }
        
        //Chamada de Game Over
        if(colidir.gameObject.tag == "Spike")
        {
            GameController.instance.ShowGameOver();
            Destroy(gameObject);
        }
    }   
    
    //Verifica se não esta tocando o layer solo
    void OnCollisionExit2D(Collision2D colidir)
    {
        if(colidir.gameObject.layer == 6)
        {
             isJump = true;     
        }
    }

    //Função de escala
    public void Escala()
    {
         // Alternar entre expandir e comprimir o personagem
        if (expandido)
        {
            // Comprimir o personagem para a escala original
            transform.localScale = escalaOriginal;
            expandido = false;
            }
        
        else
        {
            // Expandir o personagem
            transform.localScale = escalaOriginal * 2f; //ajusta o valor do multiplicador conforme necessário
            expandido = true;
        }   
    }
}

