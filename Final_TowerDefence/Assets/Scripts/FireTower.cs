using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTower : Tower
{
    
    [SerializeField] private float fireDamagePerSecond = 1.5f;
    [SerializeField] private float fireDuration = 4f;

    public override void Atacar()
    {
        if (target != null) // Verifica se há um alvo designado
        {
            Healthy enemyHealthy = target.GetComponent<Healthy>(); // Obtém o componente de saúde do inimigo

            if (enemyHealthy != null) // Verifica se o inimigo possui o componente de saúde
            {
                StartCoroutine(ApplyFireDamage(enemyHealthy)); // Inicia a aplicação do dano de queimadura
            }
        }
    }
    private IEnumerator ApplyFireDamage(Healthy enemyHealthy)
    {
        float elapsedTime = 0f; // Tempo decorrido desde o início do efeito de queimadura

        while (elapsedTime < fireDuration) // Continua aplicando dano até o fim da duração da queimadura
        {
          //  enemyHealthy.TakeDamage(fireDamagePerSecond * Time.deltaTime); // Aplica dano ao inimigo a cada frame
            elapsedTime += Time.deltaTime; // Atualiza o tempo decorrido
            yield return null; // Espera até o próximo frame para continuar
        }
    }
public override void Shoot()//é responsável por realizar o processo de disparo da torre, configurando corretamente a bala para atingir o alvo e aplicar dano.
    {
        //Instancia a bala no ponto de disparo com rotação padrão
        GameObject bulletOBJ = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);
       
        //Obtém o componente Bullet do objeto bullet recém instanciado 
        Bullet bulletScript = bulletOBJ.GetComponent<Bullet>();

        //Define o alvo da bala usando o método SetAlvo
        bulletScript.SetTarget(target);

        Atacar() ;
    }
}
