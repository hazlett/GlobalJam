﻿using UnityEngine;
using System.Collections;

public class ServerManager : MonoBehaviour {
    public static ServerManager Instance;
    internal string code;
    internal bool confirmed;
    internal bool codeCreated;
    internal bool[] playersConfirmed;
 

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        confirmed = false;
        codeCreated = false;
        playersConfirmed = new bool[]{false, false, false, false};
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            StartCoroutine("SendCode");
        }
        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            CompanionServerManager.Instance.Auth(code + "1");
            CompanionServerManager.Instance.Auth(code + "2");
            CompanionServerManager.Instance.Auth(code + "3");
            CompanionServerManager.Instance.Auth(code + "4");
        }
        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            StartCoroutine("CheckConfirmations");
        }
        if (Input.GetKeyUp(KeyCode.Alpha5))
        {
            StartCoroutine("ClearSession");
        }
    }

    internal void GetCode()
    {
        StartCoroutine("SendCode");
    }
    internal IEnumerator SendCode()
    {
        WWW www = new WWW("http://hazlett206.ddns.net/GlobalJam/SendPlayerCodes.php");
        yield return www;
        if (www.error == null)
        {
            Debug.Log(www.text);
            code = www.text;
            codeCreated = true;
            StartCoroutine("CheckConfirmations");
        }
        else
        {
            Debug.Log("SendCode error" + www.error);
        }
    }

    internal IEnumerator CheckConfirmations()
    {
        WWWForm form = new WWWForm();
        form.AddField("code", code);
        WWW www = new WWW("http://hazlett206.ddns.net/GlobalJam/CheckConfirmations.php", form);
        yield return www;
        if (www.error == null)
        {
            Debug.Log(www.text);
            if (www.text == "1234")
            {
                Debug.Log("confirmed!");
                playersConfirmed = new bool[] { true, true, true, true };
                confirmed = true;
            }
            else
            {
                if (www.text.Contains("1"))
                {
                    playersConfirmed[0] = true;
                }
                if (www.text.Contains("2"))
                {
                    playersConfirmed[1] = true;
                }
                if (www.text.Contains("3"))
                {
                    playersConfirmed[2] = true;
                }
                if (www.text.Contains("4"))
                {
                    playersConfirmed[3] = true;
                }
                StartCoroutine("CheckConfirmations");
            }
        }
        else
        {
            Debug.Log("CheckConfirmations error" + www.error);
        }
    }

    internal IEnumerator ClearSession()
    {
        WWWForm form = new WWWForm();
        form.AddField("code", code);
        WWW www = new WWW("http://hazlett206.ddns.net/GlobalJam/ClearSession.php", form);
        yield return www;
    }
}
