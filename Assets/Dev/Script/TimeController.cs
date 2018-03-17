using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeController : MonoBehaviour
{
    public float fStartTime = 500;
    private Text texClock;

    public GameObject goScreenFader;
    public GameObject goWinText;
    public GameObject goUICanvas;
    private ControllerProgress GameController;

    private void Start()
    {
        texClock = GetComponent<Text>();

        if (goUICanvas != null)
            GameController = goUICanvas.GetComponent<ControllerProgress>();
        else
            print("No UI Canvas attached!");
    }

    void Update ()
    {
        // Take away 1 frame of milliseconds
        if (fStartTime > 0)
        {
            fStartTime -= Time.deltaTime;

            // Change time text so the player knows
            texClock.text = Mathf.Ceil(fStartTime).ToString();
        }
        else   // Out of time? Reset the level
        {
            goScreenFader.SetActive(true);
            goWinText.SetActive(true);

            if (GameController.iBlueVillagers > GameController.iRedVillagers)
            {
            	//GameController.iWins[0] += 1;
                goWinText.GetComponent<Text>().text = "Player 1 won!";
            }
            else if (GameController.iBlueVillagers < GameController.iRedVillagers)
            {
            	//GameController.iWins[0]++;
                goWinText.GetComponent<Text>().text = "Player 2 won!";
            }
            else   // No more, no less, so equal scores!
            {
            	//GameController.iWins[0]++;
                goWinText.GetComponent<Text>().text = "It's a draw!";
            }

            StartCoroutine(WaitInput());
            //SceneManager.LoadScene("Main");
        }
    }

    IEnumerator WaitInput()
    {
        //yield return new WaitForSeconds(4);

        while (!Input.GetButton("Interact1") && !Input.GetButton("Interact2") && !Input.GetButton("Escape"))
            yield return null;
        
        SceneManager.LoadScene("Main");
    }
}
