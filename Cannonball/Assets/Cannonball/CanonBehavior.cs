using UnityEngine;
using System.Collections;

public class CanonBehavior : MonoBehaviour {

	[SerializeField]
	public bool fireCanon = false; 

	[SerializeField]
	private GameObject cannonball;

	[SerializeField]
	private float shootAngle;

	[SerializeField]
	public Transform target;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if (fireCanon == true) {
			fireCanon = false;
			var ball = (GameObject)Instantiate(cannonball, transform.position, Quaternion.identity);
			ball.GetComponent<Rigidbody>().velocity = BallisticVel(target, shootAngle);
			Destroy(ball, 10);
		}
	
	}

	//Copied from http://answers.unity3d.com/questions/148399/shooting-a-cannonball.html

	Vector3 BallisticVel(Transform target, float angle) {
		var dir = target.position - transform.position;  // get target direction
		var h = dir.y;  // get height difference
		dir.y = 0;  // retain only the horizontal direction
		var dist = dir.magnitude ;  // get horizontal distance
		var a = angle * Mathf.Deg2Rad;  // convert angle to radians
		dir.y = dist * Mathf.Tan(a);  // set dir to the elevation angle
		dist += h / Mathf.Tan(a);  // correct for small height differences
		// calculate the velocity magnitude
		var vel = Mathf.Sqrt(dist * Physics.gravity.magnitude / Mathf.Sin(2 * a));
		return vel * dir.normalized;
	}
}
