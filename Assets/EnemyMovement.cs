using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
	[SerializeField]private List<Transform> _wayPoints = new List<Transform>();
	public List<Transform> _getWaypoints{get{return _wayPoints;} set {_wayPoints = value;}}
	[SerializeField]private float enemyClose;
	private Vector3 desiredDirection;
	[SerializeField]private float speed;
	private int _wayPointIndex;
	void Start () {

	}

	void Update () {
		if (Vector3.Distance (transform.position, _wayPoints [_wayPointIndex].position) < enemyClose) {
			_wayPointIndex++;
		}
		desiredDirection = _wayPoints [_wayPointIndex].position - transform.position;
		desiredDirection.Normalize ();
		desiredDirection *= speed / 10;
		transform.position += desiredDirection;
	}
	void OnDrawGizmos(){
		for (int i = 1; i < _wayPoints.Count; i++) {
			Gizmos.color = Color.green;
			Gizmos.DrawLine (_wayPoints [i].position, _wayPoints [i - 1].position);
		}
	}
}
