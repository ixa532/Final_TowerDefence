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

    public virtual void Shoot()//Implementa o m�todo Shoot da interface IShoot 
    {
        GameObject bulletOBJ = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);//Cria uma instancia do prefab de bullet na posi��o do ponto de disparo com a rota��o padr�o
        Bullet bulletScript = bulletOBJ.GetComponent<Bullet>();//Obt�m o componente Bullet do objeto de bala rec�m instanciado
        bulletScript.SetAlvo(alvo);//Difine o alvo utilizando o m�todo SetAlvo do script Bullet

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
        //Calcula a dire��o do alvo em rela��o � torre, menos a posi��o atual da torre, da posi��o do alvo. O resultado � um vetor que aponta da torre para o alvo  
        Vector3 direction = alvo.position - transform.position;
        
        //Se a dire��o n�o for zero, rotaciona em dire��o ao alvo 
        if (direction != Vector3.zero)
            
        //Up esta sendo utilizado para definir o eixo do objeto para a dire��o calculada, que direciona a torre para o alvo
        //Define a rota��o da torre em dire��o ao alvo
        towerRotationPoint.up = direction; //Agora a torre apontana dire��o do alvo
    }
    void AjustarAlcance()
    {
        if (alcanceVisualizacao != null) //Verifica se o objeto visual do alcance existe na cena
        {
            escala = targetRange / 2; //Calcula a escala do alcance baseado no valor de targetRange e dividido por 2

            //Define a posi��o do objeto de visualiza��o do alcance
            //Posi��o fixa em...
            alcanceVisualizacao.transform.position = new Vector3(0, 0, 1);
        }
    }

    private void OnValidate()
    {
        AjustarAlcance();
    }
}
