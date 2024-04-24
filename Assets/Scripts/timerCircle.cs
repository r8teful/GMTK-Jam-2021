using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timerCircle : MonoBehaviour
{
    private Animator myAnimator;
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    public void ResetAnimation() {
        if (!gameObject.activeSelf) {
            gameObject.SetActive(true);
            myAnimator = GetComponent<Animator>();
        }
        myAnimator.SetTrigger("Reset");
    }
}
