using UnityEngine;

public class FenceCollision : MonoBehaviour
{
    public GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object colliding with the fence is the dog
        if (other.CompareTag("Dog"))
        {
            gameManager.DisplayWinText(); // Call the method to display "You Win!" text
            other.transform.position = new Vector3(-587, 1, 139); 
        }
    }
}