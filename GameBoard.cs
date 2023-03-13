namespace GuardiansOfTheCode
{
    public class GameBoard
    {
        private PrimaryPlayer _player;

        public GameBoard()
        {
            _player = PrimaryPlayer.Instance;
            _player.Weapon = new Sword(12, 8);
        }

        public void PlayArea(int lvl)
        {
            if (lvl == 1){
                PlayFirstLevel();
            }
        }

        public void PlayFirstLevel() {
            const int currentLvl = 1;
            List<IEnemy> enemies = new();
            for(int i = 0; i < 10; i++) 
            {
                enemies.Add(EnemyFactory.SpawnZombie(currentLvl));
            }
            for(int i = 0; i < 3; i++) 
            {
                enemies.Add(EnemyFactory.SpawnWerewolf(currentLvl));
            }

            foreach (var enemy in enemies)
            {
                System.Console.WriteLine(enemy.GetType());
            }
        }
    }
}
