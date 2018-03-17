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
        fStartTime -= Time.deltaTime;

        // Out of time? Reset the level
        if (fStartTime <= 0)
            SceneManager.LoadScene("Main");

        // Change time text so the player knows
        tText.text = Mathf.Ceil(fStartTime).ToString();
	}
}
