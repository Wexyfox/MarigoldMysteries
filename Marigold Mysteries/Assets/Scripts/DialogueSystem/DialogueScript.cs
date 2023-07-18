using UnityEngine;

namespace MarigoldMysteries
{
    [CreateAssetMenu(fileName = "DialogueScript", menuName = "ScriptableObjects/DialogueScript")]
    public class DialogueScript : ScriptableObject
    {
        [SerializeField] private string pr_DialogueScriptName;
        [SerializeField] private DialogueNode[] pr_DialogueNodes;

        public void SetDialogueScriptName(string pa_DialogueScriptName)
        {
            pr_DialogueScriptName = pa_DialogueScriptName;
        }

        public void SetDialogueNodes(DialogueNode[] pa_DialogueNodes)
        {
            pr_DialogueNodes = pa_DialogueNodes;
        }

        public DialogueNode GetNodeFromID(string pa_DialogueNodeID)
        {
            foreach (DialogueNode l_DialogueNode in pr_DialogueNodes)
            {
                if (l_DialogueNode.DialogueID() != pa_DialogueNodeID) continue;
                return l_DialogueNode;
            }
            return new DialogueNode();
        }

        public DialogueNode GetFirstNode()
        {
            if (pr_DialogueNodes.Length > 0)
            {
                return pr_DialogueNodes[0];
            }
            return new DialogueNode();
        }

        public string ScriptName()
        {
            return pr_DialogueScriptName;
        }
    }
}
