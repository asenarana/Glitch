using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MeshCombiner : MonoBehaviour
{

    public void CombineMeshBasic()
    {
        Mesh theMesh = new Mesh();
        MeshFilter[] filters = GetComponentsInChildren<MeshFilter>();
        CombineInstance[] instances = new CombineInstance[filters.Length-1];

        Debug.Log("mesh count = " + filters.Length);

        for(int i = 0, j = 0; i< filters.Length; i++)
        {
            if (filters[i].transform == transform)
                continue;
            instances[j].mesh = filters[i].sharedMesh;
            instances[j].subMeshIndex = 0;
            instances[j].transform = filters[i].transform.localToWorldMatrix;
            j++;
        }

        theMesh.CombineMeshes(instances);
        GetComponent<MeshFilter>().sharedMesh = theMesh;
    }

    public void CombineMeshAdvanced()
    {
        Mesh theMesh = new Mesh();
        MeshFilter[] filters = GetComponentsInChildren<MeshFilter>(false);
        List<Material> materials = new List<Material>();
        MeshRenderer[] renderers = GetComponentsInChildren<MeshRenderer>(false);

        Debug.Log("mesh count = " + filters.Length);

        foreach (MeshRenderer renderer in renderers)
        {
            if (renderer.transform == transform)
                continue;
            Material[] localMats = renderer.sharedMaterials;
            foreach(Material localMat in localMats)
            {
                if(!materials.Contains(localMat))
                {
                    materials.Add(localMat);
                }
            }
        }
        List<Mesh> subMeshes = new List<Mesh>();
        foreach(Material material in materials)
        {
            List<CombineInstance> instances = new List<CombineInstance>();
            foreach(MeshFilter filter in filters)
            {
                MeshRenderer renderer = filter.GetComponent<MeshRenderer>();
                if (renderer == null)
                    continue;
                Material[] localMats = renderer.sharedMaterials;
                for(int i = 0; i < localMats.Length; i++)
                {
                    if (localMats[i] != material)
                        continue;
                    CombineInstance ci = new CombineInstance();
                    ci.mesh = filter.sharedMesh;
                    ci.subMeshIndex = i;
                    ci.transform = filter.transform.localToWorldMatrix;
                    instances.Add(ci);
                }
            }
            Mesh mesh = new Mesh();
            mesh.CombineMeshes(instances.ToArray(), true);
            subMeshes.Add(mesh);
        }
        CombineInstance[] finalInstances = new CombineInstance[subMeshes.Count];
        for (int i = 0; i < subMeshes.Count; i++)
        {
            finalInstances[i].mesh = subMeshes[i];
            finalInstances[i].subMeshIndex = 0;
            finalInstances[i].transform = Matrix4x4.identity;
        }
        theMesh.CombineMeshes(finalInstances, false);
        GetComponent<MeshFilter>().sharedMesh = theMesh;
    }

    public void SaveMesh()
    {
        string path = EditorUtility.SaveFilePanel("Save Mesh Asset", "Assets/", "NewMesh", "asset");
        if (string.IsNullOrEmpty(path)) return;
        path = FileUtil.GetProjectRelativePath(path);
        Mesh m = GetComponent<MeshFilter>().sharedMesh;
        Mesh meshSave = Object.Instantiate(m) as Mesh;
        MeshUtility.Optimize(meshSave);
        AssetDatabase.CreateAsset(meshSave, path);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
}
