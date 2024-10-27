using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTower : Tower
{
    [SerializeField]private float dano = 10f; //Dano causado por cada tiro 
    [SerializeField] private float fireRateMultiplier = 1.5f;//Multiplicador para a taxa de tiro

    private void Start()
    {
        //Ajusta a taxa de disparo inicial multiplicado pela taxa de fogo 
        bulletPerSecond *= fireRateMultiplier;
    }

    protected override void Shoot()
    {
        //Instancia a bala no ponto de disparo com rota��o padr�o
        GameObject bulletOBJ = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);
       
        //Obt�m o componente Bullet do objeto bullet rec�m instanciado 
        Bullet bulletScript = bulletOBJ.GetComponent<Bullet>();

        //Define o alvo da bala usando o m�todo SetAlvo
        bulletScript.SetAlvo(alvo);

        //Adiciona dano � bala utilizando o m�todo SetDano
        bulletScript.SetDano(dano);
    }
}
