using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverScreen;
    public TMP_Text secondsSurvivedUI;
    bool gameOver;

    void Start(){
        FindObjectOfType<PlayerController>().OnPlayerDeath += OnGameOver;
    }
    void Update()
    {
        if(gameOver){
            if(Input.GetKeyDown(KeyCode.Space)){
                SceneManager.LoadScene(1);
            }

            if(Input.GetKey("escape")){
                Application.Quit();
            }
        
        }
    }

    void OnGameOver(){
        gameOverScreen.SetActive(true);
        secondsSurvivedUI.text = Mathf.RoundToInt(Time.timeSinceLevelLoad).ToString();
        gameOver=true;
    }
}
