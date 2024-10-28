using UnityEngine;

namespace SHOP
{
    [System.Serializable]
    public class PlayerData
    {
        public int coins = 0;

    }
    
    public static class GameDataManager
    {
        private static PlayerData _playerData = new PlayerData();


        public static int GetCoins()
        {
            return _playerData.coins;
        }

        public static void AddCoins(int amount)
        {
            _playerData.coins += amount;
        }

        public static bool CanSpendCoins(int amount)
        {
            return (_playerData.coins >= amount);
        }

        public static void SpendCoins(int amount)
        {
            _playerData.coins -= amount;
        }
        
    }
}
