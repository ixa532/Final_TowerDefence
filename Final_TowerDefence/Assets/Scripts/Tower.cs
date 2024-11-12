using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Tower : MonoBehaviour, IAtacavel
{
    [SerializeField] public GameObject bulletPrefab;//Referencia ao prefab da bala, que ser� instanciado para disparar contra o alvo
    [SerializeField] public Transform firingPoint;//Ponto de origem de disparo das balas, indicando de onde elas saem torre
    
    [SerializeField] protected float targetRange = 5f;//Alcance m�ximo da torre, definindo a dist�ncia at� onde a torre pode detectar e mirar nos alvos
    [SerializeField] protected LayerMask enemyMask;
    [SerializeField] private float bulletPerSecond = 1f;//Taxa de disparo, incicando quantas balas por segundo a torre consegue disparar
    
    public float timeUntilFire;//Temporizador que controle o intervalo entre os disparos da torre, acumulando o tempo at� o pr�ximo disparo
    protected Transform alvo;//Referencia ao alvo atual da torre, usada para definir a dire��o de rota��o e foco dos disparos

    private void Update()//Tem como fun��o controlar o comportamento da torre a cada momento do jogo
    {
        if (alvo == null) //caso n�o haja um alvo
        {
            FindAlvo();//Chama o m�todo FindAlvo para encontrar um novo alvo

            return;
        }

        {

            if (!CheckTargetRange()) // Verifica se o alvo est� fora do alcance permitido, chamando o m�todo Checar se o alvo esta no alcance
            {
                alvo = null; // se o alvo n�o estiver no alcance, define o alvo como nulo,ou seja, n�o h� alvo para a torre mirar  
            }
            else
            {
                timeUntilFire += Time.deltaTime; //Aumenta o tempo at� o pr�ximo tiro, somando o tempo desde o �ltimo rfame 

                if (timeUntilFire >= 1f / bulletPerSecond)//Verifica se o tempo acumulado � maior ou igual ao intervalo entre os tiros 
                {
                    Shoot(); //Chama o m�todo de disparo 
                    timeUntilFire = 0f;
                }
            }
        }
    }

    public virtual void Atacar()
    { 
    
    }

    public virtual void Shoot()//Implementa o m�todo Shoot da interface IShoot 
    {
        GameObject bulletOBJ = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);//Cria uma instancia do prefab de bullet na posi��o do ponto de disparo com a rota��o padr�o
        Bullet bulletScript = bulletOBJ.GetComponent<Bullet>();//Obt�m o componente Bullet do objeto de bala rec�m instanciado
        bulletScript.SetAlvo(alvo);//Difine o alvo utilizando o m�todo SetAlvo do script Bullet

    }


    private void FindAlvo()//m�todo responsavel por localizar o inimigo mais pr�ximo dentro da faiza de alcance da torre
    {

        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetRange, (Vector2)transform.position, 0f, enemyMask);
        if (hits.Length > 0)
        {

            alvo = hits[0].transform;

        }

    }


    private bool CheckTargetRange()//Tem como fun��o verificar se o alvo atual esta definido (targetRange) da torre. Calcula a distancia entre a posi��o da torre e a posi��o do alvo
    {

        //Retorna verdadeiro se a distancia entre o alvo e a torre for menor ou igual ao alcance da torre
        return Vector2.Distance(alvo.position, transform.position) <= targetRange;
    }
}
