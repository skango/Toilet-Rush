using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour {

	public float movementSpeed = 10f;
	public GameObject gameOver;
	public GameObject deadZone,ZessyCloud;
	public SpriteRenderer srenderer;
	public Sprite jumber, nodar;
	public TMP_Text cointext;
	private int coinCounter;
	public AudioClip coinsound, boostsound, dedaMoetyna;

	Rigidbody2D rb;

	float movement = 0f;
	float horizontal;
	private AudioSource source;
	private float currentH = 1000;


	// Use this for initialization
	void Start () {
		if (Application.isMobilePlatform)
		{
			transform.localScale = Vector3.one * 1.1f;
		}
		source = FindObjectOfType<AudioSource>();
		Time.timeScale = 1;
		rb = GetComponent<Rigidbody2D>();
		InvokeRepeating(nameof(ZessyCloudGamodzaxeba), 10, 10);
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y > currentH)
		{
			FindObjectOfType<LevelGenerator>().Start();
			currentH += 500;
		}
		Time.timeScale += 0.00001f;
		movement = (horizontal != 0 ? horizontal : 
			Input.GetAxis("Horizontal")) * movementSpeed;
		srenderer.flipX = movement <= 0;
		if (transform.position.y < deadZone.transform.position.y)
		{
			source.PlayOneShot(dedaMoetyna);
			gameOver.SetActive(true);
			Destroy(gameObject);
		}
	}

	public void SetHorizontal(float value)
	{
		horizontal = value;

	}

	public void dedisTyvna()
	{
        source.PlayOneShot(dedaMoetyna);
		Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("coin"))
		{
			source.PlayOneShot(coinsound);
			coinCounter++;
			cointext.text = $"X{coinCounter}";
			Destroy(collision.gameObject);
		}
		if (collision.CompareTag("cherry"))
		{
            source.PlayOneShot(boostsound);
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            Vector2 velocity = rb.velocity;
            velocity.y = 20;
            rb.velocity = velocity;
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("platform"))
		{
			srenderer.sprite = jumber;
		}
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
		StartCoroutine(SetNodar(collision));
    }

	IEnumerator SetNodar(Collision2D collision)
	{
		yield return new WaitForSeconds(0.5f);
        if (collision.gameObject.CompareTag("platform"))
        {
            srenderer.sprite = nodar;
        }
    }

    public void ZessyCloudGamodzaxeba()
	{
		Instantiate(ZessyCloud, transform.position + Vector3.right * 1f + Vector3.up * 6, Quaternion.identity);
	}

    void FixedUpdate()
	{
		Vector2 velocity = rb.velocity;
		velocity.x = movement;
		Debug.Log("Velocity " + movement);
		rb.velocity = velocity;
	}
}
