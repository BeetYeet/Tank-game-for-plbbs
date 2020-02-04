using UnityEngine;

public class Zooming : MonoBehaviour
{
	public Transform player1;
	public Transform player2;

	public Camera main;
	public float zoom = 5f;
	public float minSize = 16;
	public float back = 100f;

	[Range(0f, 1f)]
	public float followFactor = .95f;

	public Zooming current;

	// Start is called before the first frame update
	void Start()
	{
		if (current || current != this)
		{
			Destroy(this);
			return;
		}
		current = this;

		main = Camera.main;
	}

	// Update is called once per frame
	void Update()
	{
		float factor = minSize;
		float camSize = minSize / 2f;
		if (player1 != null && player2 != null)
		{
			factor = Vector3.Distance(player1.position, player2.position) / zoom;
			camSize = Mathf.Clamp(factor, minSize, 1000);
		}

		main.orthographicSize = Mathf.Lerp(main.orthographicSize, camSize, followFactor);
		Vector3 newPos = Vector3.zero;

		if (player1 != null && player2 != null)
		{
			newPos = Vector3.Lerp(player1.position, player2.position, 0.5f);
		}
		else
		{
			if (player2 != null)
				newPos = player2.position;

			if (player1 != null)
				newPos = player1.position;
		}
		newPos -= transform.forward * back;
		transform.position = Vector3.Lerp(transform.position, newPos, followFactor);
	}
}
