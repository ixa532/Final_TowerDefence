using System;
using UnityEngine;

[Serializable]
public class TowerMain  // Classe Tower: Representa uma torre que pode ser construída no jogo.

{
    public string name;     // Nome da torre.
    public int cost;

    public GameObject prefab;    // Prefab da torre, usado para instanciar a torre no jogo.

    public TowerMain(string _name, int _cost, GameObject _prefab)    // Construtor da classe Tower, que inicializa os atributos da torre.

    {
        name = _name;// Inicializa o nome da torre.
        cost = _cost; // Inicializa a Moedinha
        prefab = _prefab; // Inicializa o prefab da torre.

    }
}