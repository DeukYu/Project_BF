using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoScene : BaseScene
{
    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Logo;
    }
    public override void Clear()
    {
        Debug.Log("LogoScene Clear!");
    }
}
