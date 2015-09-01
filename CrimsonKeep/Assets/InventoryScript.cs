using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class InventoryScript : MonoBehaviour {
	private static GameObject inventoryCanvas;
	private static FirstPersonController controller;
	private bool inInventory = false;
	private static InventoryScript m_instance;
	[SerializeField] public GameObject[] inventoryButtons;
	[SerializeField] public GameObject[] equipmentButtons;
	public static InventoryScript instance{
		get{
			return m_instance;
		}
	}
	// Use this for initialization
	void Start () {
		m_instance = this;
		controller = GameObject.Find ("FPSController").GetComponent<FirstPersonController> ();
		inventoryCanvas = GameObject.Find ("MenuBackboard");
		inventoryCanvas.SetActive (false);
	}

	public void OnClickInventoryEvent(int box){
		if (instance.inventoryButtons [box].transform.childCount > 1) {
			if(MouseFollowScript.instance.gameObject.GetComponent<Image>().enabled == false){
			MouseFollowScript.instance.Pickup (box, true, instance.inventoryButtons [box].transform.GetChild (0).gameObject.GetComponent<InventoryItem> ().sprite);
			instance.inventoryButtons [box].transform.GetChild (0).gameObject.GetComponent<Image> ().enabled = false;
			}else{
				OnIntemtoryItemSlotSwap(box);
				MouseFollowScript.instance.DeSelect();
			}
		}
	}

	public void OnIntemtoryItemSlotSwap(int box){
		GameObject destinationItem = instance.inventoryButtons [MouseFollowScript.instance.index].transform.GetChild(0).gameObject;
		GameObject heldItem = instance.inventoryButtons [box].transform.GetChild(0).gameObject;
		heldItem.transform.SetParent (instance.inventoryButtons [box].transform);
		destinationItem.transform.SetParent(instance.inventoryButtons [MouseFollowScript.instance.index].transform);
		//heldItem
		InventoryItem item = instance.inventoryButtons[MouseFollowScript.instance.index].transform.GetChild(0).gameObject.GetComponent<InventoryItem>(); 
		item.sprite = heldItem.GetComponent<InventoryItem>().sprite;
		item.name = heldItem.GetComponent<InventoryItem>().name;
		item.isEquipment = heldItem.GetComponent<InventoryItem>().isEquipment;
		Image img = heldItem.GetComponent<Image>();
		img.enabled = true;
		img.sprite = item.sprite;
		img.color = Color.white;
		//destinationItem
		InventoryItem destItem = instance.inventoryButtons[box].transform.GetChild(0).gameObject.GetComponent<InventoryItem>(); 
		destItem.sprite = destinationItem.GetComponent<InventoryItem>().sprite;
		destItem.name = destinationItem.GetComponent<InventoryItem>().name;
		destItem.isEquipment = destinationItem.GetComponent<InventoryItem>().isEquipment;
		Image destImg = destinationItem.GetComponent<Image>();
		destImg.enabled = true;
		destImg.sprite = item.sprite;
		destImg.color = Color.white;
	}
	
	public void OnClickEquipmentEvent(int box){
		Debug.Log ("Clicked box " + box);
	}

	public void OnRightClickInventoryEvent(int box){
		GameObject dropBox = instance.inventoryButtons [box];
		if (dropBox.transform.childCount > 1) {
			GameObject dropItem = dropBox.transform.GetChild (1).gameObject;
			Debug.Log ("Dropping " + dropItem.name);
			dropItem.SetActive (true);
			dropItem.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 5;
			dropItem.transform.SetParent (null);
			GameObject dropIcon = dropBox.transform.GetChild(0).gameObject;
			dropIcon.GetComponent<Image>().sprite = null;
			dropIcon.GetComponent<Image>().color = new Color(0,0,0,0);
		}
	}

	public bool PickupObject(GameObject pickup){
		for (int i = 0; i < instance.inventoryButtons.Length; i++) {
			if(instance.inventoryButtons[i].transform.childCount == 1){
				InventoryItem item = instance.inventoryButtons[i].transform.GetChild(0).gameObject.AddComponent<InventoryItem>(); 
				item.sprite = pickup.GetComponent<InventoryItem>().sprite;
				item.name = pickup.GetComponent<InventoryItem>().name;
				item.isEquipment = pickup.GetComponent<InventoryItem>().isEquipment;
				Image img = instance.inventoryButtons[i].transform.GetChild(0).gameObject.GetComponent<Image>();
				img.sprite = item.sprite;
				img.color = Color.white;
				pickup.transform.SetParent(instance.inventoryButtons[i].transform);
				pickup.SetActive(false);
				return true;
			}
		}
		return false;
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.C)){
			if(inInventory){
				inventoryCanvas.SetActive(false);
				controller.inMenu = false;
				instance.inInventory = false;
				MouseFollowScript.instance.DeSelect();
			}else{
				inventoryCanvas.SetActive(true);
				controller.inMenu = true;
				instance.inInventory = true;
			}
		}
		if (Input.GetMouseButtonDown (0)) {
			RaycastHit hit;
			Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
			int layerMask = 1 << 8;
			if(Physics.Raycast(ray, out hit, 10f, layerMask)){
				if(hit.collider.gameObject.GetComponent<InventoryItem>()!=null){
					PickupObject(hit.collider.gameObject);
				}
			}
		}
	}
}
