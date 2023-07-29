namespace MarigoldMysteries
{
    [System.Serializable]
    public class Dependency
    {
        private string pr_DependencyName;
        private bool pr_Status;

        public string Name()
        {
            return pr_DependencyName;
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
