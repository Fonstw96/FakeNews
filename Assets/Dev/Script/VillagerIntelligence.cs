using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerIntelligence : MonoBehaviour
{
    private int iPoliticalView = 0;
    public Component MySprite;   // Please drag its own Sprite component into this thing, thank you!
    public RectTransform UICanvas;
    private ControllerProgress UIController;

    private void Start()
    {
        if (UICanvas != null)
            UIController = UICanvas.GetComponent<ControllerProgress>();
        else
            print("Missing UI Canvas");
    }

    public string ChangePoliticalView(int NewViewPoint)
    {
        if (NewViewPoint >= 0 && NewViewPoint <= 2)
        {
            if (NewViewPoint != iPoliticalView)
            {
                switch (iPoliticalView)
                {
                    case 1:   // I used to be red
                        UIController.iRedVillagers -= 1;
                        UIController.iBlueVillagers += 1;
                        break;
                    case 2:   // I used to be blue
                        UIController.iBlueVillagers -= 1;
                        UIController.iRedVillagers += 1;
                        break;
                    default:   // I used to be neutral or a clitch
                        if (NewViewPoint == 1)   // I will be red
                            UIController.iRedVillagers += 1;
                        else if (NewViewPoint == 2)   // I will be blue
                            UIController.iBlueVillagers += 1;

                        // If I will be neutral or a clitch, don't do anything...
                        break;
                }
                UIController.ChangeProgress();
            }
        }
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
