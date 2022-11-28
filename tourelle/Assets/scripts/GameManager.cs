using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    // Références des containers
    public Transform ArrowContainer;
    public Transform enemyContainer;
    public Transform spawnContainer;
    public Transform fxContainer;




    // Liste des spawns
    [SerializeField] List<Transform> spawns = new List<Transform>();
    // Liste des ennemis
    [SerializeField] public List<Enemy> enemies = new List<Enemy>();
    // Prefab des ennemis
    [SerializeField] GameObject enemyPrefab;


    //[SerializeField] public List<Arrow> fleche = new List<Arrow>();

    [SerializeField] GameObject Arrow;

    [SerializeField] GameObject Wall;
    [SerializeField] Wall WallScript;


    [SerializeField] TextMesh txtScore;
    public int score;

    private Enemy enemy;

    private void Awake()
    {
        PlayerPrefs.SetInt("Score", 0);
        score = PlayerPrefs.GetInt("Score", score);
    }

    // Start is called before the first frame update
    void Start()
    {
        WallScript = FindObjectOfType<Wall>();

        

        //txtScore.text = score.ToString();

        //txtScore.gameObject.SetActive(false);


        InvokeRepeating("SpawnEnemyToRandomPosition", 1f, 1f);
        //InvokeRepeating("SpawnArrow", 0.5f, 0.5f);
        SpawnArrow();
    }




    // Update is called once per frame
    void Update()
    {


        if ( WallScript.WallLife <= 0)
        {
            SceneManager.LoadScene("Menu");
        }

        

    }

    public void AddScore()
    {
        PlayerPrefs.SetInt("Score", score +1);
        score = PlayerPrefs.GetInt("Score", score);
        txtScore.text = score.ToString();

        if (score == 30)
        {
            CancelInvoke("SpawnEnemyToRandomPosition");
            InvokeRepeating("SpawnEnemyToRandomPosition", 0.5f, 0.5f);
        }
        if (score == 60)
        {
            CancelInvoke("SpawnEnemyToRandomPosition");
            InvokeRepeating("SpawnEnemyToRandomPosition", 0.3f, 0.3f);
        }
        if (score == 100)
        {
            CancelInvoke("SpawnEnemyToRandomPosition");
            InvokeRepeating("SpawnEnemyToRandomPosition", 0.1f, 0.1f);
        }



    }



    void SpawnEnemyToRandomPosition()
    {
        // Index aléatoire
        int randomIndex = Random.Range(0, spawns.Count);
        // Spawn alaétoire
        Transform spawn = spawns[randomIndex];
        SpawnEnemy(spawn.position);
    }

    void SpawnEnemy(Vector3 pos)
    {
        
        // Instancier l'ennemi
        GameObject e = Instantiate(enemyPrefab, enemyContainer);
        // Positionner l'ennemi
        e.transform.position = pos;
        // Ajout de l'ennemi dans la liste
        enemies.Add(e.GetComponent<Enemy>());


        enemy = FindObjectOfType<Enemy>();
        if (score < 3)
        {
            e.transform.localScale = e.transform.localScale * 2;
            
            enemy.vitesse = 5;
        }
        else if (score >= 15)
        {
            enemy.vitesse = 15;
        }
        else
        {
            enemy.vitesse = 10;
        }

    }


    public void SpawnArrow()
    {
        // Instancier l'ennemi
        
            GameObject munition = Instantiate(Arrow, ArrowContainer) ;
        

        
    }

 


}
