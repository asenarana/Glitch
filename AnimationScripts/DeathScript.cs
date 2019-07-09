using UnityEngine;
using UnityEditor;

public class DeathScript : MonoBehaviour
{
    private readonly float lerpSpeed = 0.02f;

    private float lerpAmount;
    private Color startHairColor = Color.black;
    private Color startEyeColor = Color.black;
    private Color startMouthColor = Color.red;
    private Color endHairColor = Color.white;
    private Color endEyeColor = Color.white;
    private Color endMouthColor = Color.white;
    private bool isDead;
    private Material[] mats;
    private Color curHairColor;
    private Color curEyeColor;
    private Color curMouthColor;
    private Renderer render;
    private bool hairCheck;
    private bool eyeCheck;
    private bool mouthCheck;

    void Start()
    {
        isDead = true;
        hairCheck = false;
        eyeCheck = false;
        mouthCheck = false;
        render = gameObject.transform.Find("Avatar").Find("HumanoidColorV3").gameObject.GetComponent<Renderer>();
        mats = render.materials;
        foreach (Material mat in mats)
        {
            if (mat.name.StartsWith("hair"))
            {
                startHairColor = mat.color;
                hairCheck = true;
            }
            else if (mat.name.StartsWith("eye"))
            {
                startEyeColor = mat.color;
                eyeCheck = true;
            }
            else if(mat.name.StartsWith("mouth"))
            {
                startMouthColor = mat.color;
                mouthCheck = true;
            }
            if (eyeCheck && hairCheck && mouthCheck) break;
        }
        hairCheck = false;
        eyeCheck = false;
        mouthCheck = false;
        endHairColor = ((Material)AssetDatabase.LoadAssetAtPath("Assets/Materials/deadHair.mat", typeof(Material))).color;
        endEyeColor = ((Material)AssetDatabase.LoadAssetAtPath("Assets/Materials/skin.mat", typeof(Material))).color;
        endMouthColor = ((Material)AssetDatabase.LoadAssetAtPath("Assets/Materials/skin.mat", typeof(Material))).color;
    }
    
    void Update()
    {
        if(!isDead)
        {
            hairCheck = false;
            eyeCheck = false;
            mouthCheck = false;
            lerpAmount += lerpSpeed;
            curHairColor = Color.Lerp(startHairColor, endHairColor, lerpAmount);
            curEyeColor = Color.Lerp(startEyeColor, endEyeColor, lerpAmount);
            curMouthColor = Color.Lerp(startMouthColor, endMouthColor, lerpAmount);
            mats = render.materials;
            foreach (Material mat in mats)
            {
                if(mat.name.StartsWith("hair"))
                {
                    mat.color = curHairColor;
                    hairCheck = true;
                }
                else if(mat.name.StartsWith("eye"))
                {
                    mat.color = curEyeColor;
                    eyeCheck = true;
                }
                else if(mat.name.StartsWith("mouth"))
                {
                    mat.color = curMouthColor;
                    mouthCheck = true;
                }
                if (hairCheck && eyeCheck && mouthCheck) break;
            }
            render.materials = mats;
            if(lerpAmount >= 1)
            {
                isDead = true;
            }
        }
    }

    public void Die()
    {
        isDead = false;
        lerpAmount = 0f;
    }

    public void SetDead()
    {
        hairCheck = false;
        eyeCheck = false;
        mouthCheck = false;
        mats = render.materials;
        foreach (Material mat in mats)
        {
            if (mat.name.StartsWith("hair"))
            {
                mat.color = endHairColor;
                hairCheck = true;
            }
            else if (mat.name.StartsWith("eye"))
            {
                mat.color = endHairColor;
                hairCheck = true;
            }
            else if (mat.name.StartsWith("mouth"))
            {
                mat.color = endMouthColor;
                mouthCheck = true;
            }
            if (hairCheck && eyeCheck && mouthCheck) break;
        }
        render.materials = mats;
    }
}
