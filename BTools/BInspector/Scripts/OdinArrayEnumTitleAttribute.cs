/*
 * @author	bwaynesu
 * @date	2022/08/13
 */

using System;
using UnityEngine;

namespace BTools.BInspector
{
    /// <summary>
    /// Name the elements in the array according to the enum.
    /// </summary>
    public class OdinArrayEnumTitleAttribute : PropertyAttribute
    {
        /// <summary>
        /// Enum Type
        /// </summary>
        public Type EnumType { get; private set; }

        public OdinArrayEnumTitleAttribute(Type _enumType)
        {
            EnumType = _enumType;
        }
    }
}