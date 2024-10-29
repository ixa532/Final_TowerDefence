using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private Transform towerRotationPoint;
    [SerializeField] private GameObject alcanceVisualizacao;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firingPoint;

    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private float targetRange = 5f;
    [SerializeField] private float bulletPerSecond = 1f;
    
    float escala;
    private float timeUntilFire;
    private Transform alvo;

    private void Update()
    {
        if (alvo == null)
        {
            FindAlvo();
        }
        else
        {
            RotateAlvo();

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

    public virtual void Shoot()//Implementa o método Shoot da interface IShoot 
    {
        GameObject bulletOBJ = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);//Cria uma instancia do prefab de bullet na posição do ponto de disparo com a rotação padrão
        Bullet bulletScript = bulletOBJ.GetComponent<Bullet>();//Obtém o componente Bullet do objeto de bala recém instanciado
        bulletScript.SetAlvo(alvo);//Difine o alvo utilizando o método SetAlvo do script Bullet

    }


    private void FindAlvo()
    {
        float menorDistancia = targetRange;

        foreach (Transform inimigo in LevelManager.instance.inimigos)
        {
            float distancia = Vector2.Distance(transform.position, inimigo.position);

            if (distancia < menorDistancia)
            {
                menorDistancia = distancia;
                alvo = inimigo;
            }
        }

    }
    private bool CheckTargetRange()
    {
        return Vector2.Distance(alvo.position, transform.position) <= targetRange;
    }

    private void RotateAlvo()
    {
        //Calcula a direção do alvo em relação à torre, menos a posição atual da torre, da posição do alvo. O resultado é um vetor que aponta da torre para o alvo  
        Vector3 direction = alvo.position - transform.position;
        
        //Se a direção não for zero, rotaciona em direção ao alvo 
        if (direction != Vector3.zero)
            
        //Up esta sendo utilizado para definir o eixo do objeto para a direção calculada, que direciona a torre para o alvo
        //Define a rotação da torre em direção ao alvo
        towerRotationPoint.up = direction; //Agora a torre apontana direção do alvo
    }
    void AjustarAlcance()
    {
        if (alcanceVisualizacao != null) //Verifica se o objeto visual do alcance existe na cena
        {
            escala = targetRange / 2; //Calcula a escala do alcance baseado no valor de targetRange e dividido por 2

            //Define a posição do objeto de visualização do alcance
            //Posição fixa em...
            alcanceVisualizacao.transform.position = new Vector3(0, 0, 1);
        }
    }

    private void OnValidate()
    {
        AjustarAlcance();
    }
}
