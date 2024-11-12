using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Healthy : MonoBehaviour
{
    [SerializeField] private int qtMoedas = 40;
    private bool isDestroyed = false;
    [SerializeField] private int hitPoints = 2; //Variável que define a quantidade inicial de pontos de vida do inimigo 

    public void TakeDamage(int damage)//Aplica dano ao objeto, reduzindo os pontos de vida
    {
        hitPoints -= damage;//Reduz os pontos de vida do inimigo com base no valor de damage

        if (hitPoints <= 0 && isDestroyed)//Verifica se os pontos de vida do inimigo com base no valor de damage
        {
            LevelManager.instance.IncrementarMoedas(qtMoedas);
            isDestroyed = true;
            SpawnEnemy.onEnemyDestroy.Invoke(); //Dispara um sinal para o jogo informando que o inimigo foi destruído, permitindo que outros sistemas reajam a essa destruição
            Destroy(gameObject);//Destroi o objeto
        }
    }
}