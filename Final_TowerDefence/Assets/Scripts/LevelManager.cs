using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance; //Permite o acesso � �nica inst�ncia do LevelManager

    public Transform startPoint;//Transform que define o ponto inicial do n�vel, usado para spawnar o �nicio do caminho  
    public Transform[] caminho; // Array de Transform que define os pontos de um caminho a ser seguido 
    public List<Transform> inimigos = new List<Transform>(); //Lista de inimigos ativa 
    public int currency;
    [SerializeField] TextMeshProUGUI currencyText;
    
    private void Awake() //M�todo Awake, chamado qaundo o objeto � criado, antes do Start
    {
        instance = this; // Define esta inst�ncia de LevelManager como a �nica inst�ncia acess�vel
    }
    public void IncrementarMoedas(int amount)
    {
        currency += amount;
    }
    public bool SpendCurrency(int amount) // Gastar o dinheiro
    {
        if (amount <= currency) // se a quantidade � menor ou igual a moeda
        {
            currency -= amount; // moeda  menor ou igual a quantidade
            return true; // retorna verdadeiro
        }
        else
        {
            Debug.Log("Sem dinheiro"); // mostra no console a linda mensagem escrita 
            return false;    //retorna falso
        }
    }

        // M�todo que permite adicionar um inimigo � lista de inimigos.
        // Recebe um Transform representando o inimigo a ser adicionado.
        public void AddEnemy(Transform inimigo)
        {
            inimigos.Add(inimigo);// Adiciona o transform do inimigo � lista de inimigos.
        }

        //M�todo p�blico que permite remover um inimigo da lista de inimigos.
        // Recebe um Transform representando o inimigo que deve ser removido.
        public void RemoveEnemy(Transform inimigo)
        {
            inimigos.Remove(inimigo);//Remove o transform do inimigo da lista de inimigos.

           
        }
}
