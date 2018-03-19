using UnityEngine;

public class PosterWinOver : MonoBehaviour
{
    public int iOwner = 0;

    private void OnTriggerEnter(Collider other)
    {
        // If it's a villager...
        if (other.CompareTag("Villager"))
        {
            // ...try and convert them, remember what it said after trying to convert it...
            string sDebugText = other.GetComponent<VillagerIntelligence>().ChangePoliticalView(iOwner);

            // ...if the villager didn't say 👍, tell the console what it DID say instead!
            if (sDebugText != "👍")
                print("Poster error: " + sDebugText);
        }
    }
}
