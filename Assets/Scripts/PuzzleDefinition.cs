public class PuzzleDefinition
{
	public PuzzleDefinition(string question, string answer)
	{
        Question = question;
        Answer = answer;
        UnlocksCount = 0;
	}

	public string Question { get; private set; }
    public string Answer { get; private set; }

    public int UnlocksCount { get; set; }
}
