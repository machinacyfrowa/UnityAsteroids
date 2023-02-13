using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float worldWidth;
    public float worldHeight;

    Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //policz wysokoœæ pola gry przy u¿yciu wysokoœci kamery nad polem gry i jej pola widzenia
        worldHeight = 2.0f * mainCamera.transform.position.y
                                * Mathf.Tan(mainCamera.fieldOfView * 0.5f * Mathf.Deg2Rad);

        //policz szerokoœæ z wspó³czynnika proporcji kamery
        worldWidth = worldHeight * mainCamera.aspect;

        Debug.Log("Wielkoœæ pola gry: " + worldWidth + " x " + worldHeight);
    }
}
