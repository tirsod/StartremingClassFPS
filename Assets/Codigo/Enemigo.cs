using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject particulasEnemigo;
    
    public float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Bullet"))
        {
            GameObject nuevaparticula = Instantiate(particulasEnemigo, transform.position, Quaternion.identity);
            Destroy(nuevaparticula, 5f);

            PlayerScript ps = GameObject.Find("Player").GetComponent<PlayerScript>();
            ps.objetivos -= 1;
            
            Destroy(gameObject);
        }
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(transform.forward * speed);
        transform.LookAt(Camera.main.transform);
    }
}
