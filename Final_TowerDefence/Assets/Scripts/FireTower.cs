using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTower : Tower
{
    
    [SerializeField] private float fireDamagePerSecond = 1.5f;
    [SerializeField] private float fireDuration = 4f;

    public override void Atacar()
    {
        if (target != null) // Verifica se h� um alvo designado
        {
            Healthy enemyHealthy = target.GetComponent<Healthy>(); // Obt�m o componente de sa�de do inimigo

            if (enemyHealthy != null) // Verifica se o inimigo possui o componente de sa�de
            {
                StartCoroutine(ApplyFireDamage(enemyHealthy)); // Inicia a aplica��o do dano de queimadura
            }
        }
    }
    private IEnumerator ApplyFireDamage(Healthy enemyHealthy)
    {
        float elapsedTime = 0f; // Tempo decorrido desde o in�cio do efeito de queimadura

        while (elapsedTime < fireDuration) // Continua aplicando dano at� o fim da dura��o da queimadura
        {
          //  enemyHealthy.TakeDamage(fireDamagePerSecond * Time.deltaTime); // Aplica dano ao inimigo a cada frame
            elapsedTime += Time.deltaTime; // Atualiza o tempo decorrido
            yield return null; // Espera at� o pr�ximo frame para continuar
        }
    }
public override void Shoot()//� respons�vel por realizar o processo de disparo da torre, configurando corretamente a bala para atingir o alvo e aplicar dano.
    {
        //Instancia a bala no ponto de disparo com rota��o padr�o
        GameObject bulletOBJ = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);
       
        //Obt�m o componente Bullet do objeto bullet rec�m instanciado 
        Bullet bulletScript = bulletOBJ.GetComponent<Bullet>();

        //Define o alvo da bala usando o m�todo SetAlvo
        bulletScript.SetTarget(target);

        Atacar() ;
    }
}
