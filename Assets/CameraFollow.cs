using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform target;
	public SpriteRenderer bg;
	public GameObject meoreBg;

    private void Update()
    {
        if (target.transform.position.y > 50)
		{
			meoreBg.SetActive(true);
		}
    }

    void LateUpdate () {
		if (target.position.y > transform.position.y)
		{
			Vector3 newPos = new Vector3(transform.position.x, target.position.y, transform.position.z);
			transform.position = newPos;
		}
	}
}
