using UnityEngine;
using System.Collections;

public class CompanionServerManager : MonoBehaviour {
    private static CompanionServerManager instance;
    internal static CompanionServerManager Instance { get { return instance; } }
    internal string gameCode;
    internal string player;
    internal string instructionsXML;

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
        StartCoroutine(SendAuth(code));
    }
    internal IEnumerator SendAuth(string code)
    {
        WWWForm form = new WWWForm();
        form.AddField("code", code);
        gameCode = code.Remove(code.Length - 1);
        player = code[code.Length - 1].ToString();
        WWW www = new WWW("http://hazlett206.ddns.net/GlobalJam/SendAuth.php");
        yield return www;
        if (www.error == null)
        {
            instructionsXML = www.text;
        }
        else
        {
            Debug.Log("Auth error" + www.error);
            gameCode = "";
            player = "";
            instructionsXML = "";
        }
    }
}
