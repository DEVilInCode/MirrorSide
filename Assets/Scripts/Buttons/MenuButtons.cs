using SharedLibrary.Requests;
using SharedLibrary.Responses;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public TMP_InputField loginField;
    public TMP_InputField emailField;
    public TMP_InputField passwordField;
    public TMP_InputField rePasswordField;

    public void Exit() 
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public async void SignIn()
    {
       // if (!UserDataValidation.CheckSignIn(loginField.text, passwordField.text).Equals("Success")) return;
        
        AuthenticationRequest request = new()
        {
            Username = loginField.text,
            Password = passwordField.text
        };

        var response = await HttpClient.Post<AuthenticationResponse>($"{Config.ServerUrl}/authentication/login", request);

        Debug.Log(response.Token);

        ToMain();
    }

    public async void SignUp()
    {
        //if (!rePasswordField.text.Equals(passwordField.text)) return;

        //if(!UserDataValidation.CheckSignUp(loginField.text, passwordField.text, emailField.text).Equals("Success")) return;

        AuthenticationRequest request = new()
        {
            Username = loginField.text,
            Password = passwordField.text
        };

        var response = await HttpClient.Post<AuthenticationResponse>($"{Config.ServerUrl}/authentication/register", request);

        Debug.Log(response.Token);

        ToMain();
    }

    public void ToSignIn()
    {
        SceneManager.LoadScene("SignIn");
    }

    public void ToSignUp() 
    {
        SceneManager.LoadScene("SignUp");
    }

    private void ToMain()
    {
        SceneManager.LoadScene("Game");
    }
}
