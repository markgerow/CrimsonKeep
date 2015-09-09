using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ManaScript : MonoBehaviour {
	private static float currentMana;
	public static float maxMana = 100;
	private static Image manaBar;
	//private static Image ManaBar;
	private static ManaScript m_instance;
	public static ManaScript instance{
		get{
			return m_instance;
		}
	}
	// Use this for initialization
	void Start () {
		m_instance = this;
		manaBar = GameObject.Find ("ManaBar").GetComponent<Image> ();
		SetMana(maxMana);
	}
	
	void Update(){
		if (Input.GetKeyDown (KeyCode.Space)) {
			SetMana(-1);
		}
	}
	
	public static bool SetMana(float changeInMana){
		currentMana += changeInMana;
		currentMana = Mathf.Max (currentMana, 0);
		currentMana = Mathf.Min (currentMana, maxMana);
		manaBar.GetComponent<Image> ().fillAmount = currentMana / maxMana;
		return (currentMana == 0);
	}
	
	public static float GetMana(){
		return currentMana;
	}
}
