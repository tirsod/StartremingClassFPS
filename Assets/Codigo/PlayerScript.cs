using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{

    public Transform bulletOrigin;
    public GameObject bulletObject;
    public float rateOfFire = 500f;
    public float health = 100f;
    public ParticleSystem muzzle;

    public Image healthBar;
    
    private float timeToFire;

    public bool dead;

    public int objetivos = 50;
    public Text objetivoText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Enemy"))
        {
            health -= 10f;
            other.gameObject.GetComponent<Rigidbody>().AddForce(other.transform.forward * -50f);
        }
    }

    void ReiniciarEscena()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    void PlayerDeath()
    {
        GetComponent<FirstPersonAIO>().enabled = false;
        GameObject camara = Camera.main.gameObject;
        camara.AddComponent<BoxCollider>();
        camara.AddComponent<Rigidbody>();
        camara.transform.GetChild(0).gameObject.AddComponent<Rigidbody>();
        camara.transform.GetChild(0).gameObject.AddComponent<BoxCollider>();
        camara.transform.GetChild(0).parent = null;
        Invoke("ReiniciarEscena", 3f);
    }
    
    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = health / 100f;
        if (health <= 0f)
        {
            objetivoText.text = "Intenta de nuevo!";
            if (!dead)
            {
                dead = true;
                PlayerDeath();
            }
            return;
        }
        
        if (Input.GetMouseButton(0) && timeToFire < 0f)
        {
            GameObject nuevaBala = Instantiate(bulletObject, bulletOrigin.position, bulletOrigin.rotation);
            nuevaBala.GetComponent<Rigidbody>().AddForce(nuevaBala.transform.forward * 20f);
            timeToFire = 60f / rateOfFire;
            muzzle.Emit(5);
        }

        timeToFire -= Time.deltaTime;
        if (objetivos > 0){ objetivoText.text = "Elimina " + objetivos + " enemigos";}
        else{ objetivoText.text = "Felicitaciones";}
    }
}
