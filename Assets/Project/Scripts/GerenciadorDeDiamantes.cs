using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GerenciadorDeDiamantes : MonoBehaviour
{
    private int diamantesColetados = 0;
    public TextMeshProUGUI contadorDeDiamantes;

    public void IncrementarDiamantes()
    {
        diamantesColetados++;
        AtualizarContadorDeDiamantes();
    }

    private void AtualizarContadorDeDiamantes()
    {
        if (contadorDeDiamantes != null)
        {
            contadorDeDiamantes.text =  diamantesColetados.ToString();
        }
    }
}