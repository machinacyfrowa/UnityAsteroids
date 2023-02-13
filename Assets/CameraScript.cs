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
        //policz wysoko�� pola gry przy u�yciu wysoko�ci kamery nad polem gry i jej pola widzenia
        worldHeight = 2.0f * mainCamera.transform.position.y
                                * Mathf.Tan(mainCamera.fieldOfView * 0.5f * Mathf.Deg2Rad);

        //policz szeroko�� z wsp�czynnika proporcji kamery
        worldWidth = worldHeight * mainCamera.aspect;

        //Debug.Log("Wielko�� pola gry: " + worldWidth + " x " + worldHeight);
    }
}
