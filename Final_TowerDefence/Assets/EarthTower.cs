using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthTower : Tower
{
    [SerializeField] private float paraTras = 10f; //For�a do empurrar

    protected override void Shoot()
    {
        GameObject bulletOBJ = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);//Instancia a Bala
        Bullet bulletScript = bulletOBJ.GetComponent<Bullet>();//Obt�m o componente Bullet
        bulletScript.SetAlvo(alvo);//Define o alvo
        bulletScript.ApplyparaTras(paraTras);//Aplica o de empurrar
    }
}
