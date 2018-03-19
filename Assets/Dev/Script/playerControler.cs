using UnityEngine;

public class playerControler : MonoBehaviour
{
    public string sPlayerNo = "1";
    public float moveSpeed;
    public Rigidbody theRB;

    public GameObject character;
    private Animator anim;
    //public float jumpForce;

    // Use this for initialization
    void Start()
    {
        theRB = GetComponent<Rigidbody>();
        anim = character.GetComponent<Animator>();

        anim.Play("Idle");
        anim.Play("Player2Idle");
    }

    // Update is called once per frame
    void Update()
    {
        theRB.velocity = new Vector3(Input.GetAxis("Horizontal"+sPlayerNo) * moveSpeed, theRB.velocity.y, Input.GetAxis("Vertical"+sPlayerNo) * moveSpeed);

        //if (Input.GetButtonDown("Jump"))
        //{
        //    theRB.velocity = new Vector3(theRB.velocity.x, jumpForce, theRB.velocity.z);
        //}

        if (Input.GetAxis("Horizontal" + sPlayerNo) > 0)
        {
            //Debug.Log("right");
            anim.Play("WalkRight");
            anim.Play("Player2Right");

        }

        if (Input.GetAxis("Horizontal" + sPlayerNo) < 0)
        {
            //Debug.Log("left");
            anim.Play("WalkLeft");
            anim.Play("Player2Left");
        }

    }
}
