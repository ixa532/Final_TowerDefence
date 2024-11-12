
using UnityEngine;

[System.Serializable] 
public class TowerMain
{
    public string name;
    public int cost;
    public GameObject prefab;

    public TowerMain(string _name, int _cost, GameObject _prefab)
    { 
        name = _name;
        cost= _cost;
        prefab = _prefab;
    }
}
