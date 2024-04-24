using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour {
    // Code by Matt Buckley
    // from https://medium.com/nice-things-ios-android-development/basic-2d-screen-shake-in-unity-9c27b56b516

    [SerializeField] private AudioSource _deathsound;
    [SerializeField] private AudioSource _winssound;
    // Transform of the GameObject you want to shake
    private Transform transform;

    // Desired duration of the shake effect
    private float shakeDuration = 0f;

    // A measure of magnitude for the shake. Tweak based on your preference
    private float shakeMagnitude = 0.2f;

    // A measure of how quickly the shake effect should evaporate
    private float dampingSpeed = .5f;

    // The initial position of the GameObject
    Vector3 initialPosition;


    void Awake() {
        if (transform == null) {
            transform = GetComponent(typeof(Transform)) as Transform;
        }
    }
    void OnEnable() {
        initialPosition = transform.localPosition;
    }

    void Update() {
        if (shakeDuration > 0) {
            transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;

            shakeDuration -= Time.deltaTime * dampingSpeed;
        } else {
            shakeDuration = 0f;
            transform.localPosition = initialPosition;
        }
    }
    public void TriggerShake() {
        // Also play death sound
        //Debug.Log("Sound Played");
        _deathsound.Play();
       shakeDuration = 0.2f;
    }

    // Shouldn't put this here but who cares
    public void PlayWin() {
        _winssound.Play();
    }
}
