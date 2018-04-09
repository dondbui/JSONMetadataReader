using System;

namespace core.metadata.valueobjects
{
    /// <summary>
    /// Base interface for all value object structs
    /// </summary>
    public interface IBaseVO
    {
        /// <summary>
        /// The unique identifier
        /// </summary>
        string GetUID { get; }
    }
}