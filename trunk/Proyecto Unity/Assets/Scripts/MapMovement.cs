using UnityEngine;
using System.Collections;

public class MapMovement : MonoBehaviour {

	public GameObject[] modules;
	public float mapSpeed = 1f;
	public float speedIncreaseRate = 0.1f;		//Speed increased per second
	public float difficulty = 0f;
	public float diffIncreaseRate = 0.1f;		//Difficulty increaed per second


	void Start() {
		if (modules == null) {
			modules = new GameObject[5];
			for (int i = 0; i < modules.Length; i++) {
				modules[i] = proceduralModule(difficulty, nextModulePos());
			}
		}
	}
	
	void Update() {

		mapMovement();
		mapGeneration();

		mapSpeed += speedIncreaseRate * Time.deltaTime;
		difficulty += diffIncreaseRate * Time.deltaTime;
	}

	private void mapMovement() {
		foreach (GameObject go in modules) {
			go.transform.Translate(new Vector3(-mapSpeed * Time.deltaTime, 0f, 0f));
		}
	}

	private void mapGeneration() {
		for (int i = 0; i < modules.Length; i++) {
			if (modules[i].transform.position.x < -50f) {
				GameObject.Destroy(modules[i]);
				modules[i] = proceduralModule(difficulty, nextModulePos());
			}
		}
	}

	private Vector3 nextModulePos() {
		Vector3 result = new Vector3(float.MinValue, 0f, 0f);
		foreach (GameObject go in modules) {
			if (go.transform.position.x > result.x) {
				result = go.transform.position;
			}
		}
		return (result + new Vector3(25f, 0f, 0f));
	}

	private GameObject proceduralModule(float diff, Vector3 pos) {
		//Generar el modulo como tal
		GameObject moduleTemp = new GameObject();
		moduleTemp.transform.position = pos;
		moduleTemp.AddComponent<ModuleProperties>();
		moduleTemp.GetComponent<ModuleProperties>().difficulty = diff;
		moduleTemp.name = "Module_Procedural_diff_" + diff;
		//Generar techo y suelo
		GameObject roof = GameObject.CreatePrimitive(PrimitiveType.Cube);
		roof.transform.parent = moduleTemp.transform;
		roof.transform.localPosition = new Vector3(0f, 5f, 0f);
		roof.transform.localScale = new Vector3(25f, 1f, 1f);
		roof.name = "Roof";
		GameObject floor = GameObject.CreatePrimitive(PrimitiveType.Cube);
		floor.transform.parent = moduleTemp.transform;
		floor.transform.localPosition = new Vector3(0f, -5f, 0f);
		floor.transform.localScale = new Vector3(25f, 1f, 1f);
		floor.name = "Floor";
		//Generar contenido del modulo

		float diffTemp = diff;
		int rand;
		while (diffTemp > 0) {
			if (diffTemp < 1f) {
				diffTemp = 1f; 
			}
			rand = Random.Range(1, (int)diffTemp);
			switch (rand) {
				case 1:
					if (createLevel1(diffTemp, moduleTemp.transform)) {
						diffTemp -= 1f;
						Debug.Log("Used a 1 diff module in " + moduleTemp.name + ".");
						continue;
					}
					break;
				case 2: 
					if (createLevel2(diffTemp, moduleTemp.transform)) {
						diffTemp -= 2f;
						Debug.Log("Used a 2 diff module in " + moduleTemp.name + ".");
						continue;
					}
					break;
				case 3: 
					if (createLevel3(diffTemp, moduleTemp.transform)) {
						diffTemp -= 3f;
						Debug.Log("Used a 3 diff module in " + moduleTemp.name + ".");
						continue;
					}
					break;
				case 4: 
					if (createLevel4(diffTemp, moduleTemp.transform)) {
						diffTemp -= 4f;
						Debug.Log("Used a 4 diff module in " + moduleTemp.name + ".");
						continue;
					}
					break;
				case 5: 
					if (createLevel5(diffTemp, moduleTemp.transform)) {
						diffTemp -= 5f;
						Debug.Log("Used a 5 diff module in " + moduleTemp.name + ".");
						continue;
					}
					break;
				default:
					break;
			}
		}

		return moduleTemp;
	}

