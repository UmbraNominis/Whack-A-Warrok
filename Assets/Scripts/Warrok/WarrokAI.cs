using UnityEngine;
using UnityEngine.AI;

public class WarrokAI : MonoBehaviour
{
    public Transform player;
    public Health playerHealth;
    public Health health;
    public NavMeshAgent agent;
    public WarrokAnimationManager animationManager;

    bool attacking = false;
    public float SightRange = 20f;
    public float AttackRange = 3.5f;
    public float AttackSpeed = 2f;
    public float AttackDelay = 1.2f;
    public float AttackDamage = 1f;

    private void Awake()
    {
        // Get the Transform of the Player
        player = GameObject.Find("Player").transform;
        // Get the Health of the Player
        playerHealth = GameObject.Find("Player").GetComponent<Health>();
        // Get the Bav Mesh Agent of the Warrok
        agent = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If the Warrok is Dead...Do Nothing
        if (health.CurrentHealth <= 0) return;

        // If the Player is in Attack Range of the Warrok...
        if (Vector3.Distance(transform.position, player.position) <= AttackRange)
        {
            // ...Attack the Player
            AttackPlayer();
        }
        // Else If the Player is in the Sight Range of the Warrok...
        else if (Vector3.Distance(transform.position, player.position) <= SightRange && !attacking)
        {
            // ...Chase the Player
            MoveToPlayer();
        }
        // Else If the Warrok Is Not Attacking...
        else if (!attacking)
        {
            // ...Relax
            Relax();
        }
    }

    /// <summary>
    /// Stops the Warrok and Plays the Idle Animation
    /// </summary>
    private void Relax()
    {
        // Stop Agent Movement
        agent.isStopped = true;

        //Play Animation
        animationManager.PlayMovementAnimations(agent.velocity);
    }

    /// <summary>
    /// Moves the Warrok to the Player.
    /// </summary>
    private void MoveToPlayer()
    {
        // Look At the Player Without changing the Y axis
        transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));

        // Resume Agent Movement
        agent.isStopped = false;
        // Set the Destination of the Movement to the Location of the Player
        agent.SetDestination(player.transform.position);
        // Play the Movement Animation
        animationManager.PlayMovementAnimations(agent.velocity);
    }

    /// <summary>
    /// Attacks the Player.
    /// </summary>
    private void AttackPlayer()
    {
        // Look At the Player Without changing the Y axis
        transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));

        // Resume Agent Movement
        agent.isStopped = true;

        // If the Warrok is Already Attacking...Return
        if (attacking) return;

        // Set Attacking to True
        attacking = true;

        // Invoke the Reset Attack Method After the Attack Speed Value of the Warrok
        Invoke(nameof(ResetAttack), AttackSpeed);
        // Invoke the Deal Damage To Player Method After the Attack Delay of the Warrok
        Invoke(nameof(DealDamageToPlayer), AttackDelay);

        // Play the Attack Animation
        animationManager.PlayAttackAnimation();
    }

    /// <summary>
    /// Deals Damage to the Player.
    /// </summary>
    private void DealDamageToPlayer()
    {
        // If the Warrok is Dead...Do Nothing
        if (health.CurrentHealth <= 0) return;

        // If the Player is Still in the Attack Range...
        if (Vector3.Distance(transform.position, player.position) <= AttackRange)
        {
            // ...Deal Damage to the Player
            playerHealth.TakeDamage(AttackDamage);
        }
    }

    void ResetAttack()
    {
        // If the Warrok is Dead...Do Nothing
        if (health.CurrentHealth <= 0) return;

        // Set Attacking to False
        attacking = false;

        // End the Attackign Animation
        animationManager.EndAttackAnimation();
    }
}
