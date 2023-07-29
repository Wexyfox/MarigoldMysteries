namespace MarigoldMysteries
{
    [System.Serializable]
    public class QuestVariable
    {
        private string pr_VariableName;
        private bool pr_Status;

        public string Name()
        {
            return pr_VariableName;
        }

        public bool Status()
        {
            return pr_Status;
        }

        public void SetStatus(bool pa_NewStatus)
        {
            pr_Status = pa_NewStatus;
        }
    }
}
