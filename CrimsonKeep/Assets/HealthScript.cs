using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthScript : MonoBehaviour {
	public static int currentHealth;
	public static int maxHealth = 100;
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
	
	public static bool SetHealth(int changeInHealth){
		currentHealth += changeInHealth;
		currentHealth = Mathf.Max (currentHealth, 0);
		currentHealth = Mathf.Min (currentHealth, maxHealth);
		healthBar.rectTransform.right = new Vector3(1105 - ((1105 - 816) * (currentHealth / maxHealth)), 285, 0);
		Debug.Log (healthBar.rectTransform.right);
		return (currentHealth == 0);
	}
}
