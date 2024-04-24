using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class deathNumberEndScreen : MonoBehaviour
{
    [SerializeField] private GameManager manager;
    [SerializeField] private TextMeshProUGUI deathLabel;
    [SerializeField] private Button StartButton;

    private int deaths;
    // Start is called before the first frame update
    void Start()
    {
        StartButton.onClick.AddListener(MainMenu);
        deaths = manager.GetDeaths();
        Debug.Log(deaths);
        deathLabel.text = deaths.ToString();
       
        
    }

    private void MainMenu() {
        manager.LoadMainMenu();
    }
}
