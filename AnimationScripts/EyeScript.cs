using UnityEditor;
using UnityEngine;

public class EyeScript : MonoBehaviour
{
    private Renderer leftEye;
    private Renderer rightEye;
    private Material eyeMat;
    private Material skinMat;

    void Start()
    {
        eyeMat = (Material)AssetDatabase.LoadAssetAtPath("Assets/Materials/eyes.mat", typeof(Material));
        skinMat = (Material)AssetDatabase.LoadAssetAtPath("Assets/Materials/skin.mat", typeof(Material));
        leftEye = transform.Find("LeftEye").gameObject.GetComponent<Renderer>();
        rightEye = transform.Find("RightEye").gameObject.GetComponent<Renderer>();
    }

    public void OpenEyes()
    {
        leftEye.material = eyeMat;
        rightEye.material = eyeMat;
    }

    public void CloseEyes()
    {
        leftEye.material = skinMat;
        rightEye.material = skinMat;
    }
}
