using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance; //Permite o acesso à única instância do LevelManager

    public Transform startPoint;//Transform que define o ponto inicial do nível, usado para spawnar o ínicio do caminho  
    public Transform[] caminho; // Array de Transform que define os pontos de um caminho a ser seguido 
    public List<Transform> inimigos = new List<Transform>(); //Lista de inimigos ativa 
    
    private void Awake() //Método Awake, chamado qaundo o objeto é criado, antes do Start
    {
        instance = this; // Define esta instância de LevelManager como a única instância acessível
    }

    public void AddEnemy(Transform inimigo)
    { 
        inimigos.Add(inimigo);
    }

}
