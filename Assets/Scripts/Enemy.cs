using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private ScreenShake screenShake;
    private Vector3 newPos;
    private Vector3 curPos;
    public float speed;
    private float insideTime;
    private void Start() {
        curPos = transform.position;
    }
    
    private void Update() {
        if ((transform.position.x - newPos.x) > 1) {
            // Out of sync, force move
            transform.position = newPos;
            StopAllCoroutines();
        }
    }

    public void UpdatePosition() {
        newPos = curPos + Vector3.left;
        curPos = newPos;
        StartCoroutine(Move(newPos,speed));
    }

    private IEnumerator Move(Vector3 dest,float wee) {
        while (transform.position != dest) {
            transform.position = Vector2.MoveTowards(transform.position,dest,wee * Time.deltaTime);
            yield return null;
        }
    } 
    private void OnTriggerStay2D(Collider2D collider) {
        
        //Check if we colided with any player
        if (collider.CompareTag("Player")) {
            insideTime += Time.deltaTime;
            if (insideTime > 0.1 & !_gameManager.endOfLevel) {
                _gameManager.endOfLevel = true;
                screenShake.TriggerShake();
                StartCoroutine(waitLose());
            }
        }
    }
    

    private IEnumerator waitLose() {
        yield return new WaitForSeconds(0.2f);
        _gameManager.RestartLevel();
    }

}
