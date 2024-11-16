using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthTower : Tower
{
    [SerializeField] private float paraTras = 10f; //For�a do empurrar

    public override void Shoot()//Sobreescrevendo o m�todo Shoot
    {
        base.Shoot();//Chama a l�gica da classe base Tower

        Bullet bulletScript = bulletOBJ.GetComponent<Bullet>();//Obt�m o componente Bullet do prefab de bala, permitindo acessar os m�todos e vari�veis da classe Bullet
        bulletScript.SetAlvo(alvo);//Define o alvo
        bulletScript.ApplyparaTras(paraTras);//Aplica o de empurrar
    }
}
