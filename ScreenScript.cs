using System.Collections;
using UnityEditor;
using UnityEngine;

public class ScreenScript : MonoBehaviour
{
    private readonly float waitTime = 0.01f;
    private readonly int frameCount = 20;
    private readonly int turns = 6;

    ControllerScript controllerScript;
    private bool status;
    private int control;
    private int fCounter;
    private int tCounter;

    private Renderer screen;

    private Material[,] mats;

    void Start()
    {
        status = false;
        fCounter = 0;
        tCounter = 0;
        control = 0;
        controllerScript = GameObject.FindWithTag("controller").GetComponent<ControllerScript>();
        
        screen = gameObject.transform.Find("screen").gameObject.GetComponent<Renderer>();

        mats = new Material[turns, frameCount];

        for(int i = 0; i < turns; i++)
        {
            for(int j = 0; j < frameCount; j++)
            {
                mats[i, j] = ((Material)AssetDatabase.LoadAssetAtPath("Assets/Capture/" + (i + 1) +"/Materials/" + (j + 1) + ".mat", typeof(Material)));
            }
        }
    }
    
    void Update()
    {
        if(status)
        {
            if (turns > tCounter)
            {
                if (frameCount > fCounter)
                {
                    switch (control)
                    {
                        case 0:
                            control++;
                            break;
                        case 1:
                            control++;
                            break;
                        case 2:
                            screen.material = mats[tCounter, fCounter];
                            control = 0;
                            fCounter++;
                            break;
                    }
                }
                else
                {
                    tCounter++;
                    fCounter = 0;
                }
            }
            else
            {
                status = false;
                controllerScript.SetStatus(gameObject.tag);
            }
        }
    }

    public void ShowFeed()
    {
        fCounter = 0;
        tCounter = 0;
        control = 0;
        status = true;
    }
}
