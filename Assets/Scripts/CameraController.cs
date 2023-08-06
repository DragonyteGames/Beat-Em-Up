using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Transform player;

	public Vector2 
		margin, 
		smoothing;

	public BoxCollider2D thisBounds;

	private Vector3 
		_min, 
		_max;

	public bool isFollowing{get; set; }

	public void Start()
	{
		_min = thisBounds.bounds.min;
		_max = thisBounds.bounds.max;

		isFollowing = true;
	}

	public void FixedUpdate()
	{
		var x = transform.position.x;
		var y = transform.position.y;

		if(isFollowing)
		{
			if(Mathf.Abs(x - player.position.x) > margin.x)
				x = Mathf.Lerp(x, player.position.x, smoothing.x*Time.deltaTime);

			if(Mathf.Abs (y- player.position.y) > margin.y)
				y = Mathf.Lerp(y, player.position.y, smoothing.y*Time.deltaTime);

		}

		var cameraHalfWidth = GetComponent<Camera>().orthographicSize * ((float) Screen.width / Screen.height);

		x = Mathf.Clamp(x, _min.x + cameraHalfWidth, _max.x - cameraHalfWidth);
		y = Mathf.Clamp(y, _min.y + GetComponent<Camera>().orthographicSize, _max.y - GetComponent<Camera>().orthographicSize);

		transform.position = new Vector3(x,y, transform.position.z);

	}
}
