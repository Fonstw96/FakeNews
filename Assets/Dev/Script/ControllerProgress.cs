using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerProgress : MonoBehaviour
{
    public int iRedVillagers = 0;
    public int iBlueVillagers = 0;

    public Transform tRedUIBar;
    private RectTransform tBarSize;

    void Start()
    {
        // Take red bar's size component, for easier coding later on
        if (tRedUIBar != null)
            tBarSize = tRedUIBar.GetComponent<RectTransform>();
    }

    public void ChangeProgress()
    {
        float fRedvsBlue;

        // Just in case we end up dividing by zero...
        if (iRedVillagers == 0 && iBlueVillagers == 0)
            fRedvsBlue = .5f;
        // There won't be any scary divisions? Good, calculate % red villagers vs % blue villagers and store that!
        else
            fRedvsBlue = iRedVillagers / (float)(iRedVillagers + iBlueVillagers);

        // Scale red bar's width according to % red villagers versus % blue villagers
        tBarSize.sizeDelta = new Vector2(600 * fRedvsBlue, 50);
    }
}
