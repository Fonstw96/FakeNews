using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    public int beginMoney = 100;
    private int iMoney;
    public Transform tPoster;
    private const int iPosterCost = 10;

    void Start ()
    {
        iMoney = beginMoney;
    }

    void Update ()
    {
        // if interaction button and enough money for a poster
		if (Input.GetButtonDown("Fire1") && iMoney > iPosterCost)
        {
            // Poster money
            iMoney -= iPosterCost;

            Instantiate(tPoster, transform.position, new Quaternion());
        }
	}
}
