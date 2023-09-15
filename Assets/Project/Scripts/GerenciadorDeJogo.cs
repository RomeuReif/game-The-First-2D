using UnityEngine;
using UnityEngine.SceneManagement;

public class GerenciadorDeJogo : MonoBehaviour
{
    public string Stage01; // O nome da cena que você deseja reiniciar

    // Chame este método quando o personagem morrer
    public void PersonagemMorreu()
    {
        // Carrega a cena atual novamente para reiniciar o jogo
        SceneManager.LoadScene(Stage01);
    }
}
