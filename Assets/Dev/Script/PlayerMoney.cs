using UnityEngine;
using UnityEngine.UI;

public class PlayerMoney : MonoBehaviour
{
    public int beginMoney = 100;
    private int iMoney;
    public GameObject goPoster;
    public const int iPosterCost = 10;
    private string sPlayerNo = "1";
    public GameObject goMoneyTextBox;
    private Text tMoneyText;
    public AudioClip PosterAudio;
    AudioSource audioSource;


    void Start ()
    {
        if (goMoneyTextBox != null)
            tMoneyText = goMoneyTextBox.GetComponent<Text>();
        else
            print("No textbox defined!");

        ChangeMoney(beginMoney);

        // If this object also has a player controller, use the same player number, otherwise the default value given at the declaration above
        if (GetComponent<playerControler>() != null)
            sPlayerNo = GetComponent<playerControler>().sPlayerNo;

        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionStay(Collision other)
    {
        // If touching a Building while pushing the Interact button and having enough money for the poster...
        if (other.collider.tag == "Building" && Input.GetButtonDown("Interact"+sPlayerNo) && iMoney >= iPosterCost)
        {
            // Lose poster money
            ChangeMoney(-iPosterCost);
            // Spawn a poster at the building's position angled 45°
            Instantiate(goPoster, new Vector3(transform.position.x, .41f, transform.position.z), new Quaternion());
            //audioSource.PlayOneShot(PosterAudio, 0.7F);
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
