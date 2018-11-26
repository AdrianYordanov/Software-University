namespace Skeleton.Tests
{
    public class FakeDummy : ITarget
    {
        public int Health
        {
            get => 0;
        }

        public void TakeAttack(int attackPoints)
        {
        }

        public int GiveExperience()
        {
            return 20;
        }

        public bool IsDead()
        {
            return true;
        }
    }
}