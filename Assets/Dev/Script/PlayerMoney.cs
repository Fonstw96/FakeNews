using UnityEngine;
using UnityEngine.UI;

public class PlayerMoney : MonoBehaviour
{
    public int beginMoney = 100;
    private int iMoney;
    public GameObject goPoster;
    public const int iPosterCost = 10;
    public const int iSabotageCost = 15;
    public Sprite spSabotageSprite;
    public const int iBribeCost = 25;
    private int iPlayerNo = 1;
    public GameObject goMoneyTextBox;
    private Text tMoneyText;

    void Start ()
    {
        if (goMoneyTextBox != null)
            tMoneyText = goMoneyTextBox.GetComponent<Text>();
        else
            print("No textbox defined!");

        ChangeMoney(beginMoney);

        // If this object also has a player controller, use the same player number, otherwise the default value given at the declaration above
        if (GetComponent<playerControler>() != null)
            iPlayerNo = GetComponent<playerControler>().iPlayerNo;
    }

    private void OnCollisionStay(Collision other)
    {
        // If touching a Building while pushing the Interact button and having enough money for the poster...
        if (other.collider.tag == "Building" && Input.GetButtonDown("Interact" + iPlayerNo) && iMoney >= iPosterCost)
        {
            // Lose poster money
            ChangeMoney(-iPosterCost);
            // Spawn a poster at the building's position angled 45°
            Instantiate(goPoster, new Vector3(transform.position.x, .41f, transform.position.z), new Quaternion());
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // If within range of an enemy poster while pushing the Sabotage button and having enough money for sabotaging...
        if (other.tag == "Poster" && other.GetComponent<PosterWinOver>().iOwner != iPlayerNo && Input.GetButtonDown("Sabotage" + iPlayerNo) && iMoney >= iSabotageCost)
        {
            // Lose poster money
            ChangeMoney(-iSabotageCost);
            // Change the poster's owner
            other.GetComponent<PosterWinOver>().iOwner = iPlayerNo;
            // Change its sprite to the sabotaged thing
            other.GetComponentInChildren<SpriteRenderer>().sprite = spSabotageSprite;

            // SAMPLE SPRITE ONLY REMOVE THIS WHEN IMPLEMENTING THE ACTUAL SPRITE FOR THE LOVE OF GOD //
            foreach (Transform child in other.transform)
                child.transform.localScale = new Vector3(5, 5, 5);
            // SAMPLE SPRITE ONLY REMOVE THIS WHEN IMPLEMENTING THE ACTUAL SPRITE FOR THE LOVE OF GOD //
        }
    }

    public void ChangeMoney(int iAddedMoney)
    {
        iMoney += iAddedMoney;
        if (iMoney < 0)
            iMoney = 0;

        tMoneyText.text = "Money    " + iMoney;
    }
}
