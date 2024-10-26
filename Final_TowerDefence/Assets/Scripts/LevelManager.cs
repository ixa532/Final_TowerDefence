using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance; //Permite o acesso � �nica inst�ncia do LevelManager

    public Vector3 startPoint; // Ponto inicial, onde o jogo inicia
    public Vector3[] caminho; //Array de pontos que define o caminho que ser� seguido nio n�vel

    private void Awake() //M�todo Awake, chamado qaundo o objeto � criado, antes do Start
    {
        instance = this; // Define esta inst�ncia de LevelManager como a �nica inst�ncia acess�vel
    }
}
