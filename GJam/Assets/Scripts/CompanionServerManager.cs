using UnityEngine;
using System.Collections;

public class CompanionServerManager : MonoBehaviour {
    private static CompanionServerManager instance;
    internal static CompanionServerManager Instance { get { return instance; } }
    internal string gameCode;
    internal string player;
    internal string instructionsXML;
    public GameObject SessionScreen, auth, AuthFailed;

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        gameCode = "";
        player = "";
        instructionsXML = "";
    }
 
    internal void Auth(string code)
    {
        auth.SetActive(true);
        SessionScreen.SetActive(false);
        StartCoroutine(SendAuth(code));
    }
    internal IEnumerator SendAuth(string code)
    {
        WWWForm form = new WWWForm();
        form.AddField("code", code);
        gameCode = code.Remove(code.Length - 1);
        player = code[code.Length - 1].ToString();
        WWW www = new WWW("http://hazlett206.ddns.net/GlobalJam/SendAuth.php", form);
        yield return www;
        if (www.error == null)
        {
            Debug.Log("send auth: |" + www.text + "|");
            if (www.text == "-1\n")
            {
                Debug.Log("No game exists");
                FailedAuth();
            }
            if (www.text == "-2\n")
            {
                Debug.Log("No player remains");
                FailedAuth();
            }
            else
            {
                instructionsXML = www.text;
            }
        }
        else
        {
            Debug.Log("Auth error" + www.error);
            FailedAuth();
        }
        auth.SetActive(false);
    }
    private void FailedAuth()
    {
        Debug.Log("Auth failed");
        AuthFailed.SetActive(true);
        gameCode = "";
        player = "";
        instructionsXML = "";
    }
}
