using UnityEngine;
using UnityEditor;
using ISDevTemplateDebug;

namespace ISDevTemplateEditor
{
    [CustomEditor(typeof(ExecutionEvent))]
    internal class ExecutionEventEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var executionEvent = target as ExecutionEvent;

            if (GUILayout.Button("実行"))
            {
                executionEvent.Execution();
            }
        }
    }
}
