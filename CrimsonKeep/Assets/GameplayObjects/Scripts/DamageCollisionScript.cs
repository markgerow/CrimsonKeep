using UnityEngine;
using System.Collections;

public class DamageCollisionScript : MonoBehaviour {

	public float damageToDeal = 10;

	void OnTriggerEnter(Collider other){
		if(other.gameObject.layer == 9)
		HealthScript.SetHealth (-10);
	}
}
