using System.Collections.Generic;
using UnityEngine;

namespace MarigoldMysteries
{
    [System.Serializable]
    public class DialogueNode
    {
        [SerializeField] private string pr_DialogueID;
        [SerializeField] private string pr_CharacterID;
        [SerializeField] private string pr_DialogueText;
        [SerializeField] private string pr_DefaultNode;
        [SerializeField] private string[] pr_Activates;

        [SerializeField] private DialogueOption[] pr_DialogueOptions;

        public DialogueNode()
        { 
        
        }

        public DialogueNode(RawDialogueNodeJson pa_RawDialogueNodeJson)
        {
            pr_DialogueID = pa_RawDialogueNodeJson.DialogueID;
            pr_CharacterID = pa_RawDialogueNodeJson.CharacterID;
            pr_DialogueText = pa_RawDialogueNodeJson.DialogueText;
            pr_DefaultNode = pa_RawDialogueNodeJson.DefaultNode;

            pr_Activates = pa_RawDialogueNodeJson.Activates.Split(",");
            if (pr_Activates[0] == "") pr_Activates = new string[0];

            List<DialogueOption> l_DialogueOptionList = DialogueOptionListInstantiation(pa_RawDialogueNodeJson);
            pr_DialogueOptions = l_DialogueOptionList.ToArray();
        }

