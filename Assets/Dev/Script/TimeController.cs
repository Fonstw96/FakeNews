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

    private void Start()
    {
        texClock = GetComponent<Text>();
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
            goWinText.GetComponent<Text>().text = "Player x won!";

            WaitInput();
            SceneManager.LoadScene("Main");
        }

        // Change time text so the player knows
        texClock.text = Mathf.Ceil(fStartTime).ToString();
	}

    private IEnumerator WaitInput()
    {
        //bool bWait = true;
        while (!Input.GetButton("Interact1"))
            yield return null;

        goScreenFader.SetActive(false);
        goWinText.SetActive(false);
        SceneManager.LoadScene("Main");
    }
}