	private bool createLevel1(float temp, Transform parent) {
		if (temp < 1) {
			return false;
		}
		//Create the cube
		GameObject fence1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
		fence1.transform.parent = parent;
		//Vertical placement
		bool upDown = Random.Range(0, 2) == 1;
		float upDownVal = upDown ? 4f : -4f;
		//Horizontal placement
		float rightLeftVal = Random.Range(-12.5f, 12.5f);
		do {
			fence1.transform.localPosition = new Vector3(rightLeftVal, upDownVal, 0f);
		}
		while (checkPlacement(parent, fence1.transform));
		fence1.name = "fence_1";
		return true;
	}

	private bool createLevel2(float temp, Transform parent) {
		if (temp < 2) {
			return false;
		}
		//Create the cube
		GameObject fence2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
		fence2.transform.parent = parent;
		//Vertical placement
		bool upDown = Random.Range(0, 2) == 1;
		float upDownVal = upDown ? 3.5f : -3.5f;
		//Horizontal placement
		float rightLeftVal = Random.Range(-12.5f, 12.5f);
		//Scale
		fence2.transform.localScale = new Vector3(1f, 2f, 1f);
		do {
			fence2.transform.localPosition = new Vector3(rightLeftVal, upDownVal, 0f);
		}
		while (checkPlacement(parent, fence2.transform));
		fence2.name = "fence_2";
		return true;
	}

	private bool createLevel3(float temp, Transform parent) {
		if (temp < 3) {
			return false;
		}
		//Create the cube
		GameObject fence3 = GameObject.CreatePrimitive(PrimitiveType.Cube);
		fence3.transform.parent = parent;
		//Vertical placement
		bool upDown = Random.Range(0, 2) == 1;
		float upDownVal = upDown ? 3f : -3f;
		//Horizontal placement
		float rightLeftVal = Random.Range(-12.5f, 12.5f);
		//Scale
		fence3.transform.localScale = new Vector3(1f, 3f, 1f);
		do {
			fence3.transform.localPosition = new Vector3(rightLeftVal, upDownVal, 0f);
		}
		while (checkPlacement(parent, fence3.transform));
		fence3.name = "fence_3";
		return true;
	}

	private bool createLevel4(float temp, Transform parent) {
		if (temp < 4) {
			return false;
		}
		//Create the cube
		GameObject fence4 = GameObject.CreatePrimitive(PrimitiveType.Cube);
		fence4.transform.parent = parent;
		//Vertical placement
		bool upDown = Random.Range(0, 2) == 1;
		float upDownVal = upDown ? 2.5f : -2.5f;
		//Horizontal placement
		float rightLeftVal = Random.Range(-12.5f, 12.5f);
		//Scale
		fence4.transform.localScale = new Vector3(1f, 4f, 1f);
		do {
			fence4.transform.localPosition = new Vector3(rightLeftVal, upDownVal, 0f);
		}
		while (checkPlacement(parent, fence4.transform));
		fence4.name = "fence_4";
		return true;
	}

	private bool createLevel5(float temp, Transform parent) {
		if (temp < 5) {
			return false;
		}
		//Create the cube
		GameObject fence5 = GameObject.CreatePrimitive(PrimitiveType.Cube);
		fence5.transform.parent = parent;
		//Vertical placement
		bool upDown = Random.Range(0, 2) == 1;
		float upDownVal = upDown ? 2f : -2f;
		//Horizontal placement
		float rightLeftVal = Random.Range(-12.5f, 12.5f);
		//Scale
		fence5.transform.localScale = new Vector3(1f, 5f, 1f);
		do {
			fence5.transform.localPosition = new Vector3(rightLeftVal, upDownVal, 0f);
		}
		while (checkPlacement(parent, fence5.transform));
		fence5.name = "fence_5";
		return true;
	}

	private bool checkPlacement(Transform parent, Transform check) {
		try {
			foreach (Transform child in parent) {
				if (child.collider.bounds.Intersects(check.collider.bounds)) {
					Debug.Log("Two boxes intersected! Retrying.");
					return false;
				}
			}
			return true;
		}
		catch (System.Exception e) {
			Debug.Log(e.ToString());
			return false;
		}
	}
}












