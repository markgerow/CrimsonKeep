using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthScript : MonoBehaviour {
	private static float currentHealth;
	public static float maxHealth = 100;
	private static Image HealthBar;
	//private static Image HealthBar;
	private static HealthScript m_instance;
	public static HealthScript instance{
		get{
			return m_instance;
		}
	}
	// Use this for initialization
	void Start () {
		m_instance = this;
		HealthBar = GameObject.Find ("HealthBar").GetComponent<Image> ();
		SetHealth (maxHealth);
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Space)) {
			SetHealth(-1);
		}
	}
	
	public static bool SetHealth(float changeInHealth){
		currentHealth += changeInHealth;
		currentHealth = Mathf.Max (currentHealth, 0);
		currentHealth = Mathf.Min (currentHealth, maxHealth);
		HealthBar.GetComponent<Image> ().fillAmount = currentHealth / maxHealth;
		return (currentHealth == 0);
	}

	public static float GetHealth(){
		return currentHealth;
	}
}
