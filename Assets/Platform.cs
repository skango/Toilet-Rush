using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

	public float jumpForce = 10f;
	public GameObject Coin,cherry;
	public Sprite rockyPlatform;
	private bool heartbroken = false;
	private int collisionCount;
	public GameObject Chamosxma;
	public AudioClip JumpSound;
	private AudioSource source;

    private void Start()
    {
		if (Application.isMobilePlatform)
		{
			transform.localScale = Vector3.one * 2f;
		}

		source = FindObjectOfType<AudioSource>();
		int tinkiMiyvarxar = UnityEngine.Random.Range(0, 6);
		if (tinkiMiyvarxar  is 0 or 1)
		{
			Coin.SetActive(true);
		}

		if (tinkiMiyvarxar == 5)
		{
			cherry.SetActive(true);

		}

		if (transform.position.y > 50)
		{
			if (tinkiMiyvarxar != 2)
			{
				GetComponent<SpriteRenderer>().sprite = rockyPlatform;
				heartbroken = true;
			}
		}
    }

    void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.relativeVelocity.y <= 0f)
		{
			source.PlayOneShot(JumpSound);
			collisionCount++;			
			Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
			if (rb != null)
			{
				Vector2 velocity = rb.velocity;
				velocity.y = jumpForce;
				rb.velocity = velocity;
			}
            if (heartbroken)
            {
				Instantiate(Chamosxma, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
	}

}
