using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour//classe que gerencia a seleçaão e configuração das torres 
{
    public static Building Instance; // instancia estatica da classe para permitir o aceso global a seleção das torres
    [SerializeField] private Tower[] towers; //Array de torres disponivel para seleção

    private int selectedTower = 0; //índice da torre selecionada 

    //Retorna a torre atualmente selecionada
    public Tower GetSelectedTower()
    {
        return towers[selectedTower];
    }

    public void SetSelectedTower(int _selectedTower)
    {
        selectedTower = _selectedTower;
    }
    private void Awake()
    {
        Instance = this;
    }
}
