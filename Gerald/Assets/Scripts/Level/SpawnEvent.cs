using System;
using UnityEngine;
using System.Collections.Generic;
using System.Xml.Serialization;

public class SpawnEvent
{
	public float Time { get; set; }
	public string SpawnObject { get; set; }
	public string Location { get; set; }
}