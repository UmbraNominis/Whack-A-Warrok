using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject Player;
    public TextMeshProUGUI Title;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Displays the Game Over Menu with a Message.
    /// </summary>
    /// <param name="textToDisplay"> The Message to Display. </param>
    public void Display(string textToDisplay)
    {
        // Set the Message to Display
        Title.text = textToDisplay;

        // Unlock the Cursor
        Cursor.lockState = CursorLockMode.None;
        // Pause the Game
        Time.timeScale = 0f;

        // Activate the GameOver Game Object
        gameObject.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