        private List<DialogueOption> DialogueOptionListInstantiation(RawDialogueNodeJson pa_Json)
        {
            List<DialogueOption> l_TempList = new List<DialogueOption>();

            if (pa_Json.Option1Node == "" && pa_Json.Option1Text == "") return l_TempList;
            DialogueOption l_Option1 = new DialogueOption(pa_Json.Option1Node, pa_Json.Option1Text, pa_Json.Option1Dependencies);
            l_TempList.Add(l_Option1);

            if (pa_Json.Option2Node == "" && pa_Json.Option2Text == "") return l_TempList;
            DialogueOption l_Option2 = new DialogueOption(pa_Json.Option2Node, pa_Json.Option2Text, pa_Json.Option2Dependencies);
            l_TempList.Add(l_Option2);

            if (pa_Json.Option3Node == "" && pa_Json.Option3Text == "") return l_TempList;
            DialogueOption l_Option3 = new DialogueOption(pa_Json.Option3Node, pa_Json.Option3Text, pa_Json.Option3Dependencies);
            l_TempList.Add(l_Option3);

            if (pa_Json.Option4Node == "" && pa_Json.Option4Text == "") return l_TempList;
            DialogueOption l_Option4 = new DialogueOption(pa_Json.Option4Node, pa_Json.Option4Text, pa_Json.Option4Dependencies);
            l_TempList.Add(l_Option4);

            if (pa_Json.Option5Node == "" && pa_Json.Option5Text == "") return l_TempList;
            DialogueOption l_Option5 = new DialogueOption(pa_Json.Option5Node, pa_Json.Option5Text, pa_Json.Option5Dependencies);
            l_TempList.Add(l_Option5);

            if (pa_Json.Option6Node == "" && pa_Json.Option6Text == "") return l_TempList;
            DialogueOption l_Option6 = new DialogueOption(pa_Json.Option6Node, pa_Json.Option6Text, pa_Json.Option6Dependencies);
            l_TempList.Add(l_Option6);

            if (pa_Json.Option7Node == "" && pa_Json.Option7Text == "") return l_TempList;
            DialogueOption l_Option7 = new DialogueOption(pa_Json.Option7Node, pa_Json.Option7Text, pa_Json.Option7Dependencies);
            l_TempList.Add(l_Option7);

            if (pa_Json.Option8Node == "" && pa_Json.Option8Text == "") return l_TempList;
            DialogueOption l_Option8 = new DialogueOption(pa_Json.Option8Node, pa_Json.Option8Text, pa_Json.Option8Dependencies);
            l_TempList.Add(l_Option8);

            if (pa_Json.Option9Node == "" && pa_Json.Option9Text == "") return l_TempList;
            DialogueOption l_Option9 = new DialogueOption(pa_Json.Option9Node, pa_Json.Option9Text, pa_Json.Option9Dependencies);
            l_TempList.Add(l_Option9);

            if (pa_Json.Option10Node == "" && pa_Json.Option10Text == "") return l_TempList;
            DialogueOption l_Option10 = new DialogueOption(pa_Json.Option10Node, pa_Json.Option10Text, pa_Json.Option10Dependencies);
            l_TempList.Add(l_Option10);

            if (pa_Json.Option11Node == "" && pa_Json.Option11Text == "") return l_TempList;
            DialogueOption l_Option11 = new DialogueOption(pa_Json.Option11Node, pa_Json.Option11Text, pa_Json.Option11Dependencies);
            l_TempList.Add(l_Option11);

            if (pa_Json.Option12Node == "" && pa_Json.Option12Text == "") return l_TempList;
            DialogueOption l_Option12 = new DialogueOption(pa_Json.Option12Node, pa_Json.Option12Text, pa_Json.Option12Dependencies);
            l_TempList.Add(l_Option12);

            if (pa_Json.Option13Node == "" && pa_Json.Option13Text == "") return l_TempList;
            DialogueOption l_Option13 = new DialogueOption(pa_Json.Option13Node, pa_Json.Option13Text, pa_Json.Option13Dependencies);
            l_TempList.Add(l_Option13);

            if (pa_Json.Option14Node == "" && pa_Json.Option14Text == "") return l_TempList;
            DialogueOption l_Option14 = new DialogueOption(pa_Json.Option14Node, pa_Json.Option14Text, pa_Json.Option14Dependencies);
            l_TempList.Add(l_Option14);

            if (pa_Json.Option15Node == "" && pa_Json.Option15Text == "") return l_TempList;
            DialogueOption l_Option15 = new DialogueOption(pa_Json.Option15Node, pa_Json.Option15Text, pa_Json.Option15Dependencies);
            l_TempList.Add(l_Option15);

            if (pa_Json.Option16Node == "" && pa_Json.Option16Text == "") return l_TempList;
            DialogueOption l_Option16 = new DialogueOption(pa_Json.Option16Node, pa_Json.Option16Text, pa_Json.Option16Dependencies);
            l_TempList.Add(l_Option16);

            if (pa_Json.Option17Node == "" && pa_Json.Option17Text == "") return l_TempList;
            DialogueOption l_Option17 = new DialogueOption(pa_Json.Option17Node, pa_Json.Option17Text, pa_Json.Option17Dependencies);
            l_TempList.Add(l_Option17);

            if (pa_Json.Option18Node == "" && pa_Json.Option18Text == "") return l_TempList;
            DialogueOption l_Option18 = new DialogueOption(pa_Json.Option18Node, pa_Json.Option18Text, pa_Json.Option18Dependencies);
            l_TempList.Add(l_Option18);

            if (pa_Json.Option19Node == "" && pa_Json.Option19Text == "") return l_TempList;
            DialogueOption l_Option19 = new DialogueOption(pa_Json.Option19Node, pa_Json.Option19Text, pa_Json.Option19Dependencies);
            l_TempList.Add(l_Option19);

            if (pa_Json.Option20Node == "" && pa_Json.Option20Text == "") return l_TempList;
            DialogueOption l_Option20 = new DialogueOption(pa_Json.Option20Node, pa_Json.Option20Text, pa_Json.Option20Dependencies);
            l_TempList.Add(l_Option20);

            return l_TempList;
        }

        public string DialogueID()
        {
            return pr_DialogueID;
        }

        public string CharacterID()
        {
            return pr_CharacterID;
        }

        public string DialogueText()
        {
            return pr_DialogueText;
        }

        public string DefaultNode()
        {
            return pr_DefaultNode;
        }

        public string[] ActivatesVariables()
        {
            return pr_Activates;
        }

        public DialogueOption[] DialogueOptions()
        {
            return pr_DialogueOptions;
        }

        public bool HasDefaultNode()
        {
            return pr_DefaultNode != "";
        }

        public bool HasDialogueOptions()
        {
            return pr_DialogueOptions.Length > 0;
        }
    }
}
