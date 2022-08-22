using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Singleton Pattern
public class Managers : MonoBehaviour
{
    static Managers s_instance; // 유일성 보장
    static Managers Instance { get { Init(); return s_instance; } }
    // 컨텐츠 관련
    #region Contents
    #endregion
    // 시스템 코어 관련
    #region Core
    DataManager _dataManager = new DataManager();
    InputManager _inputManager = new InputManager();
    ResourceManager _resourceManager = new ResourceManager();
    SceneManagerEx _sceneManager = new SceneManagerEx();
    SoundManager _soundManager = new SoundManager();
    UIManager   _uiManager = new UIManager();
    public static DataManager Data { get { return Instance._dataManager; } }
    public static InputManager Input { get { return Instance._inputManager; } }
    public static ResourceManager Resource { get { return Instance._resourceManager; } }
    public static SceneManagerEx Scene { get { return Instance._sceneManager; } }
    public static SoundManager Sound { get { return Instance._soundManager; } }
    public static UIManager UI { get { return Instance._uiManager; } }
    #endregion
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static void Init()
    {
        if(s_instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if(go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }
            DontDestroyOnLoad(go); 
            s_instance = go.GetComponent<Managers>();

            // TODO : 각 매니저 초기화
            s_instance._dataManager.Init();
            s_instance._soundManager.Init();
        }
    }
    public static void Clear()
    {
        Input.Clear();
        Sound.Clear();
        Scene.Clear();
    }
}
