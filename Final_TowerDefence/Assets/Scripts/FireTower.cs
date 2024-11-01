using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTower : Tower
{
    [SerializeField]private float dano = 10f; //Dano causado por cada tiro 
    [SerializeField] private float fireRateMultiplier = 1.5f;//Multiplicador para a taxa de tiro

    private void Start()//configura a taxa de disparo da torre logo no in�cio, garantindo que ela seja ajustada com base no multiplicador fireRateMultiplier
    {
        //Ajusta a taxa de disparo inicial multiplicado pela taxa de fogo 
        bulletPerSecond *= fireRateMultiplier;
    }

    public override void Shoot()//� respons�vel por realizar o processo de disparo da torre, configurando corretamente a bala para atingir o alvo e aplicar dano.
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
