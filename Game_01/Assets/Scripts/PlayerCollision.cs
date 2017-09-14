using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    //Accessing Movement Script To Disable It
    public PlayerMovement movement;

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
