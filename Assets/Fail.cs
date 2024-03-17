using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fail : MonoBehaviour
{
   public void OnFail()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
