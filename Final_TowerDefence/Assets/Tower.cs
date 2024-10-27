using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform towerRotationPoint;
    [SerializeField] private GameObject alcanceVisualizacao;

    [Header("Attributes")]
    [SerializeField] private float targetRange = 5f;

    void AjustarAlcance()
    {
        if (alcanceVisualizacao != null)
        { 
            CircleCollider2D rangeCollider = alcanceVisualizacao.GetComponent<CircleCollider2D>();
            if (rangeCollider != null)
            { 
                rangeCollider.radius = targetRange;
            }
        }
    }
}
