namespace GuardiansOfTheCode
{
    public class IceStaff : IWeapon
    {
        private int _damage;
        public int Damage { get => _damage; }
        private int _paralyzedFor;
        public int ParalyzedFor { get => _paralyzedFor; }
        public IceStaff(int damage, int paralyzedFor)
        {
            _damage = damage;
            _paralyzedFor = paralyzedFor;
        }

        public void Use(IEnemy enemy)
        {
            enemy.Health -= Damage;
            enemy.Paralyzed = true;
            enemy.ParalyzedFor = ParalyzedFor;
        }
    }
}