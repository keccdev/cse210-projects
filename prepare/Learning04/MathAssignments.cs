public class MathAssignment : Assignment
{
    private string _homeworkList;

    public MathAssignment(string studentName, string topic, string homeworkList, string v)
        : base(studentName, topic)
    {
        _homeworkList = homeworkList;
    }

    public string GetHomeworkList()
    {
        return _homeworkList;
    }
}