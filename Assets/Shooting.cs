using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {
	[SerializeField]private GameObject _bullet;
	private Quaternion rotation;
	public Transform _enemyPos;
	private bool hit;
	public int number;
	void Update () {
		if (hit) {
			rotation = Quaternion.LookRotation (_enemyPos.position - transform.position, transform.TransformDirection (Vector3.up));
			transform.rotation = new Quaternion (0, 0, rotation.z, rotation.w);
		}
	}
	void OnTriggerEnter2D(Collider2D other)
	{
			if (other.gameObject.tag == ("Enemy")) {
				hit = true;
				_enemyPos = other.transform;
				Shoot ();
				print ("hit");
		}
	}
	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.tag == ("Enemy")) {
			hit = false;
		}
	}
	public void Shoot(){
		Instantiate (_bullet, transform.position, Quaternion.identity);
	}
}
