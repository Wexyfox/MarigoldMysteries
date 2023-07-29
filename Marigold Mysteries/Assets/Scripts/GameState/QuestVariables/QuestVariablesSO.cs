using UnityEngine;
using System.Collections.Generic;

namespace MarigoldMysteries
{
    [CreateAssetMenu(fileName = "QuestVariables", menuName = "ScriptableObject/QuestVariables")]
    public class QuestVariablesSO : ScriptableObject
    {
        [SerializeField] private List<QuestVariable> pr_QuestVariables = new List<QuestVariable>();

        public void SetInfoStatus(string pa_VariableName, bool pa_Status)
        {
            QuestVariable l_QuestVariable = pr_QuestVariables.Find(i => i.Name() == pa_VariableName);

            if (l_QuestVariable != null) l_QuestVariable.SetStatus(pa_Status);
            else Debug.LogError($"Variable '{pa_VariableName}' not found in InfoHolder.");
        }

        public bool Check(string pa_VariableName)
        {
            QuestVariable l_QuestVariable = pr_QuestVariables.Find(i => i.Name() == pa_VariableName);

            if (l_QuestVariable != null) return l_QuestVariable.Status();
            
            Debug.LogError($"Variable '{pa_VariableName}' not found in InfoHolder.");
            return false;
        }

        public bool CheckMultipleVariables(string[] pa_VariableNames, bool pa_ExpectedStatus)
        {
            foreach (string l_VariableName in pa_VariableNames)
            {
                if (Check(l_VariableName) != pa_ExpectedStatus) return false;
            }
            return true;
        }
    }
}