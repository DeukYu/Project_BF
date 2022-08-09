using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Singleton Pattern
public class Managers : MonoBehaviour
{
    static Managers s_instance; // ���ϼ� ����
    static Managers Instance { get { Init(); return s_instance; } }
    // ������ ����
    #region Contents
    #endregion
    // �ý��� �ھ� ����
    #region Core
    DataManager _dataManager = new DataManager();
    public static DataManager Data { get { return Instance._dataManager; } }
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

            // TODO : �� �Ŵ��� �ʱ�ȭ
            s_instance._dataManager.Init();
        }
    }
    public static void Clear()
    {

    }
}
