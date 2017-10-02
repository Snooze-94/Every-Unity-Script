using UnityEngine;
using System.Collections;

public class OrderInLayer : MonoBehaviour {

	public int sortingOrder = 0;
	private SpriteRenderer sprite;
	
	void Start()
	{
		sprite = GetComponent<SpriteRenderer>();
	}
	
	void Update()
	{
		if (sprite)
			sortingOrder = Mathf.RoundToInt(transform.position.y * -100f);
			sprite.sortingOrder = sortingOrder;
	}
}
