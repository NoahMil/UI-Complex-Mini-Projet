using SHOP;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MENU
{
    public class SceneManagerScript : MonoBehaviour
    {
        [SerializeField] private AudioClip meowSoundClip;
        
        public void QuitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            // Quit the application
            Application.Quit();
#endif
        }

        public void Play()
        {
            GameDataManager.AddCoins(500);
            GameSharedUI.instance.UpdateCoinsUIText();
            SoundFXManager.instance.PlaySoundFXClip(meowSoundClip, transform, 1f);
        }
    }
}