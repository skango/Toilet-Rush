using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zessycloud : MonoBehaviour
{
    public float speed = 0.1f;
    Vector3 startpos;
    public int x = 1;

    private void Update()
    {
        

        transform.position += x * Vector3.left * speed * Time.deltaTime;


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().gameOver.SetActive(true);
            collision.GetComponent<Player>().dedisTyvna();
            //Destroy(collision.gameObject);
        }
    }

    public void invertX()
    {
        x *= -1;
    }

    private IEnumerator Start()
    {
        InvokeRepeating(nameof(invertX), 1.5f, 1.5f);
        startpos = transform.position;
        yield return new WaitForSeconds(20);
        Destroy(gameObject);
    }
}
