namespace GuardiansOfTheCode
{
    public class Werewolf : IEnemy
    {
        private int _health;
        private readonly int _level;
        public int Health { get => _health; set => _health = value; }

        public int Level => _level;

        public void Attack(PrimaryPlayer player)
        {
            Console.WriteLine("Werewolf attacking " + player.Name);
        }

        public void Defend(PrimaryPlayer player)
        {
            Console.WriteLine("Werewolf defending from " + player.Name);
        }
    }
}