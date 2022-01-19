using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OG.Core;

public class PlayerLocationWinLose : MonoBehaviour
{

    [SerializeField] private float zDistance;
    private bool hasEnd = false;
    void Update()
    {
        if (transform.position.z>zDistance && !hasEnd)
        {
            WinLoseHandler.OnLevelEnd(true);
            Debug.Log("True");
            Time.timeScale = 0;
            hasEnd = true;
        }
    }
}
