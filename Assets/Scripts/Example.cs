using core.metadata;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Example : MonoBehaviour
{
	public void Start ()
    {
        // Try to load up the metadata
        MetadataMap mdMap = JSONMetadataloader.LoadJSONMetadata("metadata");

        StringBuilder sb = new StringBuilder();

        sb.Append("Metadata contains the following: \n");

        foreach (KeyValuePair<Type, Dictionary<string, object>> entry in mdMap.rawMetadata)
        {
            string typeName = entry.Key.Name;
            int num = entry.Value.Count;

            sb.Append(typeName + ": " + num + "\n");
        }
        Debug.Log(sb.ToString());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
