using UnityEngine;
using System.Collections;

public class SineSpinner : MonoBehaviour {


	void Update () {

		transform.Rotate(0,0, Mathf.Sin(Time.deltaTime * 5000.5f));
	}
}
