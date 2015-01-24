using UnityEngine;
using System.Collections;

public class LoadingManager : MonoBehaviour {
    private float timer;
	void Start()
    {
        ServerManager.Instance.GetCode();
        timer = 5;
    }

    void OnGUI()
    {
        if (ServerManager.Instance.confirmed)
        {
            GUILayout.Label(Mathf.CeilToInt(timer).ToString());
        }
        GUILayout.Label("LOADING");
        ShowCodes();
    }
    void Update()
    {
        if (ServerManager.Instance.confirmed)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Application.LoadLevel("Game");
            }
        }
    }
    private void ShowCodes()
    {
        if (ServerManager.Instance.codeCreated)
        {
            GUILayout.Label("Player1: " + ServerManager.Instance.code + "1" + "\n" + ServerManager.Instance.playersConfirmed[0].ToString());
            GUILayout.Label("Player2: " + ServerManager.Instance.code + "2" + "\n" + ServerManager.Instance.playersConfirmed[1].ToString());
            GUILayout.Label("Player3: " + ServerManager.Instance.code + "3" + "\n" + ServerManager.Instance.playersConfirmed[2].ToString());
            GUILayout.Label("Player4: " + ServerManager.Instance.code + "4" + "\n" + ServerManager.Instance.playersConfirmed[3].ToString());
        }
    }
}
