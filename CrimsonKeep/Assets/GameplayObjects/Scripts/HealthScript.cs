using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthScript : MonoBehaviour {
	private static float currentHealth;
	public static float maxHealth = 100;
	private static Image healthBar;
	//private static Image healthBar;
	private static HealthScript m_instance;
	public static HealthScript instance{
		get{
			return m_instance;
		}
	}
	// Use this for initialization
	void Start () {
		m_instance = this;
		healthBar = GameObject.Find ("HealthBar").GetComponent<Image> ();
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
		/*Debug.Log (currentHealth);
		Debug.Log (maxHealth);
		Debug.Log (currentHealth / maxHealth);*/
		healthBar.rectTransform.offsetMax = new Vector2(-(1106 - ((1106 - 816) * (currentHealth / maxHealth))), -215);
		//Debug.Log (healthBar.rectTransform.offsetMax);
		return (currentHealth == 0);
	}

	public static float GetHealth(){
		return currentHealth;
	}
}
