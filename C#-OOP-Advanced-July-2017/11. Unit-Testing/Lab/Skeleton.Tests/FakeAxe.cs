namespace Skeleton.Tests
{
    public class FakeAxe : IWeapon
    {
        public int AttackPoints
        {
            get => 10;
        }

        public int DurabilityPoints
        {
            get => 10;
        }

        public void Attack(ITarget target)
        {
            target.TakeAttack(this.AttackPoints);
        }
    }
}