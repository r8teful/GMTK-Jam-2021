using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerHead _player;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Animator _animator;
    [SerializeField] private timerCircle _circle;
    [SerializeField] private AudioSource _walkAudio;
    private Vector2 lastdir;
    private float sinceStartup = 0;
    private float sinceLastPressed = 0;
    private bool firstKeyPressed = false;
    // Start is called before the first frame update
    void Start()
    {
      sinceStartup = Time.realtimeSinceStartup;
      StartCoroutine(everySecond());
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.W)) {

            sinceLastPressed = Time.realtimeSinceStartup;
            _animator.SetInteger("state", 3);
            lastdir = Vector2.up;
            newStep(lastdir);
            firstKeyPressed = true;
            return;
        } else if (Input.GetKeyDown(KeyCode.A)) {
            sinceLastPressed = Time.realtimeSinceStartup;
            lastdir = Vector2.left;
            _animator.SetInteger("state", 2);
            newStep(lastdir);
            firstKeyPressed = true;
            return;
        } else if (Input.GetKeyDown(KeyCode.S)) {
            sinceLastPressed = Time.realtimeSinceStartup;
            lastdir = Vector2.down;
            _animator.SetInteger("state", 1);
            newStep(lastdir);
            firstKeyPressed = true;
            return;
        } else if (Input.GetKeyDown(KeyCode.D)) {
            sinceLastPressed = Time.realtimeSinceStartup;
            lastdir = Vector2.right;
            _animator.SetInteger("state", 0);
            newStep(lastdir);
            firstKeyPressed = true;
            return;
        } else if (Input.GetKeyDown(KeyCode.R)) {
            _player.Suicide();
        } else if (Input.GetKeyDown(KeyCode.Escape)) {
            _player.MainMenu();
        }
            forceStep();
    }
    private IEnumerator everySecond() {
        while (true) {
            sinceStartup = Time.realtimeSinceStartup;
            yield return null;
            // yield return new WaitForSeconds(.1f);
        }
    }
    private IEnumerator LevelDone() {
        while (true) {
            sinceLastPressed = Time.realtimeSinceStartup;
            yield return null;
        }
        
    }

    private void forceStep() {
         if ((sinceStartup - sinceLastPressed) > 1 && firstKeyPressed) {
            newStep(lastdir);
            // Reset
            sinceLastPressed = sinceStartup;
         }
    }

    
    private void newStep(Vector2 dir) {
        _walkAudio.Play();
        _circle.ResetAnimation();
        _player.UpdatePosition(dir);
        _enemy.UpdatePosition();
    }

    public void SetSinceLastStepped() {
        StartCoroutine(LevelDone());
        
    }
}
