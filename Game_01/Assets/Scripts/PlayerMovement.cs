using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    //Accessing Rigid Body
    public Rigidbody rb;

    //Public used so it can be used in the inspector
    public float fowardForce = 2000f;
    public float sideForce = 300f;

	// Use this for initialization
	void Start () {
        
	}
	
	

	void FixedUpdate () { //Use Fixed Update For Physics
        rb.AddForce(0, 0, fowardForce * Time.deltaTime);

        //Player Control
        if (Input.GetKey("d"))
        {
            rb.AddForce(sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange); //Changing force type
        }

        if(Input.GetKey("a"))
        {
            rb.AddForce(-sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }

        foreach (Touch touch in Input.touches)
        {
            if (touch.position.x < Screen.width / 2)
            {
                MoveLeft();
            }
            else if (touch.position.x > Screen.width / 2)
            {
                MoveRight();
            }
        }
    }

    void MoveRight()
    {
        rb.AddForce(sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    }

    void MoveLeft()
    {
        rb.AddForce(-sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    }
}
