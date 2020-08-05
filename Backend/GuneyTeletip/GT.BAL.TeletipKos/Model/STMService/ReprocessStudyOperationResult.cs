namespace GT.Job.Implementation
{
    public class ReprocessStudyOperationResult
    {
        public ReprocessStudyOperationResult(string[] accNoAffectedList)
        {
            AccNoAffectedList = accNoAffectedList;
        }
        public string[] AccNoAffectedList { get; set; }

    }
}
