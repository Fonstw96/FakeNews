using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    public int beginMoney = 100;
    public int iMoney;
    public Object tPoster;
    public const int iPosterCost = 10;

    void Start ()
    {
        iMoney = beginMoney;
    }

    private void OnCollisionStay(Collision other)
    {
        // If touching a Building while pushing the Interact button and having enough money for the poster...
        if (other.collider.tag == "Building" && Input.GetButtonDown("Fire1") && iMoney > iPosterCost)
        {
            // Lose poster money
            iMoney -= iPosterCost;
            // Spawn a poster at the building's position angled 45°
            Instantiate(tPoster, new Vector3(transform.position.x, .41f, transform.position.z), new Quaternion());
        }
    }
}
