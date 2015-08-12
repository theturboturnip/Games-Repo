using UnityEngine;
using System.Collections;

public class BallSpawner : MonoBehaviour {
	public void SpawnBall () {
		GameObject ball=GameObject.CreatePrimitive(PrimitiveType.Sphere);
		ball.transform.position=transform.position+Random.insideUnitSphere*0.5f;
		ball.AddComponent<Rigidbody>();
	}
}
