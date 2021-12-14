using Player;
using UnityEngine;

namespace Managers
{
    public enum Sizes
    {
        Small = 0,
        Medium = 1,
        Large = 2
    }
    
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        public static bool Tutorials;

        public static bool GameIsPaused;

        private static GameObject _player;
        private static PlayerMovementJoystick _playerMovement;

        public Sizes currentSize;

        private GameObject _pauseCanvas;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        private void Start()
        {
            Time.timeScale = 1;
            currentSize = Sizes.Medium;
             
            _player = GameObject.FindWithTag("Player");
            _playerMovement = _player.GetComponent<PlayerMovementJoystick>();
            _pauseCanvas = GameObject.FindWithTag("PauseMenu"); 
            _playerMovement.SetSize((int)currentSize);
            _pauseCanvas.SetActive(false);
        }

        public void OnSizeUpButton()
        {
            if (currentSize >= Sizes.Large) return;
            switch (currentSize)
            {
                case Sizes.Small: currentSize = Sizes.Medium;
                    break;
                case Sizes.Medium: currentSize = Sizes.Large;
                    break;
                case Sizes.Large:
                    return;
                default: Debug.Log($"Size doesn't exist at {currentSize}");
                    break;
            }
            _playerMovement.SetSize((int)currentSize);
        }   
        
        public void OnSizeDownButton()
        {
            if (currentSize <= Sizes.Small) return;
            switch (currentSize)
            {
                case Sizes.Small: 
                    return;
                case Sizes.Medium: currentSize = Sizes.Small;
                    break;
                case Sizes.Large: currentSize = Sizes.Medium;
                    break;
                default: Debug.Log($"Size doesn't exist at {currentSize}");
                    break;
            }
            _playerMovement.SetSize((int)currentSize);
        }

        public void OnAbilityButton()
        {
            _playerMovement.Ability((int) currentSize);
        }
        
       public void PauseGame()
        {
            if (!GameIsPaused)
            {
                Time.timeScale = 0f;
                _pauseCanvas.SetActive(true);
                GameIsPaused = true;
            }
            else
            {
                Time.timeScale = 1;
                _pauseCanvas.SetActive(false);
                GameIsPaused = false;
                AudioManager.Instance.SaveVolume();
            }

        }
    }
}