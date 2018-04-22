using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public GameObject hazardUp;
    public GameObject hazardDown;
    public GameObject hazardLeft;
    public GameObject hazardRight;
    public Vector3 spawnValuesUp;
    public Vector3 spawnValuesDown;
    public Vector3 spawnValuesLeft;
    public Vector3 spawnValuesRight;
    public TextMeshProUGUI Text;
    public TextMeshProUGUI GameOverText;
    public TextMeshProUGUI RestartText;
    public int NewScoreValue;
    private int score;
    private bool gameOver;
    private bool restart;
    public int HazardCount;
    private int levelChanger;
    public float SpawnWait;
    public float StartWait;

    // Handling start of the app.

    private void Start()
    {
        GameOverText.text = "";
        RestartText.text = "";

        restart = false;
        gameOver = false;

        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
        levelChanger = (int)Time.timeSinceLevelLoad;

    }
    // Updateing the app.

    private void Update()
    {
        if(restart)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                
                SceneManager.LoadScene("Main");
            }
            if (Input.GetKeyDown(KeyCode.M))
            {

                SceneManager.LoadScene("Menu");
            }
        }

        // Making shorter spawn timings to make the game harder.

        levelChanger = (int)Time.timeSinceLevelLoad / 30;
        UpdateScore();

        switch(levelChanger)
        {
            case 0:
                SpawnWait = 1;
                break;
            case 1:
                SpawnWait = 0.8f;
                break;
            case 2:
                SpawnWait = 0.6f;
                break;
            case 3:
                SpawnWait = 0.4f;
                break;
            case 4:
                SpawnWait = 0.2f;
                break;
            case 5:
                SpawnWait = 0.1f;
                break;
            default:
                SpawnWait = 0.05f;
                break;
        }
    }



    public void GameOver()
    {
        GameOverText.text = "GAME OVER \n\n FINAL SCORE: " + score;
        gameOver = true;
       
    }
   
    // Updating the score.

    void UpdateScore()
    {

        Text.text = "Score: " + score; ;
    }


     public void  AddScore()
    {
        score += NewScoreValue;
        UpdateScore();
    }

    // Spawning waves of asteroids, form random sides and with random trajectories.

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(StartWait);
        while (true)
        {
            for (int i = 0; i < HazardCount; i++)
            {
                int j = Random.Range(1, 5);

                switch (j)
                {
                    case 1:
                        {
                            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValuesUp.x, spawnValuesUp.x), spawnValuesUp.y, spawnValuesUp.z);
                            Quaternion spawnRotation = Quaternion.identity;
                            Instantiate(hazardUp, spawnPosition, spawnRotation);
                            yield return new WaitForSeconds(SpawnWait);
                            if (gameOver)
                            {
                                RestartText.text = "PRESS 'R' TO RESTART \nPRESS 'M' TO GO TO MAIN MENU";
                                restart = true;
                                break;
                            }
                            break;
                        }
                    case 2:
                        {
                            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValuesDown.x, spawnValuesDown.x), spawnValuesDown.y, spawnValuesDown.z);
                            Quaternion spawnRotation = Quaternion.identity;
                            Instantiate(hazardDown, spawnPosition, spawnRotation);
                            yield return new WaitForSeconds(SpawnWait);
                            if (gameOver)
                            {
                                RestartText.text = "PRESS 'R' TO RESTART \nPRESS 'M' TO GO TO MAIN MENU";
                                restart = true;
                                break;
                            }
                            break;
                        }
                    case 3:
                        {
                            Vector3 spawnPosition = new Vector3(spawnValuesLeft.x, spawnValuesLeft.y,Random.Range(-spawnValuesLeft.z, spawnValuesLeft.z));
                            Quaternion spawnRotation = Quaternion.identity;
                            Instantiate(hazardLeft, spawnPosition, spawnRotation);
                            yield return new WaitForSeconds(SpawnWait);
                            if (gameOver)
                            {
                                RestartText.text = "PRESS 'R' TO RESTART \nPRESS 'M' TO GO TO MAIN MENU";
                                restart = true;
                                break;
                            }
                            break;
                        }
                    case 4:
                        {
                            Vector3 spawnPosition = new Vector3(spawnValuesRight.x, spawnValuesRight.y, Random.Range(-spawnValuesRight.z, spawnValuesRight.z));
                            Quaternion spawnRotation = Quaternion.identity;
                            Instantiate(hazardRight, spawnPosition, spawnRotation);
                            yield return new WaitForSeconds(SpawnWait);
                            if (gameOver)
                            {
                                RestartText.text = "PRESS 'R' TO RESTART \nPRESS 'M' TO GO TO MAIN MENU";
                                restart = true;
                                break;
                            }
                            break;
                        }
                    case 5:
                        if (gameOver)
                        {
                            RestartText.text = "PRESS 'R' TO RESTART \nPRESS 'M' TO GO TO MAIN MENU";
                            restart = true;
                        }
                        break;
                }
            }
           
        }
    }
}


