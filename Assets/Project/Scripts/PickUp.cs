using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickUp : MonoBehaviour
{
    private GerenciadorDeDiamantes gerenciadorDeDiamantes;

    private void Start()
    {
        gerenciadorDeDiamantes = FindObjectOfType<GerenciadorDeDiamantes>();
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if (gerenciadorDeDiamantes != null)
            {
                gerenciadorDeDiamantes.IncrementarDiamantes();
            }

        }

        Destroy(gameObject);
    }


}
