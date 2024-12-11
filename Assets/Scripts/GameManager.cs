using System.Collections;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI GameRestartText;
    public TextMeshProUGUI YouWinText;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        // Score is 0 when the game begins
        score = -4; 
        scoreText.text = "Score: " + score; 
        Debug.Log("Score Initialized: " + score);
        // Win or Lose status is not visible until the dog reaches owner or collides with log
        GameRestartText.gameObject.SetActive(false); 
        YouWinText.gameObject.SetActive(false);
    }


    public void UpdateScore(int scoreToAdd)
    {
        // Increase the score
        score += scoreToAdd;
        // Updates score in the UI
        scoreText.text = "Score = " + score; 
    }

    public void GameOver()
    {
        // Make the Game Over text visible again
        GameRestartText.gameObject.SetActive(true);

        // Hides the Game Restart after a few seconds
        StartCoroutine(HideGameRestartText());
    }

    private IEnumerator HideGameRestartText()
    {
        // Wait for 2 seconds and then hide the "Game Restart" text
        yield return new WaitForSeconds(2f);
        GameRestartText.gameObject.SetActive(false);
    }

    public void DisplayWinText()
    {
        // Show the "You Win!" text
        YouWinText.gameObject.SetActive(true);
    }

    // Unity calls this method when the dog collides with another object
    private void OnCollisionEnter(Collision other)
    {
        // Check if the object the dog collided with has the tag "Fence"
        if (other.gameObject.CompareTag("Fence"))
        {
             // Show "You Win!" text
            DisplayWinText();
        }
    }
}
