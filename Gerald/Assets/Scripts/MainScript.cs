using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Linq;
using System.Reflection;

public class MainScript : MonoBehaviour {

	List<SpawnEvent> _spawnEvents = new List<SpawnEvent>();
    private Level _level;

	// Use this for initialization
	void Start () {

        _level = LoadXML<Level>("level1");
        var globalData = LoadXML<GlobalData>("globaldata");
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
            bool eventsDue = true;
            while (eventsDue)
            {
                var spawnEvent = _spawnEvents.First();
                if (spawnEvent.Time < Time.timeSinceLevelLoad)
                {
                    _spawnEvents.RemoveAt(0);
                    if (!_spawnEvents.Any()) eventsDue = false;
                    GameObject obj = Resources.Load<GameObject>("Enemies/" + spawnEvent.SpawnObject);
                    Instantiate(obj, ParseVector3(spawnEvent.Location), Quaternion.identity);
                }
                else
                    eventsDue = false;
            }
		}
        else
        {
            var time = Time.timeSinceLevelLoad;
            _spawnEvents = _level.SpawnEvents.OrderBy(e => e.Time).Select(
                e => new SpawnEvent() 
                { 
                    Time = e.Time + Time.timeSinceLevelLoad, 
                    Location = e.Location, 
                    SpawnObject = e.SpawnObject 
                }).ToList();
        }
	}

    private Vector3 ParseVector3(string p)
    {
        var split = p.Split(',');
        return new Vector3(float.Parse(split[0]), float.Parse(split[1]), split.Length > 2 ? float.Parse(split[2]) : 0);
    }
}
