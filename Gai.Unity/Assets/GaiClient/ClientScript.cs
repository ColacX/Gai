using UnityEngine;
using System.Collections;

public class ClientScript : MonoBehaviour {

	public GameObject playerPrefab;

	// Use this for initialization
	void Start () {
		//var playerPrefab = (GameObject)Resources.Load("/Assets/CreativeSpore/RpgMapEditor/Samples/Prefabs/Player.prefab", typeof(GameObject));
		Instantiate(playerPrefab, new Vector3(30,-25), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
