using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI levelLabel;
    [SerializeField] private TextMeshProUGUI deathLabel;
    [SerializeField] private GameObject completeLevel;
    [SerializeField] private GameManager _gameManager;


    void Start()
    {
        levelLabel = GameObject.Find("LevelText").GetComponent<TextMeshProUGUI>();
        deathLabel = GameObject.Find("DeathsText").GetComponent<TextMeshProUGUI>();
        UpdateDeaths();
        UpdateLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateDeaths() {
        deathLabel.text = "Deaths:" + _gameManager.GetDeaths();
    }
    public void UpdateLevel() {
        levelLabel.text = "Level:" + _gameManager.GetLevel();
    }

    public void LevelComplete() {
        completeLevel.SetActive(true);
    }
}
