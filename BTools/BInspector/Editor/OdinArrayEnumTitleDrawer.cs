/*
 * @author	bwaynesu
 * @date	2022/08/13
 */

using Sirenix.OdinInspector.Editor;
using System;
using UnityEngine;

namespace BTools.BInspector
{
    /// <summary>
    /// Rename the titles of the elements in the array according to the enum.
    /// </summary>
    public sealed class OdinArrayEnumTitleDrawer : OdinAttributeDrawer<OdinArrayEnumTitleAttribute>
    {
        /// <summary>
        /// Odin Method
        /// </summary>
        /// <param name="_label"> Lable </param>
        protected override void DrawPropertyLayout(GUIContent _label)
        {
            var idx = GetPropertyIndex(Property);
            if (idx < 0)
            {
                CallNextDrawer(_label);
                return;
            }

            var enumName = Enum.GetName(Attribute.EnumType, idx);
            var newText = string.Format("[{0}] {1}", idx, enumName);

            if (_label == null)
            {
                CallNextDrawer(new GUIContent(newText));
            }
            else
            {
                _label.text = newText;
                CallNextDrawer(_label);
            }
        }

        /// <summary>
        /// Get the index of a property in the array, returns -1 if the property is not an element of the array.
        /// </summary>
        /// <param name="_property"> Property </param>
        /// <returns> Index </returns>
        private int GetPropertyIndex(InspectorProperty _property)
        {
            var path = _property.UnityPropertyPath;
            var idx = 0;
            var curDigit = 1;

            for (var i = path.Length - 1; i >= 0; --i)
            {
                if (path[i] == ']')
                {
                    continue;
                }

                if (path[i] == '[')
                {
                    break;
                }

                if (!char.IsDigit(path[i]))
                {
                    return -1;
                }

                var n = (path[i] - '0');

                idx = (n * curDigit) + idx;
                curDigit *= 10;
            }

            return idx;
        }
    }
}
