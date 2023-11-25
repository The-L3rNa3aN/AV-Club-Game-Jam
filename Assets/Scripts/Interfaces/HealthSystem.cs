namespace AVClub.Interfaces
{
    public interface HealthSystem
    {
        public void StartHealth(int number);

        public void Heal(int number);

        public void Damage(int number);

        public void Kill();
    }
}
