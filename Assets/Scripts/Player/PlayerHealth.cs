public class PlayerHealth : Health
{
    public GameOverMenu GameOverMenu;
    public HealthBar HealthBar;

    public override void TakeDamage(float amount)
    {
        base.TakeDamage(amount);

        // Update the Player Health Bar
        HealthBar.UpdateHealthBar();
    }

    public override void Death()
    {
        // Display the Game Over Screen
        GameOverMenu.Display("Game Over");
    }
}
