using UnityEngine;
using System.Collections;

public class TrapTriggerScript : MonoBehaviour {
	Transform child;
	// Use this for initialization
	float pressurePlateDelay = 0.5f;
	float upTime = 0.5f;
	float downTime = 0.5f;
	public bool isTimed = true;
	void Start () {
		child = transform.GetChild (0);
		if (isTimed)
			StartCoroutine ("SpikeLoop");
	}
	
	void OnTriggerEnter(Collider other){
		if(!isTimed)
		StartCoroutine ("SpikeMove");
	}

	IEnumerator SpikeLoop(){
		while (true) {
			while (child.localPosition.y < 0) {
				child.position += new Vector3 (0, 0.05f);
				yield return new WaitForFixedUpdate ();
			}
			yield return new WaitForSeconds (upTime);
			while (child.localPosition.y > -0.05) {
				child.position -= new Vector3 (0, 0.05f);
				yield return new WaitForFixedUpdate ();
			}
			yield return new WaitForSeconds (downTime);
		}
	}

	IEnumerator SpikeMove(){
		yield return new WaitForSeconds (pressurePlateDelay);
		while (child.localPosition.y < 0) {
			child.position += new Vector3(0, 0.05f);
			yield return new WaitForFixedUpdate();
		}
		yield return new WaitForSeconds (upTime);
		while (child.localPosition.y > -0.05) {
			child.position -= new Vector3(0, 0.05f);
			yield return new WaitForFixedUpdate();
		}
		yield return null;
	}
}
