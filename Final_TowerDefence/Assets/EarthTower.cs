using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthTower : Tower
{
    [SerializeField] private float paraTras = 10f; //Força do empurrar

    public override void Shoot()//Sobreescrevendo o método Shoot
    {
        base.Shoot();//Chama a lógica da classe base Tower

        Bullet bulletScript = bulletOBJ.GetComponent<Bullet>();//Obtém o componente Bullet do prefab de bala, permitindo acessar os métodos e variáveis da classe Bullet
        bulletScript.SetAlvo(alvo);//Define o alvo
        bulletScript.ApplyparaTras(paraTras);//Aplica o de empurrar
    }
}
