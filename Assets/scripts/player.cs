using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject Sbullet;
    [SerializeField] float firerate;
    private float tipodisparo=1;
    private float nextbullet = 0;
    private float timepressed = 0;
    float minX, maxX, maxY, minY;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 esqInfIzq= Camera.main.ViewportToWorldPoint(new Vector2(0,0));
        minX = esqInfIzq.x + (GetComponent<CircleCollider2D>().radius);
        minY = esqInfIzq.y + (GetComponent<CircleCollider2D>().radius);
        Vector2 esqSupDer = Camera.main.ViewportToWorldPoint(new Vector2(1,1));
        maxX = esqSupDer.x - (GetComponent<CircleCollider2D>().radius);
        maxY = esqSupDer.y - (GetComponent<CircleCollider2D>().radius);
        tipodisparo = 1;
    }

    // Update is called once per frame
    void Update()
    {
        float movH = Input.GetAxis("Horizontal");
        float movV = Input.GetAxis("Vertical");

        transform.Translate(new Vector2(movH * speed * Time.deltaTime, movV * speed * Time.deltaTime));
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, minX, maxX), Mathf.Clamp(transform.position.y, minY, maxY));
        if (Input.GetKeyDown(KeyCode.Q))
        {
            tipodisparo *= -1;
        }
            if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextbullet && tipodisparo==1)
            {
                nextbullet = Time.time + firerate;
                Instantiate(bullet, transform.position, transform.rotation);
            }
        if (Input.GetKeyDown(KeyCode.Space) && tipodisparo == -1)
        {

            timepressed = Time.time;
        }
            if (Input.GetKeyUp(KeyCode.Space) && tipodisparo == -1)
            {
            Debug.Log(Time.time - timepressed);
            if ((Time.time - timepressed) >= 3)
                {
                    Instantiate(Sbullet, transform.position, transform.rotation);
                }

            }
                
        



    }
}
