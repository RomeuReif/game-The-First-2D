using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; //Importando input system
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] float playerVida = 100.0f;
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] float ladderSpeed = 5f;
    string Stage01;
    float initialGravity;
    public GerenciadorDeJogo gerenciador;

    Rigidbody2D rb; // Declarando o rigibody2D
    Vector2 movementInput;
    Animator playerAnimator; // Pegar o animator
    CapsuleCollider2D playerCapsuleCollider;
    BoxCollider2D feetBoxCollider;
    bool isJumping = false;
    bool isLadder = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Pegando o rigibody sempre quando inicia
        playerAnimator = GetComponent<Animator>(); 
        playerCapsuleCollider = GetComponent<CapsuleCollider2D>();
        feetBoxCollider = GetComponent<BoxCollider2D>();
        initialGravity = rb.gravityScale;

    }

    void Update()
    {
        Jump();
        Run();
        SpriteFlip();
        Ladder();
        OnLimbo();
        Morte();
        playerCapsuleCollider = GetComponent<CapsuleCollider2D>();
        feetBoxCollider = GetComponent<BoxCollider2D>();
    }

    private void Ladder()
    {
        if(!playerCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("escadas")))
        {
            playerAnimator.SetBool("isLadder", false);
            rb.gravityScale = 2f;
            return;
        }

        Vector2 playerLadderSpeed = new Vector2(rb.velocity.x, movementInput.y * ladderSpeed);
        rb.velocity = playerLadderSpeed;
        rb.gravityScale = 0.8f;
        playerAnimator.SetBool("isLadder", true);
    }

    void OnMove(InputValue value)
    {
        movementInput = value.Get<Vector2>(); // Pegando as teclas que forem pressionadas
    }

    void OnJump(InputValue value)
    {
        if (!IsOnGround())
        {
            return;
        }

        if (value.isPressed)
        {
            rb.velocity = new Vector2(0f, jumpForce);
            isJumping = true;
        }
    }

    void Jump()
    {
        if(isJumping && !IsOnGround())
        {
            playerAnimator.SetBool("isJumping", true);
            
        } 
        else if (isJumping && IsOnGround())
        {
            playerAnimator.SetBool("isJumping", false);
        }
    }

    private bool IsOnGround()
    {
        return feetBoxCollider.IsTouchingLayers(LayerMask.GetMask("Ground"));
    }

    void Run() // Fazer o movimento para os lados
    {
        Vector2 playerSpeed = new Vector2(movementInput.x * speed, rb.velocity.y); 
        rb.velocity = playerSpeed;
        // Mudando a animaçao para corrida
        bool playerHasxSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        playerAnimator.SetBool("isRunning", playerHasxSpeed);
    }

    void SpriteFlip() // Personagem virar para outro lado
    {
        float scaleX = (Mathf.Sign(rb.velocity.x)) * 8f;
        float scaleY = 8f;

        bool playerHasxSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;

        if (playerHasxSpeed)
        {
            transform.localScale = new Vector2(scaleX, scaleY); 
        }
    }

    void OnLimbo()
    {
        if (feetBoxCollider.IsTouchingLayers(LayerMask.GetMask("limbo")))
        {
            playerVida = 0;
            return;
        }
    }

    void Morte()
    {
        if(playerVida == 0)
        {
            gerenciador.PersonagemMorreu();
            SceneManager.LoadScene("Menu");
        }
    }

}
