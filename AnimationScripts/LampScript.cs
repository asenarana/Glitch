using UnityEditor;
using UnityEngine;

public class LampScript : MonoBehaviour
{
    private Renderer rend;
    private Material offmat;
    private Material onmat;
    void Start()
    {
        rend = gameObject.GetComponent<Renderer>();
        offmat = ((Material)AssetDatabase.LoadAssetAtPath("Assets/Materials/lampOff.mat", typeof(Material)));
        onmat = ((Material)AssetDatabase.LoadAssetAtPath("Assets/Materials/lamp.mat", typeof(Material)));
    }

    public void TurnOff()
    {
        rend.material = offmat;
    }

    public void TurnOn()
    {
        rend.material = onmat;
    }
}
