using UnityEngine;
using UnityEngine.Events;

namespace Eloi.TwoPointsLoader
{
    public class TwoPointsLoad_MoveAtStartEndPoint : MonoBehaviour
    {
            [SerializeField] private Transform m_whatToMove;
            public void MoveTheSceneFrom(Vector3 worldPointStart, Vector3 worldPointEnd)
            {
                Vector3 start = worldPointStart;
                Vector3 end = worldPointEnd;
                Vector3 endFlat = end;
                endFlat.y = start.y;
                m_whatToMove.transform.position = Vector3.zero;
                m_whatToMove.transform.rotation = Quaternion.identity;
                Vector3 unityForward = Vector3.forward;
                Vector3 startEndDirection = endFlat - start;
                float rotationToApply = Vector3.SignedAngle(unityForward, startEndDirection, Vector3.up) - 90f;
                m_whatToMove.transform.Rotate(Vector3.up, rotationToApply);
                Vector3 directionStart = worldPointStart;
                m_whatToMove.transform.position = directionStart;              
            }
    }
}
