using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour {
	private Quaternion rotation;
	private Vector3 lookAt;
	[SerializeField]private float _speed;
	private Shooting _shooting;
	public GameObject _raycast;
	public bool alive;

	void Start () {
		_raycast = GameObject.Find ("CastLineTurret");
	}
	
	void Update () {
		transform.rotation = _raycast.transform.rotation;
		transform.position += transform.up * _speed / 10;
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == ("Turret")) {
			_shooting = other.GetComponent<Shooting> ();
		}
		if (other.gameObject.tag == ("Enemy")) {
			_shooting.Shoot ();
			Destroy (gameObject);
		}
		if (other.gameObject.name == ("CastLineTurret")) {
			_raycast = other.gameObject;
		}
	}
	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.tag == ("Turret")) {
			Destroy (gameObject);
		}
	}
}
