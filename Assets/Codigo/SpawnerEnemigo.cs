using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemigo : MonoBehaviour
{

    public GameObject enemigo;
    public Transform origenEnemigo;
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Spawnear", Random.Range(5f, 10f));
    }

    void Spawnear()
    {
        
        for (int cuantos = 0; cuantos < Mathf.RoundToInt(Random.Range(2f, 5f)); cuantos++)
        {
            Vector3 offset = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), Random.Range(-5f, 5f));
            Instantiate(enemigo, origenEnemigo.transform.position+offset, Quaternion.identity);
        }
        
        Invoke("Spawnear", Random.Range(1f, 5f));
    }
    
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 120*Time.deltaTime, 0);
    }
}
