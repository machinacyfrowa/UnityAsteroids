using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        //znajdz gracza na scenie i pobierz jego transform (wsp�rz�dne)
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        //obr�� si� w kierunku gracza
        //transform.LookAt(player);
        //popchnij nas do przodu (w kierunku gracza)
        //transform.GetComponent<Rigidbody>().AddForce(Vector3.forward, ForceMode.VelocityChange);
        //^ nie dzia�a�o - zmienili�my na poni�sze

        //policz wektor od asteroidy do gracza
        Vector3 playerVector = player.position - transform.position;
        //nadaj pr�dko�� u�ywaj�c policzonego wektora z maksymaln� si�� = 1 * speed
        transform.GetComponent<Rigidbody>().AddForce(playerVector.normalized * speed, ForceMode.VelocityChange);

        //nadaj nam losow� rotacj�
        Vector3 randomVector = new Vector3(Random.Range(0, 90), Random.Range(0, 90), Random.Range(0, 90));
        transform.GetComponent<Rigidbody>().AddTorque(randomVector);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;
        if(other.CompareTag("Bullet"))
        {
            // zderzyli�my si� z pociskiem - usu� pocisk i asteroid� z gry

            //zniszcz pocisk
            Destroy(other);

            //zniszcz asteroide
            Destroy(gameObject);
        }
    }
}
