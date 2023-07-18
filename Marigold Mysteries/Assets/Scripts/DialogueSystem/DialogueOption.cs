using UnityEngine;

namespace MarigoldMysteries
{
    [System.Serializable]
    public class DialogueOption
    {
        [SerializeField] private string pr_Node;
        [SerializeField] private string pr_Text;
        [SerializeField] private string[] pr_Dependencies;

        public DialogueOption(string pa_Node, string pa_Text, string pa_Dependencies)
        {
            pr_Node = pa_Node;
            pr_Text = pa_Text;
            pr_Dependencies = pa_Dependencies.Split(",");

            if (pr_Dependencies[0] != "") return;
            pr_Dependencies = new string[0];
        }

        public string Node()
        {
            return pr_Node;
        }

        public string Text()
        {
            return pr_Text;
        }

        public string[] Dependencies()
        {
            return pr_Dependencies;
        }
    }
}
