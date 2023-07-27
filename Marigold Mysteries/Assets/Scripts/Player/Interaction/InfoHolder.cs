using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "InfoHolder", menuName = "Game/Info Holder")]
public class InfoHolder : ScriptableObject{
    [System.Serializable]
    public class Info{
        public string name;
        public bool status;
    }

    [SerializeField] private List<Info> infos = new List<Info>();

    public void SetInfoStatus(string variableName, bool status){
        Info info = infos.Find(i => i.name == variableName);
        if (info != null){
            info.status = status;
        }
        else{
            Debug.LogError($"Variable '{variableName}' not found in InfoHolder.");
        }
    }

    public bool Check(string variableName){
        Info info = infos.Find(i => i.name == variableName);
        if (info != null){
            return info.status;
        }
        else{
            Debug.LogError($"Variable '{variableName}' not found in InfoHolder.");
            return false;
        }
    }

    public bool CheckMultipleVariables(string[] variableNames, bool expectedStatus){
        foreach (string variableName in variableNames){
            if (Check(variableName) != expectedStatus)
                return false;
        }

        return true;
    }
}