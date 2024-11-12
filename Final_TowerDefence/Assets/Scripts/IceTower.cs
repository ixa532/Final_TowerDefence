using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceTower : Tower
{
    [SerializeField] private float slowAmount = 0.5f; //Percentual de redução da velocidade
    [SerializeField] private float slowDuration = 2f;//Duração do efeito de congelamento
    [SerializeField] private float ataquePS = 4f; //ataques por segundo

    private void Update()
    {
        timeUntilFire += Time.deltaTime; // Incrementa o tempo até o próximo ataque
        if (timeUntilFire >= 1f / ataquePS) // Se o tempo acumulado é suficiente para um ataque
        {
            FreezeEnemies(); // Aplica o efeito de desaceleração aos inimigos
            timeUntilFire = 0f; // Reseta o tempo até o próximo ataque
        }
    }
    // Aplica o efeito de desaceleração nos inimigos dentro do alcance da torre
    private void FreezeEnemies()
    {
        // Realiza um CircleCast para detectar todos os inimigos no alcance da torre
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetRange, (Vector2)transform.position, 0f, enemyMask);
        if (hits.Length > 0)
        {
            for (int i = 0; i < hits.Length; i++) // Percorre todos os inimigos detectados
            {
                RaycastHit2D hit = hits[i];
                EnemyMovement em = hit.transform.GetComponent<EnemyMovement>(); // Obtém o script de movimento do inimigo
                em.UpdateSpeed(0.5f); // Reduz a velocidade do inimigo pela metade
                StartCoroutine(ResetEnemySpeed(em)); // Inicia a rotina para restaurar a velocidade normal após o tempo de congelamento
            }
        }
    }
    private IEnumerator ResetEnemySpeed(EnemyMovement em)
    {
        yield return new WaitForSeconds(slowDuration); // Espera pelo tempo de congelamento //yield serve para permitir essa pausa controlada sem bloquear a execução do jogo
        em.ResetSpeed(); // Restaura a velocidade original do inimigo
    }
    //Método publico sobrescrito que realiza o disparo da torre.
    // Ele instancia um objeto de bala na posição de disparo, define o alvo da bala e aplica um efeito de congelamento.
    public override void Shoot()
    {
        GameObject bulletOBJ = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);//Instancia a bala no ponto de disparo
        Bullet bulletScript = bulletOBJ.GetComponent<Bullet>();//Obtém o componente Bullet
        bulletScript.SetAlvo(alvo); //Define o alvo para a bala

    }
}
