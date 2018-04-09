using core.metadata.valueobjects;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace core.metadata
{
    /// <summary>
    /// Contains the map of all the value objects
    /// </summary>
    [Serializable]
    public class MetadataMap : ISerializationCallbackReceiver
    {
        /// BEGIN SERIALIZABLE SHEETS

        /// <summary>
        /// List of all Character VOs in case quick iteration is necessary
        /// </summary>
        public List<CharacterVO> Characters;

        /// END SERIALIZABLE SHEETS

        /// <summary>
        /// The map that contains the VO type to the dictionary of UID to VO objects
        /// </summary>
        public Dictionary<Type, Dictionary<string, object>> rawMetadata;

        private DateTime startT;

        public MetadataMap()
        {
            rawMetadata = new Dictionary<Type, Dictionary<string, object>>();
            startT = DateTime.Now;
        }

        public void OnBeforeSerialize()
        {
            // Don't do anything before serialize for now
        }

        public void OnAfterDeserialize()
        {
            Debug.Log("Begin Post-Processing");
            SaveListToMetadataMap<CharacterVO>(Characters);

            DateTime endT = DateTime.Now;
            TimeSpan timeSpan = (TimeSpan)(endT - startT);

            Debug.Log("Done Post-Processing: " + timeSpan.TotalMilliseconds + "ms");
        }

        /// <summary>
        /// Given the raw VO list, map them all by UID for quicker lookup later.
        /// </summary>
        private void SaveListToMetadataMap<T>(List<T> voList) where T : IBaseVO
        {
            for (int i = 0, count = voList.Count; i < count; i++)
            {
                IBaseVO vo = voList[i];

                Type type = typeof(T);

                // See if we have the mapping yet.
                if (!rawMetadata.ContainsKey(type))
                {
                    // nope then let's make the dictionary.
                    rawMetadata[type] = new Dictionary<string, object>();
                }

                Dictionary<string, object> voMap = rawMetadata[type];
                voMap[vo.GetUID] = vo;
            }
        }

        /// <summary>
        /// Gets a VO by type and uid
        /// </summary>
        /// <returns></returns>
        public T GetVO<T>(string uid) where T : IBaseVO
        {
            Type type = typeof(T);

            if (!rawMetadata.ContainsKey(type))
            {
                Debug.LogError("Failed to find metadata for type: " + type.ToString());
            }

            Dictionary<string, object> voMap = rawMetadata[type];
            if (!voMap.ContainsKey(uid))
            {
                Debug.LogError("Failed to find VO of type: " + type.ToString() + " for UID: " + uid);
            }

            return (T)voMap[uid];
        }

        
    }
}