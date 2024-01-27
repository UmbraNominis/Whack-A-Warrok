using UnityEngine;

public class GameWonObject : MonoBehaviour
{
    public GameOverMenu GameOverMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Displays the Game Over Menu If the Player Collides with this Area.
    /// </summary>
    /// <param name="other"> The Colliding Object which might be the Player. </param>
    private void OnTriggerEnter(Collider other)
    {
        // If the Colliding Object is the Player...
        if (other.CompareTag("Player"))
        {
            // Display the Game Over Screen With the words Game Won
            GameOverMenu.Display("Game Won");
        }

    }
}
