using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    //Reference To Player
    public Transform player; //Using Transform Data Type To Find Position
    public Vector3 offset; //Vector 3 stores 3 floats


	// Update is called once per frame
	void Update () {
        transform.position = player.position + offset;
	}
}
