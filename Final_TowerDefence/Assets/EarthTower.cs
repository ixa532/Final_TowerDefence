using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthTower : Tower
{
    [SerializeField] private float paraTras = 10f; //For�a do empurrar

    public override void Shoot()//Sobreescrevendo o m�todo Shoot
    {
        base.Shoot();//Chama a l�gica da classe base Tower

        GameObject bulletOBJ = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);//Instancia a Bala
        Bullet bulletScript = bulletOBJ.GetComponent<Bullet>();//Obt�m o componente Bullet
        bulletScript.SetAlvo(alvo);//Define o alvo
        bulletScript.ApplyparaTras(paraTras);//Aplica o de empurrar
    }
}
