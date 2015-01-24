using UnityEngine;
using System.Collections;

public class SineSpinner : MonoBehaviour {
	float speed = 0;

	void Update () {
		speed = Mathf.MoveTowards(5,200,Time.deltaTime * 5);
		transform.Rotate(0,0, speed);
	}
}
