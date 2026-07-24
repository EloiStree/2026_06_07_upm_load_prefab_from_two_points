using UnityEngine;
using UnityEngine.Events;

namespace Eloi.TwoPointsLoader
{
    public class TwoPointsLoad_MoveAndScaleTargetFromTwoPoints : MonoBehaviour
    {

        [SerializeField]
        private UnityEvent m_onMovedObject;
        [SerializeField] private Transform m_targetToMoveAndScale;

        [SerializeField] private float m_scaleFactor = 1.0f;


        public void MoveWithStartEndPoints(Vector3 worldPointStart, Vector3 worldPointEnd)
        {
   
            Vector3 start = worldPointStart;
            Vector3 end = worldPointEnd;
            //bool isUpFlat = e.y > 0.05f;
            Vector3 endFlat = end;
            endFlat.y = start.y;
            float distanceStartEndFlat = (endFlat - start).magnitude;
            var toMove = m_targetToMoveAndScale;
            toMove.position = Vector3.zero;
            toMove.rotation = Quaternion.identity;
            Vector3 unityForward = Vector3.forward;
            Vector3 startEndDirection = endFlat - start;
            float rotationToApply = Vector3.SignedAngle(unityForward, startEndDirection, Vector3.up) - 90f;
            toMove.Rotate(Vector3.up, rotationToApply);
            Vector3 directionStart = worldPointStart;
            toMove.position = directionStart;
            toMove.localScale = Vector3.one * distanceStartEndFlat * m_scaleFactor;
            m_onMovedObject.Invoke();
        }
    }
}
