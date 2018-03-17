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
            fStartTime -= Time.deltaTime;
        else   // Out of time? Reset the level
        {
            goScreenFader.SetActive(true);
            goWinText.SetActive(true);

            if (GameController.iBlueVillagers > GameController.iRedVillagers)
                goWinText.GetComponent<Text>().text = "Player 1 won!";
            else if (GameController.iBlueVillagers < GameController.iRedVillagers)
                goWinText.GetComponent<Text>().text = "Player 2 won!";
            else   // No more, no less, so equal scores!
                goWinText.GetComponent<Text>().text = "It's a draw!";

            //WaitInput();
            SceneManager.LoadScene("Main");
        }

        // Change time text so the player knows
        texClock.text = Mathf.Ceil(fStartTime).ToString();
    }

    //IEnumerator WaitInput()
    //{
    //    //yield return new WaitForSeconds(4);

    //    while (!Input.GetButton("Interact1"))
    //        yield return null;

    //    goScreenFader.SetActive(false);
    //    goWinText.SetActive(false);
    //    SceneManager.LoadScene("Main");
    //}
}
