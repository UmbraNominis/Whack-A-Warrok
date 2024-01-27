using UnityEngine;

public class PlayerSword : MonoBehaviour
{
    private const int MAXIMUM_COMBO_COUNT = 3;
    private const int MINIMUM_COMBO_COUNT = 0;
    public PlayerAnimationManager animationManager;
    public AudioSource swordAudio;
    public Camera cam;

    public float attackDistance = 2.5f;
    public float attackDelay = 0.3f;
    public float attackSpeed = 0.5f;
    public int attackDamage = 1;
    public AudioClip swordSwing;

    bool attacking = false;
    int comboCount = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Swing the Player's Sword.
    /// </summary>
    public void Swing()
    {
        // If the Character isn't Ready to Attack or is Already Attacking...Return
        if (attacking) return;

        // Set Attacking to True
        attacking = true;

        // Invoke Reset Attack and Attack Raycast After a Delay
        Invoke(nameof(ResetAttack), attackSpeed);
        Invoke(nameof(AttackRaycast), attackDelay);

        // Play the Attacking Animation
        animationManager.PlayAttackComboAnimation(comboCount);
        // Play the Sword Swing Sound Clip
        swordAudio.PlayOneShot(swordSwing);
        // Increment the Combo Count
        IncrementComboCount();
    }

    /// <summary>
    /// Increments the Player's Combo Count.
    /// </summary>
    private void IncrementComboCount()
    {
        // Increment the Combo Count
        comboCount += 1;

        // If the Combo Count is over the Maximum Possible Combo Count...
        if (comboCount == MAXIMUM_COMBO_COUNT)
        {
            //...Reset it to the Minimum Possible Combo Count
            comboCount = MINIMUM_COMBO_COUNT;
        }
    }

    /// <summary>
    /// Resets the Player's Attacking Value.
    /// </summary>
    void ResetAttack()
    {
        // Set Attaching to False
        attacking = false;

        // Play the End Attack Animation
        animationManager.EndAttackAnimation();
    }

    /// <summary>
    /// Fires a Raycast and Makes the Target Take Damage If it has a Health Component.
    /// </summary>
    void AttackRaycast()
    {
        // If there is an Object at the Player's Attack Distance...
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit, attackDistance))
        {
            // ...And that Object has a Health Component...
            if (hit.collider.tag != "Player" && hit.transform.TryGetComponent<Health>(out Health enemy))
            {
                // ...Deal Damage to It
                enemy.TakeDamage(attackDamage);
            }
        }
    }
}
