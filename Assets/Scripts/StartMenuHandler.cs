using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StartMenuHandler : MonoBehaviour
{
    [SerializeField] private Button StartButton;
    [SerializeField] private Button SettingsButton;
    [SerializeField] private Canvas SettingsCanvas;

    [SerializeField] private GameManager _gameManager;
    [SerializeField] private Slider MusicVolumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        StartButton.onClick.AddListener(StartGame);
        SettingsButton.onClick.AddListener(OpenSettings);
        MusicVolumeSlider.onValueChanged.AddListener(delegate { MusicVolumeSliderChanged(); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame() {
        _gameManager.StartGame();
    }

    public void OpenSettings() {
        SettingsCanvas.enabled = true;
    }

    public void MusicVolumeSliderChanged() {
        _gameManager.MusicVolume(MusicVolumeSlider.value);
    }

}
