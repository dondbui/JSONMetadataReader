using UnityEngine;

namespace core.metadata
{
    /// <summary>
    /// Handles all of the loading for the metadata JSON files
    /// </summary>
    public class JSONMetadataloader
    {
        public static MetadataMap LoadJSONMetadata(string jsonFileName)
        {
            // Load the raw JSON Text
            TextAsset textAsset = Resources.Load<TextAsset>(
                JSONMetadataReaderConstants.METADATA_LOC + jsonFileName);

            // Use Unity's built in JSON serializer to serialize to VOs and set them up
            // in the metadata map
            MetadataMap dataMap = JsonUtility.FromJson<MetadataMap>(textAsset.text);

            return dataMap;
        }
        
    }
}