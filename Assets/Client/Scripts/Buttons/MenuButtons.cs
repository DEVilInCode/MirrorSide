using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void Exit() 
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void ToSignIn()
    {
        SceneManager.LoadScene("SignIn");
    }

    public void ToSignUp() 
    {
        SceneManager.LoadScene("SignUp");
    }
}
