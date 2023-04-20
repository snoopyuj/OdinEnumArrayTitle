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
    /// 將陣列中的元素標題依照 enum 取名
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
        /// 取得 Property 於陣列中的索引值, 若不是陣列元素則回傳 -1
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