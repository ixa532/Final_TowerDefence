using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private Transform towerRotationPoint;
    [SerializeField] private GameObject alcanceVisualizacao;

    [SerializeField] private float targetRange = 5f;
    float escala;

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

            CheckTargetRange(); //Chamar o m�todo checar se o alvo esta no alcance
        }
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

    private void RotateAlvo()
    {
        //Calcula a dire��o do alvo em rela��o � torre, menos a posi��o atual da torre, da posi��o do alvo. O resultado � um vetor que aponta da torre para o alvo  
        Vector3 direction = alvo.position - transform.position;

        //Up esta sendo utilizado para definir o eixo do objeto para a dire��o calculada, que direciona a torre para o alvo
        //Define o vetor UP do ponto de rota��o da torre para apontar na dire��o do alvo, utilisando componentes x e y da dire��o calculada.  
        towerRotationPoint.up = new Vector3(direction.x, direction.y, 0);

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
