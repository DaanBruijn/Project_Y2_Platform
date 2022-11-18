using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
   public void ReloadScene()
   {
      LevelFade.Instance.FadeToLevel(GameManager.Instance.currentSceneName);
   }
}
