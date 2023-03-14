namespace GuardiansOfTheCode
{
    public class EnemyFactory
    {
        private int _areaLevel;
        public int AreaLevel { get => _areaLevel; }

        private Stack<Zombie> _zombiesPool = new();
        private Stack<Werewolf> _werewolvesPool = new();
        private Stack<Giant> _giantsPool = new();

        public EnemyFactory(int areaLevel)
        {
            _areaLevel = areaLevel;
            PreLoadZombies();
            PreLoadWerewolves();
            PreLoadGiants();
        }

        #region Enemy status methods
        private (int health, int level, int armor) GetZombieStatus(int areaLevel) 
        {
            int health, level, armor;
            if (areaLevel < 3)
            {
                health = 66;
                level = 2;
                armor = 15;
            }
            else if (areaLevel >= 3 && areaLevel < 10)
            {
                health = 66;
                level = 5;
                armor = 15;
            }
            else
            {
                health = 100;
                level = 8;
                armor = 15;
            }
            return (health, level, armor);
        }

        private (int health, int level, int armor) GetWerewolfStatus(int areaLevel) 
        {
            int health, level, armor;
            if (areaLevel < 5)
            {
                health = 100;
                level = 12;
                armor = 15;
            }
            else
            {
                health = 100;
                level = 20;
                armor = 15;
            }
            return (health, level, armor);
        }

        private (int health, int level, int armor) GetGiantStatus(int areaLevel) 
        {
            int health, level, armor;
            if (areaLevel < 8)
            {
                health = 100;
                level = 14;
                armor = 15;
            }
            else
            {
                health = 100;
                level = 32;
                armor = 15;
            }
            return (health, level, armor);
        }
        #endregion

        #region PreLoad enemies methods
        private void PreLoadZombies()
        {
            int count, health, armor, level;
            if (_areaLevel < 3)
            {
                count = 15;
            }
            else if (_areaLevel >= 3 && _areaLevel < 10)
            {
                count = 50;
            }
            else
            {
                count = 200;
            }
            (health, level, armor) = GetZombieStatus(_areaLevel);
            for(int i = 0; i < count; i++){
                _zombiesPool.Push(new Zombie(health, level, armor));
            }
        }

        private void PreLoadWerewolves()
        {
            int count, health, armor, level;
            if (_areaLevel < 5)
            {
                count = 15;
            }
            else
            {
                count = 50;
            }
            (health, level, armor) = GetWerewolfStatus(_areaLevel);
            for(int i = 0; i < count; i++){
                _werewolvesPool.Push(new Werewolf(health, level, armor));
            }
        }

        private void PreLoadGiants()
        {
            int count, health, armor, level;
            if (_areaLevel < 8)
            {
                count = 25;
            }
            else
            {
                count = 100;
            }
            (health, level, armor) = GetGiantStatus(_areaLevel);
            for(int i = 0; i < count; i++){
                _giantsPool.Push(new Giant(health, level, armor));
            }
        }
        #endregion

        #region Reclaim enemies methods
        public void ReclaimZombie(Zombie zombie)
        {
            (int health, int level, int armor) = GetZombieStatus(_areaLevel);
            zombie.Health = health;
            zombie.Armor = armor;
            _zombiesPool.Push(zombie);
        }

        public void ReclaimWerewolf(Werewolf werewolf)
        {
            (int health, int level, int armor) = GetWerewolfStatus(_areaLevel);
            werewolf.Health = health;
            werewolf.Armor = armor;
            _werewolvesPool.Push(werewolf);
        }

        public void ReclaimGiant(Giant giant)
        {
            (int health, int level, int armor) = GetGiantStatus(_areaLevel);
            giant.Health = health;
            giant.Armor = armor;
            _giantsPool.Push(giant);
        }
        #endregion

        #region Spawn enemies methods
        public Zombie SpawnZombie(int areaLevel)
        {
            if(_zombiesPool.Count > 0) 
            {
                return _zombiesPool.Pop();
            } 
            else 
            {
                throw new Exception("Zombies pool depleted");
            }
        }

        public Werewolf SpawnWerewolf(int areaLevel)
        {
            if(_werewolvesPool.Count > 0) 
            {
                return _werewolvesPool.Pop();
            } 
            else 
            {
                throw new Exception("Werewolves pool depleted");
            }
        }

        public Giant SpawnGiant(int areaLevel)
        {
            if(_giantsPool.Count > 0) 
            {
                return _giantsPool.Pop();
            } 
            else 
            {
                throw new Exception("Giants pool depleted");
            }
        }
        #endregion
    }
}
