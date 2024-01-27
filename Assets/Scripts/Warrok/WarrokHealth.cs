public class WarrokHealth : Health
{
    public PlayerSword playerSword;
    public PlayerHealth playerHealth;

    public override void Death()
    {
        base.Death();

        // Increase the Attack of the Player
        playerSword.attackDamage += 1;

        // Increase the Health of the Player
        playerHealth.CurrentHealth = playerHealth.MaxHealth;
    }
}
