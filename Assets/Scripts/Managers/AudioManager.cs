using System;
using UnityEngine;
using UnityEngine.Audio;

namespace Managers
{
    public class AudioManager : MonoBehaviour
    {
        public AudioClip[] sounds;
        public static AudioManager Instance;

        [SerializeField] private AudioMixer masterMixer;

        private float _newMaster;
        private float _newMusic;
        private float _newSfx;
        
        
        // Start is called before the first frame update
        void Awake ()
        {
            Instance = this;

            // foreach (Sound s in sounds)
            // {
            //     s.source = gameObject.AddComponent<AudioSource>();
            //     s.source.clip = s.clip;
            //
            //     s.source.volume = s.volume;
            //     s.source.pitch = s.pitch;
            //     s.source.loop = s.loop;
            // }
            LoadVolume();
        }

        private void Start()
        {
            Play("Theme"); // <- Plays Background Music from Audiomanager
        }

        public void Play(string audioName)
        {
            // foreach (var t in sounds)
            // {
            //     if (t == null || t.name != audioName) continue;
            //     t.source.Play();
            //     return;
            // }

            Debug.LogWarning($"Sound: {audioName} not found!");
        }

        public void SetMasterVolume(float masterLvl)
        {
            masterMixer.SetFloat("Master Volume", Mathf.Log10(masterLvl)*20);
            PlayerPrefs.SetFloat("Master Volume", masterLvl);
        }
        
        public void SetMusicVolume(float musicLvl)
        {
            masterMixer.SetFloat("Music Volume", Mathf.Log10(musicLvl) * 20);
            PlayerPrefs.SetFloat("Music Volume", musicLvl);
        }

        public void SetSfxVolume(float sfxLvl)
        {
            masterMixer.SetFloat("Sfx Volume", Mathf.Log10(sfxLvl) * 20);
            PlayerPrefs.SetFloat("Sfx Volume", sfxLvl);
        }

        public void SaveVolume()
        {
            if (Math.Abs(_newMaster - PlayerPrefs.GetFloat("Master Volume")) > 0)
            {
                PlayerPrefs.SetFloat("Master Volume", _newMaster);
            }

            if (Math.Abs(_newMusic - PlayerPrefs.GetFloat("Music Volume")) > 0)
            {
                PlayerPrefs.SetFloat("Music Volume", _newMusic);
            }

            if (Math.Abs(_newSfx - PlayerPrefs.GetFloat("Sfx Volume")) > 0)
            {
                PlayerPrefs.SetFloat("Sfx Volume", _newSfx);
            }
        }
        private void LoadVolume()
        {
            masterMixer.SetFloat("Master Volume", PlayerPrefs.GetFloat("Master Volume"));
            masterMixer.SetFloat("Music Volume", PlayerPrefs.GetFloat("Music Volume"));
            masterMixer.SetFloat("Sfx Volume", PlayerPrefs.GetFloat("Sfx Volume"));
        }
        
    }
}
