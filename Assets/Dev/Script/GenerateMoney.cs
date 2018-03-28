using UnityEngine;

public class GenerateMoney : MonoBehaviour
{
    private float fGeneratedMoney = 0;
    public float fGenerationSpeed = 6;
    public GameObject goOwnSprite;

	void Update ()
    {
        fGeneratedMoney += Time.deltaTime * fGenerationSpeed;

        // Make yourself greener as you get richer
        float fColourVariable = 255 - Mathf.FloorToInt(fGeneratedMoney);
        if (fColourVariable < 0)
            fColourVariable = 0;
        else if (fColourVariable > 255)
            fColourVariable = 255;

        byte bRBValue = (byte)fColourVariable;
        goOwnSprite.GetComponent<SpriteRenderer>().color = new Color32(bRBValue, 255, bRBValue, 255);
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerMoney>().ChangeMoney((int)fGeneratedMoney);
            fGeneratedMoney = 0;
        }
    }
}
