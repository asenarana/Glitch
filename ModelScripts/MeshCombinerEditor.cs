using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MeshCombiner))]
public class MeshCombineEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        MeshCombiner mc = (MeshCombiner)target;

        if(GUILayout.Button("Combine Mesh Basic"))
        {
            mc.CombineMeshBasic();
        }
        if (GUILayout.Button("Combine Mesh Advanced"))
        {
            mc.CombineMeshAdvanced();
        }
        if (GUILayout.Button("Save Mesh"))
        {
            mc.SaveMesh();
        }
    }
}
