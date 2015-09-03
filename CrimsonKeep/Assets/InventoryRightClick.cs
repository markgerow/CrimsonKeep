using UnityEngine;
using UnityEngine.EventSystems;

using System.Collections;

class InventoryRightClick : MonoBehaviour//, IRightPointerClickHandler
{
	public bool overlapping { get; set;}
	public int index = 0;
	public static bool test(){
		return true;
	}

	public void Update(){
		//Debug.Log (hitbox.rect);
		if (Input.GetMouseButtonDown(1) && overlapping) {
			//Debug.Log("Right Click Successful");
			InventoryScript.instance.OnRightClickInventoryEvent(index);
		}
	}
}
