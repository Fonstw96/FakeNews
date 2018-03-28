using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosterText : MonoBehaviour
{
    public string[] sTexts;   // Please put all positive pop-up texts here
    public float fKillTime = 2;
    public float fPopSpeed = .2f;

    private TextMesh myText;

    void Start()
    {
        // For readability
        myText = GetComponent<TextMesh>();
        
        // Select a random text
        int iWhichText = Random.Range(0, sTexts.Length);

        // Make that text
        myText.text = sTexts[iWhichText];

        // Make sure text actually survives
        fKillTime += Time.time;
    }

    void Update()
    {
        // Move text
        myText.transform.position += transform.up * Time.deltaTime * fPopSpeed;

        // Time's up?
        if (fKillTime < Time.time)
        {
            // Shut the whole gameobject with this script and the text off
            gameObject.SetActive(false);
        }
    }
}
