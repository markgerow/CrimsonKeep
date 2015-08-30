using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class InventoryScript : MonoBehaviour {
	private static GameObject inventoryCanvas;
	private static FirstPersonController controller;
	private bool inInventory = false;
	private static InventoryScript m_instance;
	public static InventoryScript instance{
		get{
			return m_instance;
		}
	}
	// Use this for initialization
	void Start () {
		m_instance = this;
		controller = GameObject.Find ("FPSController").GetComponent<FirstPersonController> ();
		inventoryCanvas = GameObject.Find ("InventoryBackboard");
		inventoryCanvas.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.C)){
			if(inInventory){
				inventoryCanvas.SetActive(false);
				controller.inMenu = false;
				instance.inInventory = false;
			}else{
				inventoryCanvas.SetActive(true);
				controller.inMenu = true;
				instance.inInventory = true;
			}
		}
	}
}
