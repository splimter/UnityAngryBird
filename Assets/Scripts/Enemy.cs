using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _puffsPrefab;
    private void OnCollisionEnter2D(Collision2D other)
    {
        Bird b = other.collider.GetComponent<Bird>();
        Enemy e = other.collider.GetComponent<Enemy>();
        
        if (b != null)
        {
            Instantiate(_puffsPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            return;
        }
        if (e != null)
        {
            return;
        }

        if (other.contacts[0].normal.y < -0.5)
        {
            Instantiate(_puffsPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        
    }
}
