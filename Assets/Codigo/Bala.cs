using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{

    public GameObject bulletHole;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Enemy") || other.transform.CompareTag("Bullet") || other.transform.CompareTag("Player"))
        {
            Destroy(gameObject);
            return;
        }
        
        Vector3 pos = other.GetContact(0).point;
        Vector3 normal = other.GetContact(0).normal;
        GameObject newBulletHole = Instantiate(bulletHole, pos, Quaternion.identity);
        newBulletHole.transform.forward = normal;
        newBulletHole.transform.position += newBulletHole.transform.forward * 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
