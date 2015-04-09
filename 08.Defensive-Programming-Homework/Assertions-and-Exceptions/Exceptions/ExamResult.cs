using System;

public class ExamResult
{
    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        if (grade < 0)
        {
            throw new ArgumentException("grade can't be negative, please enter positive number");
        }

        if (minGrade < 0)
        {
            throw new ArgumentException("your minimum grade can't be negative, please enter positive number");
        }

        if (maxGrade <= minGrade)
        {
            throw new ArgumentException("maximum grade can't equal or smaller then minimum grade");
        }

        if (string.IsNullOrEmpty(comments))
        {
            throw new NullReferenceException("comments can't be null or empty, pleace enter comments");
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }

    public int Grade { get; private set; }

    public int MinGrade { get; private set; }

    public int MaxGrade { get; private set; }

    public string Comments { get; private set; }
}
