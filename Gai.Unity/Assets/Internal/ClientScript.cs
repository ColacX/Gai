using UnityEngine;
using System.Collections;

public class ClientScript : MonoBehaviour {

	public GameObject playerPrefab;

	// Use this for initialization
	void Start () {
		//var playerPrefab = (GameObject)Resources.Load("/Assets/CreativeSpore/RpgMapEditor/Samples/Prefabs/Player.prefab", typeof(GameObject));
		Instantiate(playerPrefab, new Vector3(31.0f,-25.5f), Quaternion.identity);
		Debug.LogFormat("Hello world");
	}
	
	// Update is called once per frame
	void Update () {
		Debug.LogFormat("Hello world");

	}
}
