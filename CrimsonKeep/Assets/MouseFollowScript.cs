using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MouseFollowScript : MonoBehaviour {
	private static MouseFollowScript m_instance;
	public static MouseFollowScript instance {
		get{
			return m_instance;
		}
	}
	public Image iconImage;
	public int index;
	public bool isInventory;
	// Update is called once per frame

	void Start(){
		m_instance = this;
		m_instance.iconImage = gameObject.GetComponent<Image> ();
	}

	void Update () {
		transform.position = Input.mousePosition;
	}

	public void SetImage(Sprite spriteToSet){
		instance.iconImage.sprite = spriteToSet;
	}

	public void SetColor(Color colorToSet){
		instance.iconImage.color = colorToSet;
	}

	public void Pickup(int indexToSet, bool isInv, Sprite spriteToSet){
		index = indexToSet;
		isInventory = isInv;
		instance.GetComponent<Image> ().enabled = true;
		SetImage (spriteToSet);
		SetColor (Color.white);
	}

	public void DeSelect(){
		iconImage.enabled = false;
		InventoryScript.instance.inventoryButtons [index].transform.GetChild (0).gameObject.GetComponent<Image> ().enabled = true;
	}
}
