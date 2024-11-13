using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Building : MonoBehaviour//classe que gerencia a sele�a�o e configura��o das torres 
{
    public static Building intance; // instancia estatica da classe para permitir o aceso global a sele��o das torres
    [SerializeField] private TowerMain[] towers; //Array de torres disponivel para sele��o

    private int selectedTower = 0; //�ndice da torre selecionada 

    //Retorna a torre atualmente selecionada
    public TowerMain GetSelectedTower()
    {
        return towers[selectedTower];//Acessa a lista ou array 'towers' usando o �ndice 'selectedTower' // e retorna a torre armazenada nessa posi��o.
    }

    public void SetSelectedTower(int _selectedTower)// M�todo p�blico que define a torre selecionada com base em um �ndice fornecido.

    {
        selectedTower = _selectedTower;// Atribui o valor do par�metro '_selectedTower' � vari�vel 'selectedTower'// atualizando qual torre est� selecionada.

    }
    private void Awake()//usado para configurar uma inst�ncia �nica (singleton) da classe
    {
        intance = this;// Define a vari�vel est�tica 'Instance' como esta inst�ncia da classe permitindo que outros scripts acessem a inst�ncia facilmente.
    }
}
