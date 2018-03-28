using System.Collections;
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

    private bool bInGame = true;

    public AudioClip RoundWin;
    AudioSource audioSource;

    private void Start()
    {
        texClock = GetComponent<Text>();

        if (goUICanvas != null)
            GameController = goUICanvas.GetComponent<ControllerProgress>();
        else
            print("No UI Canvas attached!");

        audioSource = GetComponent<AudioSource>();

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
            if (bInGame)
            {
                bInGame = false;

                goScreenFader.SetActive(true);
                goWinText.SetActive(true);

                if (GameController.iBlueVillagers > GameController.iRedVillagers)
                {
                    PlayerPrefs.SetInt("blueWins", PlayerPrefs.GetInt("blueWins", 0) + 1);
                    goWinText.GetComponent<Text>().text = "Player 1 won this round!";
                    //audioSource.PlayOneShot(RoundWin, 0.7F);
                }
                else if (GameController.iBlueVillagers < GameController.iRedVillagers)
                {
                    PlayerPrefs.SetInt("redWins", PlayerPrefs.GetInt("redWins", 0) + 1);
                    goWinText.GetComponent<Text>().text = "Player 2 won this round!";
                    audioSource.PlayOneShot(RoundWin, 0.7F);
                }
                else   // No more, no less, so equal scores!
                {
                    PlayerPrefs.SetInt("blueWins", PlayerPrefs.GetInt("blueWins", 0) + 1);
                    PlayerPrefs.SetInt("redWins", PlayerPrefs.GetInt("redWins", 0) + 1);
                    goWinText.GetComponent<Text>().text = "It's a draw!";
                }
                GameController.ShowWins();

                if (PlayerPrefs.GetInt("blueWins") >= 2 && PlayerPrefs.GetInt("redWins") >= 2)
                    goWinText.GetComponent<Text>().text = "Congratulations! \n You are both horrible!";
                else if (PlayerPrefs.GetInt("blueWins") >= 2)
                    goWinText.GetComponent<Text>().text = "Congratulations player 1! \n You are the biggest liar!";
                else if (PlayerPrefs.GetInt("redWins") >= 2)
                    goWinText.GetComponent<Text>().text = "Congratulations player 2! \n You are the biggest liar!";

                if (PlayerPrefs.GetInt("blueWins") >= 2 || PlayerPrefs.GetInt("redWins") >= 2)
                {
                    PlayerPrefs.SetInt("blueWins", 0);
                    PlayerPrefs.SetInt("redWins", 0);
                }
            }

            StartCoroutine(WaitInput());
        }
    }

    IEnumerator WaitInput()
    {
        while (!Input.GetButton("Interact1") && !Input.GetButton("Interact2") && !Input.GetButton("Escape"))
            yield return null;
        
        if (PlayerPrefs.GetInt("blueWins") == 0 && PlayerPrefs.GetInt("redWins") == 0)
            SceneManager.LoadScene("Intro");
        else
            SceneManager.LoadScene("Main");
    }
}
