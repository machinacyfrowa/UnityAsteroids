using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    CameraScript cs;
    private float maxHorizontal, maxVertical;
    private float spawnTimer, spawnInterval;

    public GameObject asteroidPrefab;
    // Start is called before the first frame update
    void Start()
    {
        cs = Camera.main.GetComponent<CameraScript>();
        
        spawnInterval = 3;
        spawnTimer = spawnInterval;
    }

    // Update is called once per frame
    void Update()
    {
        maxHorizontal = (cs.worldWidth / 2) * 1.2f;
        maxVertical = (cs.worldHeight / 2) * 1.2f;
        //Debug.Log(maxHorizontal+ " " + maxVertical);
        spawnTimer -= Time.deltaTime;
        if(spawnTimer < 0) 
        {
            Spawn();
            spawnTimer = spawnInterval;
        }
    }
    void Spawn()
    {
        float randomX, randomZ;
        //decydujemy czy spawnujemy kamulec na liniach poziomych czy pionowych
        if (Mathf.Round(Random.Range(0, 1)) == 0)
        {
            //generujemy na liniach poziomych
            randomZ = randomSign() * maxVertical; //to do poprawki powinno byc -1* albo 1*
            randomX = Random.Range(0, maxHorizontal);
        }
        else
        {
            //generujemy na liniach pionowych
            randomX = randomSign() * maxHorizontal;
            randomZ = Random.Range(0, maxVertical);
        }
        Vector3 spawnPoint = new Vector3(randomX, 0, randomZ);
        Instantiate(asteroidPrefab, spawnPoint, Quaternion.identity);
    }
    int randomSign()
    {
        int[] numbers = { -1, 1 };
        int randomIndex = Random.Range(0, numbers.Length);
        return numbers[randomIndex];
    }
}
