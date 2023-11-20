using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SceneManager : MonoBehaviour
{ 
    [SerializeField] private GameObject m_registerUI         = null;
    [SerializeField] private GameObject m_loginUI            = null;
    [SerializeField] private Text       m_textText           = null;
    [SerializeField] private InputField m_userNameInput      = null;
    [SerializeField] private InputField m_password           = null;
    [SerializeField] private InputField m_emailInput         = null;
    [SerializeField] private InputField m_reEnterPassword    = null;

    private NetworkManager m_networkManager = null;

    private void Awake()
    {
        m_networkManager = GameObject.FindObjectOfType<NetworkManager>();
    }

    public void SubmitLogin()
    {
        if(m_userNameInput.text == "" || m_emailInput.text == "" || m_password.text == "" || m_reEnterPassword.text == "")
        {
            m_textText.text = "Porfavor llene todos los campos";
            return;
        }

        if(m_password.text == m_reEnterPassword.text)
        {
            m_textText.text = "Procesando...";
            m_networkManager.CreateUser(m_userNameInput.text, m_emailInput.text, m_password.text, delegate (Response response)
              {

                  m_textText.text = response.message;

              });

        }
        else
        {
            m_textText.text = "Contrasena invalida";

        }

    }
    
    public void ShowLogin()
    {
        m_registerUI.SetActive(false);
        m_loginUI.SetActive(true);
    }

    internal static void LoadScene(int sceneId)
    {
        throw new NotImplementedException();
    }

    public void ShowRegister()
    {
        m_registerUI.SetActive(true);
        m_loginUI.SetActive(false);
    }

    internal static AsyncOperation LoadSceneAsync(int sceneId)
    {
        throw new NotImplementedException();
    }
}

