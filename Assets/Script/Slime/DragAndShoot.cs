using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndShoot : MonoBehaviour
{
	public float power = 10f;
	public Rigidbody2D rb;

	public Vector2 minpower;
	public Vector2 maxpower;
	private bool onland = true;
	public Animator animator;
	public Collider2D onlandtrigger;
	private bool facingLeft = true;
	private void OnTriggerEnter2D(Collider2D other)
	{
		onland = true;
	}
	Camera cam;
	Vector2 force;
	Vector3 startpoint;
	Vector3 endpoint;

	void Flip()
	{
		facingLeft = !facingLeft;
		Vector3 Scaler = transform.localScale;
		Scaler.x *= -1;
		transform.localScale = Scaler;
	}

	private void Start()
	{
		cam = Camera.main;
	}
	private void Update()
	{

		if (onland)
		{
			if (Input.GetMouseButtonDown(0))
			{
				startpoint = cam.ScreenToWorldPoint(Input.mousePosition);
				startpoint.z = 15;

			}
			if (Input.GetMouseButtonUp(0))
			{
				endpoint = cam.ScreenToWorldPoint(Input.mousePosition);
				endpoint.z = 15;

				force = new Vector2(Mathf.Clamp(startpoint.x - endpoint.x, minpower.x, maxpower.x), Mathf.Clamp(startpoint.y - endpoint.y, minpower.y, maxpower.y));
				rb.AddForce(force * power, ForceMode2D.Impulse);
				onland = false;
				if (startpoint.x > endpoint.x && facingLeft == true)
				{
					Flip();
				}
				if (startpoint.x < endpoint.x && facingLeft != true)
				{
					Flip();
				}
			}

		}

	}

}
