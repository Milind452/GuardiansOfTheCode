namespace GuardiansOfTheCode
{
    public class FireStaff : IWeapon
    {
        private int _damage;
        public int Damage { get => _damage; }
        private int _fireDamage;
        public int FireDamage { get => _fireDamage; }
        public FireStaff(int damage, int fireDamage)
        {
            _damage = damage;
            _fireDamage = fireDamage;
        }
        public void Use(IEnemy enemy)
        {
            enemy.Health -= Damage;
            enemy.OvertimeDamage = FireDamage;
        }
    }
}