using UnityEngine;

namespace ISDevTemplate.UI
{
    public abstract class GUIHandle : MonoBehaviour
    {
        public Vector3 StartPos => _startPos;

        public Vector3 EndPos => _endPos;

        public Vector3 StartLocalPos => _startLocalPos;

        public Vector3 EndLocalPos => _endLocalPos;

        [Header("=== GUI Editor ===")]
        [SerializeField]
        private Vector3 _startPos;

        [SerializeField]
        private Vector3 _endPos;

        private Vector3 _startLocalPos;

        private Vector3 _endLocalPos;

        public void SetStartPos(Vector3 pos)
        {
            _startPos = pos;
        }

        public void SetEndPos(Vector3 pos)
        {
            _endPos = pos;
        }

        public void SetStartLocalPos(Vector3 pos)
        {
            _startLocalPos = pos;
        }

        public void SetEndLocalPos(Vector3 pos)
        {
            _endLocalPos = pos;
        }
    }
}
