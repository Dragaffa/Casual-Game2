using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {

    }



    private void OnCollisionEnter(Collision collision)
    {
        // Comparer le tag du gameobject qui collisionne
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("collide");

            Destroy(gameObject);


            Destroy(collision.gameObject);



        }
    }


}




    




