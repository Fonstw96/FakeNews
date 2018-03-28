using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosterText : MonoBehaviour
{
    public string[] sTexts;   // Please put all positive pop-up texts here
    public float fKillDelay = 2;
    private float fKillTimer;
    public float fPopSpeed = .2f;

    private TextMesh myText;
    private Vector3 vStartPos;
    private bool bActive = true;

    void Start()
    {
        // For readability
        myText = GetComponent<TextMesh>();

        // For sabotaging
        vStartPos = transform.position;
        
        // Select a random text
        int iWhichText = Random.Range(0, sTexts.Length);

        // Make that text
        myText.text = sTexts[iWhichText];

        // Make sure text actually survives
        fKillTimer = Time.time + fKillDelay;
    }

    void Update()
    {
        if (bActive)
        {
            // Move text
            myText.transform.position += transform.up * Time.deltaTime * fPopSpeed;

            // Time's up?
            if (fKillTimer < Time.time)
            {
                // Make text invisible
                myText.color = Color.clear;

                // Tell myself to stop caring
                bActive = false;
            }
        }
    }

    public void Sabotage(string sNewText)
    {
        // Setup: Get back, change the text
        transform.position = vStartPos;
        myText.text = sNewText;
        fKillTimer = Time.time + fKillDelay;

        // Make it visible, start caring again!
        myText.color = Color.white;
        bActive = true;
    }
}
