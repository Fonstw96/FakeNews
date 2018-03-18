using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour {

    void Update()
    {
        if (Input.GetButton("Interact1")
        {
            
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //void Start()
    //{
    //    Button b = gameObject.GetComponent<Button>();
    //    b.onClick.AddListener(delegate () { this.LoadLevel(); });
    //    b.onClick.AddListener(delegate () { print("Button is geklikked"); });
    //}

    


}
