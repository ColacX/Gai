using UnityEngine;
using System.Collections;
using CreativeSpore.RpgMapEditor;

public class ClientScript : MonoBehaviour {

	public GameObject playerPrefab;
	public GameObject autoTileMap;

	// Use this for initialization
	void Start () {
		Debug.LogFormat("Start");

		var map = (AutoTileMap)autoTileMap.GetComponent("AutoTileMap");
		var filePath = "Assets/Map.xml";
		AutoTileMapSerializeData mapData = AutoTileMapSerializeData.LoadFromFile(filePath);
		map.MapData.Data.CopyData(mapData);
		map.LoadMap();

		//var playerPrefab = (GameObject)Resources.Load("/Assets/CreativeSpore/RpgMapEditor/Samples/Prefabs/Player.prefab", typeof(GameObject));
		Instantiate(playerPrefab, new Vector3(25.0f,-25.0f), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
	}

}
