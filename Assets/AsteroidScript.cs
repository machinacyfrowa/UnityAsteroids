using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        //znajdz gracza na scenie i pobierz jego transform (wspó³rzêdne)
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        //obróæ siê w kierunku gracza
        //transform.LookAt(player);
        //popchnij nas do przodu (w kierunku gracza)
        //transform.GetComponent<Rigidbody>().AddForce(Vector3.forward, ForceMode.VelocityChange);
        //^ nie dzia³a³o - zmieniliœmy na poni¿sze

        //policz wektor od asteroidy do gracza
        Vector3 playerVector = player.position - transform.position;
        //nadaj prêdkoœæ u¿ywaj¹c policzonego wektora z maksymaln¹ si³¹ = 1 * speed
        transform.GetComponent<Rigidbody>().AddForce(playerVector.normalized * speed, ForceMode.VelocityChange);

        //nadaj nam losow¹ rotacjê
        Vector3 randomVector = new Vector3(Random.Range(0, 90), Random.Range(0, 90), Random.Range(0, 90));
        transform.GetComponent<Rigidbody>().AddTorque(randomVector);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
