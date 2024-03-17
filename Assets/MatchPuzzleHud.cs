using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchPuzzleHud : MonoBehaviour
{
    private Camera mainCamera;
    public Transform lookatObj;

    private void Start()
    {
        mainCamera = Camera.main;
    }
    // Update is called once per frame
    void Update()
    {
        if (mainCamera != null)
        {
            lookatObj.LookAt(mainCamera.transform);
        }
    }
}
