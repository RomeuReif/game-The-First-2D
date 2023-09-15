using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dino : MonoBehaviour
{
    public float velocidade = 2.0f; // Velocidade de movimento
    public float limiteEsquerdo = -5.0f; // Limite esquerdo do movimento
    public float limiteDireito = 5.0f; // Limite direito do movimento

    private bool indoParaDireita = true; // Vari�vel para controlar a dire��o
    Animator dinoAnimator;
    private bool isRunning = false;

    void Start()
    {
        dinoAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        // Verifica se o inimigo atingiu um dos limites e inverte a dire��o
        if (transform.position.x <= limiteEsquerdo)
        {
            indoParaDireita = true;
        }
        else if (transform.position.x >= limiteDireito)
        {
            indoParaDireita = false;
        }

        // Move o inimigo na dire��o apropriada
        if (indoParaDireita)
        {
            transform.Translate(Vector2.right * velocidade * Time.deltaTime);
            transform.localScale = new Vector3(-8f, 8f, 8f); // vira o inimigo para dire�ao que est� correndo
            isRunning = true;
        }
        else
        {
            transform.Translate(Vector2.left * velocidade * Time.deltaTime);
            transform.localScale = new Vector3(8f, 8f, 8f); // vira o inimigo para a dire�ao que est� correndo
            isRunning = true;
        }

    }
}
