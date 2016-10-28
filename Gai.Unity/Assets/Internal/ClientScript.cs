using UnityEngine;
using System.Collections;

public class ClientScript : MonoBehaviour {

	public GameObject playerPrefab;
	public GameObject autoTileMap;

	// Use this for initialization
	void Start () {
		Instantiate(autoTileMap);
		//var playerPrefab = (GameObject)Resources.Load("/Assets/CreativeSpore/RpgMapEditor/Samples/Prefabs/Player.prefab", typeof(GameObject));
		Instantiate(playerPrefab, new Vector3(25.0f,-25.0f), Quaternion.identity);
		
		Debug.LogFormat("Hello world");
	}
	
	// Update is called once per frame
	void Update () {
	}
}
