using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTower : Tower
{
    [SerializeField]private float dano = 10f; //Dano causado por cada tiro 
    [SerializeField] private float fireRateMultiplier = 1.5f;//Multiplicador para a taxa de tiro

}
