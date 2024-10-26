using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance; //Permite o acesso à única instância do LevelManager

    public Vector3 startPoint; // Ponto inicial, onde o jogo inicia
    public Vector3[] caminho; //Array de pontos que define o caminho que será seguido nio nível

    private void Awake() //Método Awake, chamado qaundo o objeto é criado, antes do Start
    {
        instance = this; // Define esta instância de LevelManager como a única instância acessível
    }
}
