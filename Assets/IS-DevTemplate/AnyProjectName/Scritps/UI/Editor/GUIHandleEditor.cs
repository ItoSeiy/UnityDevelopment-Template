using ISDevTemplate.UI;
using UnityEditor;
using UnityEngine;

namespace ISDevTemplateEditor
{
    [CustomEditor(typeof(GUIHandle), true)]
    public class GUIHandleEditor : Editor
    {
        void OnSceneGUI()
        {
            var t = target as GUIHandle;
            var start = t.transform.TransformPoint(t.StartPos);
            var end = t.transform.TransformPoint(t.EndPos);

            using (var checkScope = new EditorGUI.ChangeCheckScope())
            {
                start = Handles.PositionHandle(start, t.transform.rotation);

                Handles.Label(start, "Start");
                Handles.Label(end, "End");

                end = Handles.PositionHandle(end, t.transform.rotation);

                if (checkScope.changed)
                {
                    Undo.RecordObject(t, "Move Handles");
                    t.SetStartPos(t.transform.InverseTransformPoint(start));
                    t.SetEndPos(t.transform.InverseTransformPoint(end));

                    t.SetStartLocalPos(start);
                    t.SetEndLocalPos(end);
                }
            }

            Handles.color = Color.yellow;
            Handles.DrawDottedLine(start, end, 5);
            Handles.Label(Vector3.Lerp(start, end, 0.5f), "Distance:" + (end - start).magnitude);
        }
    }
}
