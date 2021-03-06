﻿using UnityEngine;

public class ControllerProgress : MonoBehaviour
{
    public int iRedVillagers = 0;
    public int iBlueVillagers = 0;
    private float fBluevsRed = .5f;

    public GameObject goBlueUIBar;
    private RectTransform tBarSize;

    public GameObject[] goWinOrb;   // Please set objects 0..3 here kthnxbye

    void Start()
    {
        ShowWins();

        // Take red bar's size component, for easier coding later on
        if (goBlueUIBar != null)
            tBarSize = goBlueUIBar.GetComponent<RectTransform>();
    }

    private void Update()
    {
        ChangeProgress();
        //print("B: " + iBlueVillagers + ", R: " + iRedVillagers);
    }

    public void ChangeProgress()
    {
        // Just in case we end up dividing by zero...
        if (iBlueVillagers == 0 && iRedVillagers == 0)
            fBluevsRed = .5f;
        // There won't be any scary divisions? Good, calculate % red villagers vs % blue villagers and store that!
        else
            fBluevsRed = iBlueVillagers / (float)(iBlueVillagers + iRedVillagers);

        // Scale red bar's width according to % red villagers versus % blue villagers
        tBarSize.sizeDelta = new Vector2(600 * fBluevsRed, 50);
    }

    public void ShowWins()
    {
        // For easier coding
        int blueWins = PlayerPrefs.GetInt("blueWins");
        int redWins = PlayerPrefs.GetInt("redWins");

        // Show how many wins someone has
        if (blueWins >= 1)
            goWinOrb[1].SetActive(true);
        if (blueWins >= 2)
            goWinOrb[0].SetActive(true);
        if (redWins >= 1)
            goWinOrb[2].SetActive(true);
        if (redWins >= 2)
            goWinOrb[3].SetActive(true);

    }
}
