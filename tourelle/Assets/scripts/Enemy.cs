using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    [SerializeField] public Transform target;
    [SerializeField] GameObject explosionPrefab;
    GameManager gameManager;

    public float vitesse = 10f;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        
        transform.Translate(0, 0, vitesse * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Comparer le tag du gameobject qui collisionne
        if (collision.gameObject.CompareTag("Arrow"))
        {
            Debug.Log("collide");
            
            Destroy(gameObject);

            
            //Destroy(collision.gameObject);

            
            
                FindObjectOfType<GameManager>().AddScore();
          
            

            gameManager.enemies.Remove(this);

            
            GameObject explo = Instantiate(explosionPrefab, gameManager.fxContainer);
            explo.transform.position = transform.position;

           


        }

        

        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);

        }
    }

}
