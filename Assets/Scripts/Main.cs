using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Main : MonoBehaviour
{
    public Rigidbody ballPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
{
        if (Input.GetMouseButtonDown(0))
        {
            // Vi bruger funktionen ScreenPointToRay p� det nuv�rende hovedkamera
            // for at f� en ray (str�le) i "verdens" koordinater ud fra musens
            // sk�rm koordinater.
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Med vektor-regning flyttes position lidt v�k fra kameraet, s� 
            // vores nye kugle ikke starter for t�t p�.
            // Pr�v evt. at �ndre tallet og se hvad der sker.
            // f'et er n�dvendigt for at lave tallet til et s�kaldt "float".
            Vector3 position = ray.origin + ray.direction * 2.0f;

            // Tilf�j en ny kugle p� den beregnede position. Quaternion.identity
            // bestemmer hvordan den er roteret i rummet.
            // For en kugle g�r det naturligvis ingen forskel.
            Rigidbody body = Instantiate(ballPrefab, position, Quaternion.identity);

            // S�t en fart i retning af str�len fra kameraet
            body.velocity = ray.direction * 5.0f;
            body.mass = 10.0f;
        }

    }
}
