using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour // Classe que gerencia a cria��o de inimigos no jogo, aumentando a dificuldade em ondas.
{
    [Header("References")]
    [SerializeField] private GameObject[] enemyPrefabs; // Array de prefabs de inimigos a serem instanciados.

    [Header("Attributes")]
    [SerializeField] private int baseEnemies = 8; // Quantidade b�sica de inimigos por onda.
    [SerializeField] private float enemiesPerSecond = 0.5f; // Taxa de aparecimento dos inimigos por segundo.
    public float timebetweenWaves = 5f; // Tempo de espera entre ondas de inimigos.
    [SerializeField] private float difficultyScallingFactor = 0.75f; // Fator de escala da dificuldade, aumentando o n�mero de inimigos por onda.

    [Header("Events")]
    public static UnityEvent onEnemyDestroy = new UnityEvent(); // Evento acionado quando um inimigo � destru�do.

    private int currentwave = 1; // Contador da onda atual.
    private float timesinceLastSpawn; // Tempo decorrido desde o �ltimo inimigo gerado.
    private int enemiesAlive; // N�mero de inimigos vivos atualmente no jogo.
    private int enemiesLeftToSpawn; // N�mero de inimigos restantes para aparecer na onda atual.
    private bool isSpawning = false; // Controla se os inimigos est�o sendo gerados.

    private void Awake() // M�todo chamado ao iniciar o script, antes do Start.
    {
        onEnemyDestroy.AddListener(EnemyDestroyed); // Adiciona o m�todo EnemyDestroyed como ouvinte para o evento onEnemyDestroy.
    }

    public void Start() // M�todo inicial que configura o estado do jogo ao iniciar.
    {
        StartCoroutine(StartWave()); // Inicia a primeira onda de inimigos ap�s um per�odo de espera.
    }

    public void Update() // Chamado a cada quadro para atualizar o estado da cria��o de inimigos.
    {
        if (!isSpawning) return; // Se n�o for o momento de gerar inimigos, retorna.

        timesinceLastSpawn += Time.deltaTime; // Atualiza o tempo desde a �ltima gera��o de inimigos.

        // Verifica se � hora de criar um novo inimigo e se ainda restam inimigos para gerar na onda atual.
        if (timesinceLastSpawn >= (1f / enemiesPerSecond) && enemiesLeftToSpawn > 0)
        {
            SpawnEnemy(); // Gera um inimigo.
            enemiesLeftToSpawn--; // Decrementa o contador de inimigos restantes para gerar.
            enemiesAlive++; // Incrementa o n�mero de inimigos vivos no jogo.
            timesinceLastSpawn = 0f; // Reseta o tempo desde o �ltimo inimigo gerado.
        }

        // Se n�o restam inimigos para gerar e todos os inimigos foram destru�dos, termina a onda.
        if (enemiesLeftToSpawn == 0 && enemiesAlive == 0)
        {
            Endwave(); // Finaliza a onda atual e prepara para a pr�xima.
        }
    }

    public void Endwave() // M�todo para finalizar a onda atual.
    {
        isSpawning = false; // Para a gera��o de inimigos.
        timesinceLastSpawn = 0f; // Reseta o tempo desde o �ltimo inimigo gerado.
        currentwave++; // Incrementa o n�mero da onda atual.
        StartCoroutine(StartWave()); // Inicia a pr�xima onda ap�s o per�odo de espera.
        AdsManager.instance.ShowNextAd();
    }

    private void EnemyDestroyed() // M�todo chamado quando um inimigo � destru�do.
    {
        enemiesAlive--; // Decrementa o contador de inimigos vivos.
    }

    private IEnumerator StartWave() // Coroutine que inicia uma nova onda ap�s um tempo de espera.
    {
        yield return new WaitForSeconds(timebetweenWaves); // Aguarda o tempo definido entre ondas.
        isSpawning = true; // Ativa a gera��o de inimigos.
        enemiesLeftToSpawn = EnemiesPerwave(); // Calcula o n�mero de inimigos a serem gerados na onda atual.
    }

    private void SpawnEnemy() // M�todo para gerar um inimigo.
    {
        GameObject prefabToSpawn = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)]; // Escolhe um prefab aleat�rio da lista de inimigos.
        Instantiate(prefabToSpawn, LevelManager.instance.startPoint.position, Quaternion.identity); // Instancia o inimigo na posi��o inicial definida no LevelManager.
    }

    private int EnemiesPerwave() // Calcula o n�mero de inimigos para a onda atual com base na dificuldade.
    {
        return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentwave, difficultyScallingFactor)); // Aumenta o n�mero de inimigos por onda de acordo com o fator de dificuldade.
    }
}