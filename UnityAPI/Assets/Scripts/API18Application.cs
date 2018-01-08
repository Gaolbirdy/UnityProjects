using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class API18Application : MonoBehaviour 
{
    private void Start()
    {
        print(Application.identifier);
        print(Application.companyName);
        print(Application.productName);
        print(Application.installerName);
        print(Application.installMode);
        print(Application.isEditor);
        print(Application.isFocused);
        print(Application.isMobilePlatform);
        print(Application.isPlaying);
        print(Application.isWebPlayer);
        print(Application.platform);
        print(Application.unityVersion);
        print(Application.version);
        print(Application.runInBackground);

        Application.Quit();
        Application.OpenURL("www.sikiedu.com");
        //Application.CaptureScreenshot("游戏截图");
        //ScreenCapture.CaptureScreenshot("游戏截图.png");

        //Application.LoadLevel(1);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Application.isPlaying = false;
            //UnityEditor.EditorApplication.isPlaying = false;
            SceneManager.LoadScene(1);
        }
    }
}
