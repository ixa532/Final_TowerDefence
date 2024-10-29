using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthTower : Tower
{
    [SerializeField] private float paraTras = 10f; //Força do empurrar

    public override void Shoot()//Sobreescrevendo o método Shoot
    {
        base.Shoot();//Chama a lógica da classe base Tower

        GameObject bulletOBJ = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);//Instancia a Bala
        Bullet bulletScript = bulletOBJ.GetComponent<Bullet>();//Obtém o componente Bullet
        bulletScript.SetAlvo(alvo);//Define o alvo
        bulletScript.ApplyparaTras(paraTras);//Aplica o de empurrar
    }
}
