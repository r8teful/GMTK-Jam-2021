using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour{

    [SerializeField] private GameManager gameManager;

    void Awake() {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Manager");

        if (objs.Length < 1) {
            Instantiate(gameManager);
        }
    }
}