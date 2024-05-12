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

	Rigidbody2D rb;

	float movement = 0f;

	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		rb = GetComponent<Rigidbody2D>();
		InvokeRepeating(nameof(ZessyCloudGamodzaxeba), 10, 10);
	}
	
	// Update is called once per frame
	void Update () {

		Time.timeScale += 0.00001f;
		movement = Input.GetAxis("Horizontal") * movementSpeed;
		srenderer.flipX = movement <= 0;
		if (transform.position.y < deadZone.transform.position.y)
		{
			gameOver.SetActive(true);
		}
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("coin"))
		{
			coinCounter++;
			cointext.text = $"X{coinCounter}";
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
		Instantiate(ZessyCloud, transform.position + Vector3.right * 6, Quaternion.identity);
	}

    void FixedUpdate()
	{
		Vector2 velocity = rb.velocity;
		velocity.x = movement;
		rb.velocity = velocity;
	}
}