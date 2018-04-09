using System;

namespace core.metadata.valueobjects
{
    /// <summary>
    /// Example meta data VO which holds character data
    /// </summary>
    [Serializable]
    public struct CharacterVO  : IBaseVO
    {
        /// <summary>
        /// The unique identifier
        /// </summary>
        public string uid;

        public string GetUID { get { return uid; } }

        public int damageReduction;
        public double dodgeChance;
        public double hitChance;
    }
}