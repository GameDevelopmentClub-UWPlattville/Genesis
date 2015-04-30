using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour {

	string levelSelected;
	string lastLevelSelected;

	// Use this for initialization
	void Start ()
	{
		levelSelected = "VerticalClimb";
		GameObject.Find (levelSelected + "Btn").GetComponent<RectTransform> ().Translate (0.0f, 0.0f, -5.0f);
	}

	public void StartBtn()
	{
		Application.LoadLevel(levelSelected);
	}

	public void SelectLevel (string levelName)
	{
		lastLevelSelected = levelSelected;
		GameObject.Find ("DebugBox1").GetComponent<Text> ().text = "levelName : " + levelName;
		GameObject.Find ("DebugBox2").GetComponent<Text> ().text = "onGround = ";
		GameObject.Find (lastLevelSelected + "Btn").GetComponent<RectTransform> ().Translate (0.0f, 0.0f, 5.0f);
		GameObject.Find (levelName + "Btn").GetComponent<RectTransform> ().Translate (0.0f, 0.0f, -5.0f);
		//GameObject.Find (levelName).
		levelSelected = levelName;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//GameObject.Find ("VerticalClimb").
	}
}
