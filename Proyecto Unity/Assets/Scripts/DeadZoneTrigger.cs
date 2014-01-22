using UnityEngine;
using System.Collections;

public class DeadZoneTrigger : MonoBehaviour {

	private bool ended = false;
	private float timeRecord = -1f;


	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			GameObject.Destroy(other.gameObject);
			Debug.Log("You Lose!");
			Time.timeScale = 0f;
			ended = true;
			timeRecord = Time.time;
		}
	}

	void OnGUI() {
		if (ended) {
			GUILayout.BeginArea(new Rect(Screen.width / 2 - 200f, Screen.height / 2 - 100f, 400f, 200f));
			GUILayout.BeginVertical();
			GUILayout.Label("You Lose!");
			GUILayout.Label("Your time record is " + timeRecord + " seconds.");
			if (GUILayout.Button("Restart?")) {
				Time.timeScale = 1f;
				Application.LoadLevel(Application.loadedLevel);
			}
			GUILayout.EndVertical();
			GUILayout.EndArea();
		}
	}
}
