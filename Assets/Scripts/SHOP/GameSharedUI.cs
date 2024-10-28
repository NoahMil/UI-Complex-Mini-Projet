using System;
using TMPro;
using UnityEngine;

namespace SHOP
{
    public class GameSharedUI : MonoBehaviour
    {
        #region Singleton class : GameSharedUI

        public static GameSharedUI instance;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }

        #endregion

        [SerializeField] private TMP_Text[] coinsUIText;

        private void Start()
        {
            UpdateCoinsUIText();
        }

        public void UpdateCoinsUIText()
        {
            for (int i = 0; i < coinsUIText.Length; i++)
            {
                SetCoinsText(coinsUIText[i], GameDataManager.GetCoins());
            }
        }

        private void SetCoinsText(TMP_Text textMesh, int value)
        {
            if (value >= 1000)
            {
                textMesh.text = string.Format("{0}K.{1}", (value / 1000), GetFirstDigitFromNumber(value % 1000));
            }

            else
            {
                textMesh.text = value.ToString();
            }
        }

        private int GetFirstDigitFromNumber(int num)
        {
            return int.Parse(num.ToString()[0].ToString());
        }
        
        
    }
}
