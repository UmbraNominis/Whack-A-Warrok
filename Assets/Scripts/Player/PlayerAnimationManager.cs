public class PlayerAnimationManager : AnimationManager
{
    const string ATTACK1 = "AttackRightToLeft";
    const string ATTACK2 = "AttackLeftToRight";
    const string ATTACK3 = "AttackTopToDown";

    public override void PlayAttackComboAnimation(int comboCount)
    {
        isAttacking = true;

        if (comboCount == 0)
            ChangeAnimationState(ATTACK1);

        if (comboCount == 1)
            ChangeAnimationState(ATTACK2);

        if (comboCount == 2)
            ChangeAnimationState(ATTACK3);
    }
}
