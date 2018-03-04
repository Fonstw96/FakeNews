using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerIntelligence : MonoBehaviour
{
    private int iPoliticalView = 0;
    public Component MySprite;   // Please drag its own Sprite component into this thing, thank you!

    public string ChangePoliticalView(int NewViewPoint)
    {
        if (NewViewPoint >= 0 && NewViewPoint <= 2)
            iPoliticalView = NewViewPoint;
        else
            return "Set view to either 0, 1 or 2";

        switch (iPoliticalView)
        {
            case 1:
                MySprite.GetComponent<SpriteRenderer>().color = Color.blue;
                break;
            case 2:
                MySprite.GetComponent<SpriteRenderer>().color = Color.red;
                break;
            default:   // Neutral
                MySprite.GetComponent<SpriteRenderer>().color = Color.yellow;
                break;
        }

        return "👍";
    }
}
