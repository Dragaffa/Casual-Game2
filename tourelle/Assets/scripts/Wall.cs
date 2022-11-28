using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wall : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] Image lifeBar;
    public float WallLife = 100f;
    // Couleurs
    [SerializeField] Color colorFull = Color.green;
    [SerializeField] Color colorEmpty = Color.red;

    Rigidbody rb;
    GameManager gameManager;

    public float life = 100f;


    //Quaternion startRotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();

        // Set
        Life = 100;
        // Get
        Debug.Log(Life);
    }


    public float Life
    {
        get
        {
            return life;
        }
        set
        {
            // Assigner la valeur life
            life = value;
            // Limiter la valeur life
            life = Mathf.Clamp(life, 0, 100f);
            // Et la transmettre au HUD
            GetComponent<Wall>().WallLife = life;
        }
    }//bool canShoot = false;
    private void OnCollisionEnter(Collision collision)
    {
        // Si le player touche un ennemi
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Diminuer la vie
            Life -= 10;
            
        }
    }



    // Update is called once per frame
    void LateUpdate()
    {

        // Faire évoluer la barre de vie
        lifeBar.fillAmount = Mathf.Lerp(lifeBar.fillAmount, WallLife / 100f, 0.1f);
        // Interpolation de couleurs
        lifeBar.color = Color.Lerp(colorEmpty, colorFull, lifeBar.fillAmount);
    }
}
