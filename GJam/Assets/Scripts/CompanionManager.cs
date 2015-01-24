using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class CompanionManager : MonoBehaviour {

    public InputField input;

    public void Auth()
    {
        CompanionServerManager.Instance.Auth(input.text);
        input.text = "";
    }
}
