using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceTower : Tower
{
    [SerializeField] private float slowAmount = 0.5f; //Percentual de redu��o da velocidade
    [SerializeField] private float slowDuration = 2f;//Dura��o do efeito de congelamento

    protected override void Shoot()
    {
        GameObject bulletOBJ = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);//Instancia a bala no ponto de disparo
        Bullet bulletScript = bulletOBJ.GetComponent<Bullet>();//Obt�m o componente Bullet
        bulletScript.SetAlvo(alvo); //Define o alvo para a bala
        bulletScript.ApplySlowEffect(slowAmount, slowDuration); //Aplica o efeito de congelamento
    }
}
