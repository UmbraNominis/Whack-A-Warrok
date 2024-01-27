using TMPro;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject FloatingText;
    public AnimationManager animationManager;
    public AudioSource damageTakenAudioSource;
    public AudioClip damageTakenAudio;

    public float CurrentHealth; 
    public float MaxHealth;

    private void Awake()
    {
        // Set the Current Health to the Maximum Possible Amount
        CurrentHealth = MaxHealth;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Plays Death Animation, Death Sound Effect and Destroys the Object after an Interval.
    /// </summary>
    public virtual void Death()
    {
        // Play Death Animation
        animationManager.PlayDeathAnimation();

        // Remove the Collider of the Enemy
        gameObject.GetComponent<CapsuleCollider>().enabled = false;

        // Destroy the Object after an Interval
        Destroy(gameObject, 4f);
    }

    /// <summary>
    /// Handles Taking Damage.
    /// </summary>
    /// <param name="amount"> The Amount of Damage Taken. </param>
    public virtual void TakeDamage(float amount)
    {
        // Play Hurt Sound Effect
        damageTakenAudioSource.PlayOneShot(damageTakenAudio);

        // Reduce Health
        CurrentHealth -= amount;

        // If a Floating Text Prefab has been Assigned...Show the Amount of Damage Taken
        if (FloatingText is not null) ShowFloatingText(amount);

        // If the Current Health is Lesser or Equal to 0...
        if (CurrentHealth <= 0)
        {
            // ...Execute the Death Function
            Death();
        }
    }

    /// <summary>
    /// Shows the Damage Taken as a Floating Number.
    /// </summary>
    /// <param name="damageTaken"> The Amount of Damage Taken. </param>
    public void ShowFloatingText(float damageTaken)
    {
        // Instantiate the Floating Text Prefab
        var floatingText = Instantiate(FloatingText, transform.position, Quaternion.identity, transform);

        // Set the Text of the Prefab to the Amount of Damage Taken
        floatingText.GetComponent<TextMeshPro>().text = damageTaken.ToString();
    }
}
