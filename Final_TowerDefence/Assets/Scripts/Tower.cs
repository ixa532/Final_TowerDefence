using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Tower : MonoBehaviour, IAtacavel
{
    [SerializeField] public GameObject bulletPrefab;//Referencia ao prefab da bala, que será instanciado para disparar contra o alvo
    [SerializeField] public Transform firingPoint;//Ponto de origem de disparo das balas, indicando de onde elas saem torre
    
    [SerializeField] protected float targetRange = 5f;//Alcance máximo da torre, definindo a distância até onde a torre pode detectar e mirar nos alvos
    [SerializeField] protected LayerMask enemyMask;
    [SerializeField] private float bulletPerSecond = 1f;//Taxa de disparo, incicando quantas balas por segundo a torre consegue disparar
    
    public float timeUntilFire;//Temporizador que controle o intervalo entre os disparos da torre, acumulando o tempo até o próximo disparo
    protected Transform alvo;//Referencia ao alvo atual da torre, usada para definir a direção de rotação e foco dos disparos

    private void Update()//Tem como função controlar o comportamento da torre a cada momento do jogo
    {
        if (alvo == null) //caso não haja um alvo
        {
            FindAlvo();//Chama o método FindAlvo para encontrar um novo alvo

            return;
        }

        {

            if (!CheckTargetRange()) // Verifica se o alvo está fora do alcance permitido, chamando o método Checar se o alvo esta no alcance
            {
                alvo = null; // se o alvo não estiver no alcance, define o alvo como nulo,ou seja, não há alvo para a torre mirar  
            }
            else
            {
                timeUntilFire += Time.deltaTime; //Aumenta o tempo até o próximo tiro, somando o tempo desde o último rfame 

                if (timeUntilFire >= 1f / bulletPerSecond)//Verifica se o tempo acumulado é maior ou igual ao intervalo entre os tiros 
                {
                    Shoot(); //Chama o método de disparo 
                    timeUntilFire = 0f;
                }
            }
        }
    }

    public virtual void Atacar()
    { 
    
    }

    public virtual void Shoot()//Implementa o método Shoot da interface IShoot 
    {
        GameObject bulletOBJ = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);//Cria uma instancia do prefab de bullet na posição do ponto de disparo com a rotação padrão
        Bullet bulletScript = bulletOBJ.GetComponent<Bullet>();//Obtém o componente Bullet do objeto de bala recém instanciado
        bulletScript.SetAlvo(alvo);//Difine o alvo utilizando o método SetAlvo do script Bullet

    }


    private void FindAlvo()//método responsavel por localizar o inimigo mais próximo dentro da faiza de alcance da torre
    {

        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetRange, (Vector2)transform.position, 0f, enemyMask);
        if (hits.Length > 0)
        {

            alvo = hits[0].transform;

        }

    }


    private bool CheckTargetRange()//Tem como função verificar se o alvo atual esta definido (targetRange) da torre. Calcula a distancia entre a posição da torre e a posição do alvo
    {

        //Retorna verdadeiro se a distancia entre o alvo e a torre for menor ou igual ao alcance da torre
        return Vector2.Distance(alvo.position, transform.position) <= targetRange;
    }
}
