using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

	public float jumpForce = 10f;
	public GameObject Coin;
	public Sprite rockyPlatform;
	private bool hearbroken = false;
	private int collisionCount;

    private void Start()
    {
		int tinkiMiyvarxar = UnityEngine.Random.Range(0, 3);
		if (tinkiMiyvarxar  == 0)
		{
			Coin.SetActive(true);
		}

		if (transform.position.y > 50)
		{
			if (tinkiMiyvarxar != 2)
			{
				GetComponent<SpriteRenderer>().sprite = rockyPlatform;
				hearbroken = true;
			}
		}
    }

    void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.relativeVelocity.y <= 0f)
		{
			collisionCount++;			
			Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
			if (rb != null)
			{
				Vector2 velocity = rb.velocity;
				velocity.y = jumpForce;
				rb.velocity = velocity;
			}
            if (hearbroken)
            {
                Destroy(gameObject);
            }
        }
	}

}
