using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance; //Permite o acesso � �nica inst�ncia do LevelManager

    public Transform startPoint;//Transform que define o ponto inicial do n�vel, usado para spawnar o �nicio do caminho  
    public Transform[] caminho; // Array de Transform que define os pontos de um caminho a ser seguido 
    public List<Transform> inimigos = new List<Transform>(); //Lista de inimigos ativa 
    
    private void Awake() //M�todo Awake, chamado qaundo o objeto � criado, antes do Start
    {
        instance = this; // Define esta inst�ncia de LevelManager como a �nica inst�ncia acess�vel
    }

    public void AddEnemy(Transform inimigo)
    { 
        inimigos.Add(inimigo);
    }

}
