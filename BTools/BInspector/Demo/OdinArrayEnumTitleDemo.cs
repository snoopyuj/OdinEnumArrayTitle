/*
 * @author	bwaynesu
 * @date	2022/08/13
 */

using UnityEngine;

namespace BTools.BInspector.Demo
{
    // 1. Define an enum to be used as the display name for the array elements.
    public enum DirectionType : byte
    {
        North = 0,
        South,
        East,
        West,
    }

    /// <summary>
    /// This example demonstrates displaying the title name of array elements using an enum in the Inspector,
    /// making it easier for developers to correlate types and values.
    /// </summary>
    public class OdinArrayEnumTitleDemo : MonoBehaviour
    {
        // 2. Designate the array to display the enum title.
        [OdinArrayEnumTitle(typeof(DirectionType))]
        [SerializeField]
        private Vector3[] vectorArray = new Vector3[0];

        [Space, SerializeField]
        private Transform transToMove = null;

        [SerializeField]
        private DirectionType curDir = DirectionType.North;

        /// <summary>
        /// Unity Update: Moving the target
        /// </summary>
        private void Update()
        {
            if (transToMove == null)
            {
                Debug.LogError("Empty object to move.");
                return;
            }

            var curDirIdx = (int)curDir;
            if (curDirIdx >= vectorArray.Length)
            {
                Debug.LogErrorFormat("{0} has not been defined in the array yet.", curDir);
                return;
            }

            transToMove.position += Time.deltaTime * vectorArray[curDirIdx];
        }
    }
}