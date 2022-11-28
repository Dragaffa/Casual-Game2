using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControler : MonoBehaviour
{

    [SerializeField] TextMesh scoreTxt;

    private GameManager gameManager;
    private int score;

    public void ChangeScene(string Start)
    {
        SceneManager.LoadScene(Start);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Awake()
    {
        score = PlayerPrefs.GetInt("Score", score);
    }

    public void Start()
    {
        scoreTxt.text = score.ToString();
    }


}
