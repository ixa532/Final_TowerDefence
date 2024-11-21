using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;


public class SpawnEnemy : MonoBehaviour
{
   
    [SerializeField] private GameObject[] enemyPrefabs; //Array de prefabs de inimigos, que podem ser instanciados durante o jogo 

    [SerializeField] private int baseEnemies = 8; //Número base de inimigos que aparecem na primeira onda
    [SerializeField] private float enemiesPerSecond = 0.5f; //Taxa de spawn de inimigos por segundo
    [SerializeField] private float timeBetweenWaves = 5f;//Tempo em segundos do ínicio de uma onda a outra
    [SerializeField] private float difficultyFactor = 0.75f;//Ajusta a dificuldade,aumentando o número de inimigos em ondas subquentes  
    [SerializeField] private float enemiesPScapacity = 14f; //capacidade max de inimigos por segundo
    public static UnityEvent onEnemyDestroy = new UnityEvent() ;//Declara uma variavel de evento estática para notificar quando um inimigo é destruído

    private int currentWaves = 1; //Contador que rastreia o número atual de ondas
    private float timeLastSpawn;//Acumula o tempo desde o último spawn de inimigo
    protected int enemiesAlive;//Contador do número total de inimigos vivos no jogo
    private int enemiesLeftSpawn;//Contador do número de inimigos que ainda precisam ser spawnados na onda atual
    protected bool isSpawning = false;//Indica se a onda de inimigos está em processo de spawn 

    private void Awake() //Inicializa o script conectando o evento onEnemyDestroy ao método EnemyDestroyed, garantindo que EnemyDestroyed seja chamado automaticamente sempre que um inimigo for destruído.
    {
        onEnemyDestroy.AddListener(EnemyDestroyed); //Adiciona o método "EnemyDestroyed" como um (listener) ao evento onEnemyDestroy, ou seja, quando o evento onEnemyDestroy for disparado, o método EnemyDestroyed será executado automaticamente
    }

    private void Start()//Inicia a primeira onda de inimigos chamando o método StartWave()
    {
       StartCoroutine(StartWave()); //Começar as ondas
    }

    private void Update()//Coordena o tempo e controla o spawn de inimigos, mantendo a frequência de criação com base na variável enemiesPerSecond e a contagem de inimigos restantes na onda (enemiesLeftSpawn).
    {
        timeLastSpawn += Time.deltaTime; //Acumulao o tempo desde o último spawn, aumentando a variavél com o tempo passado desde o último frame

        //Verifica se o tempo desde o último spawn é suficiente para spawnar um novo inimigo
        //e se ainda há inimigos restantes para spawnar na onda atual 
        if (timeLastSpawn >= (1f / enemiesPerSecond)&& enemiesLeftSpawn > 0) 
        {
            SpawnEnemies(); //Chama o método SpawnEnemies, ou seja, método que realiza o spawn dos inimigos
            enemiesLeftSpawn--; //Diminui o contador de inimigos que faltam spawnar na onda atual
            enemiesAlive++;//Incrementa o contador de inimigos atualmente vivos no jogo
            timeLastSpawn = 0f;//Reinicia o temporizador para controlar o intervalor de tempo até o próximo spawn 
        }
        if (enemiesAlive == 0 && enemiesLeftSpawn == 0)         // Verifica se todos os inimigos foram destruídos.

        {
            EndWave(); // Termina a onda atual.
            baseEnemies++; // incrementa a quantidade máxima de inimigos 
        }
    }
    private void EnemyDestroyed()//Método chamado quando um inimigo é destruído 
    { 
        enemiesAlive--; //Reduz o contador de inimigos vivos no jogo ao decrementar a variavel enemiesAlive
    }

        private IEnumerator StartWave()//método é chamado para iniciar uma nova onda de inimigos
        {
            yield return new WaitForSeconds(timeBetweenWaves);
            isSpawning = true; //Define a variável como verdadeira, indicando que a onda de inimigos está em processo de spawn
            
            //Obtém o número total de inimigos para a onda atual chamando o método EnemiesPerWave
            // armazena o resultado na variável enemiesLeftSpawn
            enemiesLeftSpawn = EnemiesPerWave(); 
        }
    private void EndWave()     // Método para terminar a onda atual e iniciar uma nova.

    {
        isSpawning = false; // Para a geração de inimigos.
        timeLastSpawn = 0f; // Reseta o temporizador de geração.
        currentWaves++; // Avança para a próxima onda.
        StartCoroutine(StartWave()); // Inicia a próxima onda.
    }


    private void SpawnEnemies()//Método responsavel por instanciar um inimigo na cena
    {
        int index = UnityEngine.Random.Range(0, enemyPrefabs.Length); // Seleciona um prefab aleatório de inimigo.
        GameObject prefabToSpawn = enemyPrefabs[index]; // Obtém o prefab escolhido.


        //Instancia o inimigo escolhido na posição inicial definida no LevelManager
        Instantiate(prefabToSpawn, LevelManager.instance.startPoint.position, Quaternion.identity);
    }


    private int EnemiesPerWave()//método responsável por determinar quantos inimigos devem aparecer em cada onda, ajustando a quantidade com base na dificuldade e na progressão do jogo
    {
        //Calcula e retorna o número de inimigos para a onda atual
        //Multiplica o número base de inimigos pelo valor da onda atual elevado ao fator de dificuldade
        ////Mathf.RoundToInt esta garantindo que o numero de inimigos seja um valor inteiro 
        return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentWaves, difficultyFactor));
    }
}
