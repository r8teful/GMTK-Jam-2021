using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextLevel : MonoBehaviour
{
    [SerializeField] private GameManager _gm;
    // Start is called before the first frame update
    
    private void NextLevel() {
        _gm.NextLevel();
    }
}
