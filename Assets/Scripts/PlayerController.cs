using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //PlayerController
    public float speed; //Velocidade do jogador
    private Rigidbody2D body; //Recebe as propriedades do Rigidbody do jogador;
    private Animator anim; //Recebe as configurações do Animator do jogador
    private Vector2 axisMove; //É utilizado para gerenciar os inputs;
    private SpriteRenderer sprite; //Recebe as propriedades do render do jogador;

    void Start()
    {
        body = GetComponentInChildren<Rigidbody2D>(); //Pega o as confirgurações do Rigidbody e insere na variavel.
        anim = GetComponentInChildren<Animator>();//Pega o as confirgurações do Animator e insere na variavel.
        sprite = GetComponentInChildren<SpriteRenderer>();//Pega o as confirgurações do SpriteRenderer e insere na variavel.
    }

    void Update()
    {
        Movemente(); //Chama o metódo de movimentação
        Animations(); //Chama o metódo de animação
    }

    void Movemente()
    {
        //Pega os inputs do teclado e associa ao Vector2 axisMove;
        axisMove.x = Input.GetAxisRaw("Horizontal");
        axisMove.y = Input.GetAxisRaw("Vertical");

        body.velocity = axisMove * speed; //Movimenta o player usando a sua velocidade.

        //Inverte o sprite do player depende para onde ele anda
        if(body.velocity.x < 0)
            sprite.flipX = true;
        else if (body.velocity.x > 0)
            sprite.flipX = false;
    }

    void Animations()
    {
        //Troca a animação dependendo do movimento do player
        anim.SetBool("Run", body.velocity.x != 0 || body.velocity.y != 0);
    }
}
