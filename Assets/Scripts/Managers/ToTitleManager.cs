using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToTitleManager : MonoBehaviour
{
    public void OnCkick()
    {
        SceneManager.LoadScene(0);
    }
}
