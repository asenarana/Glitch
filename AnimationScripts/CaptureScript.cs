using System.IO;
using UnityEngine;


public class CaptureScript : MonoBehaviour
{
    private bool captured;
    private string name;

    private void Start()
    {
        captured = true;
    }

    private void LateUpdate()
    {
        if(!captured)
        {
            CamCapture();
            captured = true;
        }
    }

    private void CamCapture()
    {
        Camera Cam = GetComponent<Camera>();

        RenderTexture currentRT = RenderTexture.active;
        RenderTexture.active = Cam.targetTexture;

        Cam.Render();

        Texture2D Image = new Texture2D(Cam.targetTexture.width, Cam.targetTexture.height, TextureFormat.RGB24, false);
        Image.ReadPixels(new Rect(0, 0, Cam.targetTexture.width, Cam.targetTexture.height), 0, 0);
        Image.Apply();
        RenderTexture.active = currentRT;

        var Bytes = Image.EncodeToPNG();
        Destroy(Image);

        File.WriteAllBytes(Application.dataPath + "/Capture/" + name + ".png", Bytes);
    }

    public void Capture(string name)
    {
        captured = false;
    }
}
  
