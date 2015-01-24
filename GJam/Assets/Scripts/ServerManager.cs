using UnityEngine;
using System.Collections;

public class ServerManager : MonoBehaviour {
    private string code;


    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            StartCoroutine("SendCode");
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            StartCoroutine("ClearSession");
        }
    }


    internal IEnumerator SendCode()
    {
        WWW www = new WWW("http://hazlett206.ddns.net/GlobalJam/SendPlayerCodes.php");
        yield return www;
        if (www.error == null)
        {
            Debug.Log(www.text);
            code = www.text;
        }
        else
        {
            Debug.Log("error" + www.error);
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
