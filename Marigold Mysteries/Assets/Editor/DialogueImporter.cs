using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace MarigoldMysteries
{
    public class DialogueImporter : EditorWindow
    {
        private string pr_DialogueScriptName;
        private TextAsset pr_DialogueScriptJson;

        private string pr_JsonStringPrimer = "{\"pu_RawDialogueArray\":";
        private string pr_JsonStringEnding = "}";

        [MenuItem("Window/DialogueImporter")]
        public static void ShowWindow()
        {
            GetWindow<DialogueImporter>("Dialogue Importer");
        }

        private void OnGUI()
        {
            pr_DialogueScriptName = EditorGUILayout.TextField("Dialogue script name", pr_DialogueScriptName);
            pr_DialogueScriptJson = (TextAsset)EditorGUILayout.ObjectField(pr_DialogueScriptJson, typeof(TextAsset), false);

            if (GUILayout.Button("Generate Dialogue Script"))
            {
                if (pr_DialogueScriptName == null || pr_DialogueScriptJson == null) return;

                string l_RawJsonString = pr_DialogueScriptJson.text;
                string l_RawJsonArrayString = pr_JsonStringPrimer + l_RawJsonString + pr_JsonStringEnding;
                Debug.Log(l_RawJsonArrayString);
                RawDialogueNodeArray l_RawDialogueNodeArray = JsonUtility.FromJson<RawDialogueNodeArray>(l_RawJsonArrayString);

                List<DialogueNode> l_DialogueNodeList = new List<DialogueNode>();
                foreach (RawDialogueNodeJson l_RawDialogueNode in l_RawDialogueNodeArray.pu_RawDialogueArray)
                {
                    l_DialogueNodeList.Add(new DialogueNode(l_RawDialogueNode));
                }
                DialogueNode[] l_ProcessedDialogueNodeArray = l_DialogueNodeList.ToArray();

                DialogueScript l_GeneratedDialogueScript = ScriptableObject.CreateInstance<DialogueScript>();

                l_GeneratedDialogueScript.SetDialogueScriptName(pr_DialogueScriptName);
                l_GeneratedDialogueScript.SetDialogueNodes(l_ProcessedDialogueNodeArray);

                string l_AssetPath = AssetDatabase.GenerateUniqueAssetPath(
                    $"Assets/_Project/DialogueSO/{l_GeneratedDialogueScript.ScriptName()}.asset");

                AssetDatabase.CreateAsset(l_GeneratedDialogueScript, l_AssetPath);
                AssetDatabase.SaveAssets();

                EditorUtility.FocusProjectWindow();
                Selection.activeObject = l_GeneratedDialogueScript;
            }
        }
    }
}
