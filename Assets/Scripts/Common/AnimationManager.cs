using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    private Animator anim;

    protected const string IDLE = "Idle";
    protected const string WALK = "Walking";
    protected const string ATTACK = "Attack";
    protected const string DEATH = "Death";

    protected string currentAnimationState;

    protected bool isAttacking = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Changes the Current Animation State to the New One.
    /// </summary>
    /// <param name="newState"> The New Animation State which will be Cross Faded Into. </param>
    public void ChangeAnimationState(string newState)
    {
        // If the New Animation is the Same as the Old One...Do not Change the State
        if (currentAnimationState == newState) return;

        // Assign the Current Animation State
        currentAnimationState = newState;

        // Cross Fade into the New Animation State
        anim.CrossFadeInFixedTime(newState, 0.2f);
    }

    /// <summary>
    /// Plays an Animation Depending on the Velocity.
    /// </summary>
    /// <param name="movementVelocity"> The Velocity which will be used to determine which Animation to Play. </param>
    public void PlayMovementAnimations(Vector3 movementVelocity)
    {
        // If the Character is Attacking...Return
        if (isAttacking) return;

        // If the Character is Standing Still...
        if (movementVelocity.x == 0 && movementVelocity.z == 0)
        {
            // ...Play the Idle Animation
            ChangeAnimationState(IDLE);
        }
        // If the Character is Moving...
        else
        {
            // ...Play the Walking Animation
            ChangeAnimationState(WALK);
        }
    }

    /// <summary>
    /// Plays the Death Animation of the Character.
    /// </summary>
    public void PlayDeathAnimation()
    {
        // Play the Death Animation
        ChangeAnimationState(DEATH);
    }

    /// <summary>
    /// Plays the Attack Animation of the Character.
    /// </summary>
    public void PlayAttackAnimation()
    {
        // Play the Attack Animation
        ChangeAnimationState(ATTACK);
    }

    /// <summary>
    /// Plays a Special Attack Animation depending on the Combo Count.
    /// </summary>
    /// <param name="comboCount"> The Value which will be used to determined the Attack Animation to Play. </param>
    public virtual void PlayAttackComboAnimation(int comboCount)
    {

    }

    /// <summary>
    /// Ends the Attack Animation.
    /// </summary>
    public void EndAttackAnimation()
    {
        // Set is Attacking to False
        isAttacking = false;

        // Play the Idle Animation
        ChangeAnimationState(IDLE);
    }
}
