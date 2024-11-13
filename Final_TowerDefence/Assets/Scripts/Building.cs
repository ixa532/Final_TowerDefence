using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Building : MonoBehaviour//classe que gerencia a seleçaão e configuração das torres 
{
    public static Building intance; // instancia estatica da classe para permitir o aceso global a seleção das torres
    [SerializeField] private TowerMain[] towers; //Array de torres disponivel para seleção

    private int selectedTower = 0; //índice da torre selecionada 

    //Retorna a torre atualmente selecionada
    public TowerMain GetSelectedTower()
    {
        return towers[selectedTower];//Acessa a lista ou array 'towers' usando o índice 'selectedTower' // e retorna a torre armazenada nessa posição.
    }

    public void SetSelectedTower(int _selectedTower)// Método público que define a torre selecionada com base em um índice fornecido.

    {
        selectedTower = _selectedTower;// Atribui o valor do parâmetro '_selectedTower' à variável 'selectedTower'// atualizando qual torre está selecionada.

    }
    private void Awake()//usado para configurar uma instância única (singleton) da classe
    {
        intance = this;// Define a variável estática 'Instance' como esta instância da classe permitindo que outros scripts acessem a instância facilmente.
    }
}
