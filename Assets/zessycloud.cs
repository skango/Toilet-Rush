using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zessycloud : MonoBehaviour
{
    public float speed = 0.1f;
    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().gameOver.SetActive(true);
            Destroy(collision.gameObject);
        }
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
