using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;
using UnityEngine.Diagnostics;

public class Managers : MonoBehaviour
{
    public static Managers s_instance;
    public static Managers Instance { get { Init();  return s_instance; } }  // Singleton Pattern

    /* Cloned Codes */
    //private static GameManagerEx s_gameManager = new GameManagerEx();
    //private static GoogleAdsManager s_adsmanager = new GoogleAdsManager();
    //private static DataManager s_dataManager = new DataManager();
    //private static UIManager s_uiManager = new UIManager();
    private static ResourceManager s_resourceManager = new ResourceManager();
    //private static SoundManager s_soundManager = new SoundManager();
    //private static CutsceneManager s_cutsceneManger = new CutsceneManager();

    //public static GameManagerEx Game { get { Init(); return s_gameManager; } }
    //public static GoogleAdsManager Ads { get { Init(); return s_adsmanager; } }
    //public static DataManager Data { get { Init(); return s_dataManager; } }
    //public static UIManager UI { get { Init(); return s_uiManager; } }
    public static ResourceManager Resource { get { Init(); return s_resourceManager; } }
    //public static SoundManager Sound { get { Init(); return s_soundManager; } }
    //public static CutsceneManager Cutscene { get { Init(); return s_cutsceneManger; } }

    private void Start()
    {
        Init();
    }

    private static void Init()
    {
        if (s_instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if (go == null)
                go = new GameObject { name = "@Managers" };

            s_instance = Utils.GetOrAddComponent<Managers>(go);
            DontDestroyOnLoad(go);

            Application.targetFrameRate = 60;
        }
    }
}
