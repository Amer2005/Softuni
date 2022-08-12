using System;

public class FakeWeapon : IWeapon
{
    public int AttackPoints => 100;

    public int DurabilityPoints => 5;

    public void Attack(ITarget target)
    {
       
    }
}
