using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginScene : BaseScene
{
    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Login;
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))
        {
            System.Console.WriteLine("Mouse Button Down");
            Managers.Scene.LoadScene(Define.Scene.Lobby);
        }
    }
    public override void Clear()
    {
        Debug.Log("LoginScene Clear!");
    }
}
