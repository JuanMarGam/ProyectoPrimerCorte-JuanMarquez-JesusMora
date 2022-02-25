using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    Rigidbody2D myBody;
    [SerializeField] float speed;
    [SerializeField] float vida;
    float minX, minY, maxX, maxY;
    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        Vector2 esqInfIzq = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        minX = esqInfIzq.x + (GetComponent<CircleCollider2D>().radius);
        minY = esqInfIzq.y;
        Vector2 esqSupDer = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        maxX = esqSupDer.x - (GetComponent<CircleCollider2D>().radius);
        maxY = esqSupDer.y;
        

    }

    // Update is called once per frame
    void Update()
    {

        if (vida == 0) {
            Destroy(gameObject);
        }
            transform.position = new Vector2(Mathf.Clamp(transform.position.x, minX, maxX), Mathf.Clamp(transform.position.y, minY, maxY));
        if (transform.position[0] >= maxX)
            speed = speed * -1;
        if (transform.position[0] <= minX)
            speed = speed * -1;
           
    }

    private void FixedUpdate()
    {
        myBody.velocity = new Vector2(speed, myBody.velocity.y);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "bullet(Clone)")
        {
            vida -= 1;
        }
        if (collision.gameObject.name == "Sbullet(Clone)")
        {
            vida = 0;
        }
    }
}
