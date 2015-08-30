using UnityEngine;
using System.Collections;

public class DamageCollisionScript : MonoBehaviour {

	public float damageToDeal = 10;

	void OnTriggerEnter(Collider other){
		HealthScript.SetHealth (-10);
	}
}
