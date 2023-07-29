using UnityEngine;
using System.Collections.Generic;

namespace MarigoldMysteries
{
    [CreateAssetMenu(fileName = "Dependencies", menuName = "ScriptableObjects/Dependencies")]
    public class DependenciesSO : ScriptableObject
    {
        [SerializeField] private List<Dependency> pr_Dependencies = new List<Dependency>();

        public void SetDependencyStatus(string pa_DependencyName, bool pa_Status)
        {
            Dependency l_Dependency = pr_Dependencies.Find(i => i.Name() == pa_DependencyName);

            if (l_Dependency != null) l_Dependency.SetStatus(pa_Status);
            else Debug.LogError($"Variable '{pa_DependencyName}' not found in InfoHolder.");
        }

        public bool CheckDependencyStatus(string pa_DependencyName)
        {
            Dependency l_Dependency = pr_Dependencies.Find(i => i.Name() == pa_DependencyName);

            if (l_Dependency != null) return l_Dependency.Status();
            
            Debug.LogError($"Variable '{pa_DependencyName}' not found in InfoHolder.");
            return false;
        }

        public bool CheckMultipleDependencies(string[] pa_DependencyNames, bool pa_ExpectedStatus)
        {
            foreach (string l_DependencyName in pa_DependencyNames)
            {
                if (CheckDependencyStatus(l_DependencyName) != pa_ExpectedStatus) return false;
            }
            return true;
        }
    }
}