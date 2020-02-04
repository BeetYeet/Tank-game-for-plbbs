using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloatingText : MonoBehaviour
{
	public float destroyTime = 5f;
	public Vector3 offset = new Vector3(0f, 1f, 0f);
	public string text;
	public TextMeshProUGUI textMesh;
	public HoverAbove hoverAbove;
	public float scaleLoss;

	// Start is called before the first frame update
	void Start()
	{
		Destroy(gameObject, destroyTime);
		textMesh.text = text;
		hoverAbove.target = transform.parent;

	}

	// Update is called once per frame
	void Update()
	{
		hoverAbove.relativePosition += offset * Time.deltaTime;


	}
	private void FixedUpdate()
	{
		transform.localScale = Vector3.Lerp(transform.localScale, transform.localScale * scaleLoss, Time.fixedDeltaTime);
	}
}
