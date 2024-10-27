using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform alvo;

    [SerializeField] private float bulletSpeed = 5f;
    [SerializeField] private Rigidbody rb;

}
