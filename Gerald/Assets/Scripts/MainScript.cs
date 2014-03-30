using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Linq;
using System.Reflection;

public class MainScript : MonoBehaviour {

	IList<SpawnEvent> _spawnEvents;

	// Use this for initialization
	void Start () {

        var level = LoadXML<Level>("level1");
        var globalData = LoadXML<GlobalData>("globaldata");

		_spawnEvents = level.SpawnEvents.OrderBy(e => e.Time).ToList();
	}

    private static T LoadXML<T>(string file)
    {
        var serializer = new XmlSerializer(typeof(T));
        return (T)(serializer.Deserialize(new MemoryStream(Resources.Load<TextAsset>(file).bytes)));
    }
	
	// Update is called once per frame
	void Update () {
		if (_spawnEvents.Any())
		{
			var spawnEvent = _spawnEvents.First();
			if (spawnEvent.Time < Time.timeSinceLevelLoad)
			{
				_spawnEvents.RemoveAt(0);
				GameObject obj = Resources.Load<GameObject>("Enemies/"+spawnEvent.SpawnObject);
				Instantiate (obj, ParseVector3(spawnEvent.Location), Quaternion.identity);
			}
		}
	}

    private Vector3 ParseVector3(string p)
    {
        var split = p.Split(',');
        return new Vector3(float.Parse(split[0]), float.Parse(split[1]), split.Length > 2 ? float.Parse(split[2]) : 0);
    }
}
