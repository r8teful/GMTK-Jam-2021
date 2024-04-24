using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHead : MonoBehaviour {

    [SerializeField] private Transform segmentTransform;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private GameObject _goal;
    [SerializeField] private ScreenShake screenShake;
    [SerializeField] private UI _ui;
    [SerializeField] private PlayerController _help;

    public int _size;
    private List<Transform> _segments;
    private Vector3 newPos;
    private Transform curPos;
    private bool _busy;
    private Animator _animator;
    public float speed;
    private float insideTime;

    void Awake() {
        // Make the list and add the first player 
        _segments = new List<Transform>();
        _segments.Add(this.transform);
        Init();
        _gameManager.endOfLevel = false;
    }

    private void Start() {
        curPos = transform;
        _busy = false;
        _animator = GetComponent<Animator>();
    }

    private void Init() {
        for (int i = 0; i < _size; i++) {
            Grow();
        }
    }

    public void UpdatePosition(Vector3 movement) {
        // Only allow to move if your not moving
        if (!_busy) {
            _busy = true;
            for (int i = _segments.Count - 1; i > 0; i--) {
                StartCoroutine(Move(_segments[i], _segments[i - 1].position, speed));
            }
            newPos = curPos.position + movement;
            StartCoroutine(Move(curPos, newPos, speed));
        }

    }
    private IEnumerator Move(Transform cur, Vector3 dest, float wee) {
        while (cur.position != dest) {
            cur.position = Vector2.MoveTowards(cur.position, dest, wee * Time.deltaTime);
            yield return null;
        }
        _busy = false;
    }


    public void Grow() {
        Transform segment = Instantiate(this.segmentTransform);
        segment.position = _segments[_segments.Count - 1].position + Vector3.up;
        _segments.Add(segment);
    }



    private void OnTriggerStay2D(Collider2D collider) {
        if (!collider.CompareTag("Goal")) {
            insideTime += Time.deltaTime;
            if (insideTime > 0.1 & !_gameManager.endOfLevel) {
                _gameManager.endOfLevel = true;
                screenShake.TriggerShake();
                StartCoroutine(waitLose());
            }
        } else{
            screenShake.PlayWin();
            _animator.SetInteger("state", 4);
            _goal.transform.position = newPos + Vector3.up*.7f;
            _ui.LevelComplete();

            _help.SetSinceLastStepped();


        }
    }

    private IEnumerator waitLose() {
        yield return new WaitForSeconds(0.2f);
        
        _gameManager.RestartLevel();
    }

    // These last two are bad but I dont care, 4h left
    public void Suicide() {
        _gameManager.RestartLevel();
    }
    public void MainMenu() {
        _gameManager.LoadMainMenu();
    }

}
