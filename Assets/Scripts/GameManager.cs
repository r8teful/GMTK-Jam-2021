using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{

    [SerializeField] private AudioSource _music;
    private int _deaths;
    private int _level;
    public bool endOfLevel;
    // Start is called before the first frame update
    private void Awake() {
        DontDestroyOnLoad(this.gameObject);
        
    }

    private void Update() {
        if (_music = null) {
            Debug.Log("Setting audio");
            _music = GetComponent<AudioSource>();
        }
    }
    public void RestartLevel() {
        //PlayDeathSound();
        _deaths++;
       // endOfLevel = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel() {
        //endOfLevel = false;
        _level = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(_level);
        // Handle for last level
    }

    public void StartGame() {
        _level = 1;
        SceneManager.LoadScene(_level);
    }

    public void LoadMainMenu() {
        _level = 1;
        _deaths = 0;
        SceneManager.LoadScene(0);
    }

    public int GetDeaths() {
        return _deaths;
    }
    public void AddDeaths() {
        _deaths++;
    }
    public int GetLevel() {
        _level = SceneManager.GetActiveScene().buildIndex;
        return _level;
    }

    public void MusicVolume(float volume) {
        Debug.Log("Game Manager Changing volume: " + _music.volume);
        _music.volume = volume;
    }
}
