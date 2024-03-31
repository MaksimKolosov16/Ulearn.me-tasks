using System.Data.Common;
using static Program;

public class Program
{
    public enum Mark
    {
        Empty,
        Cross,
        Circle
    }

    public enum GameResult
    {
        CrossWin,
        CircleWin,
        Draw
    }

    public static void Main()
    {
        Run("XXX OO. ...");
        Run("OXO XO. .XO");
        Run("OXO XOX OX.");
        Run("XOX OXO OXO");
        Run("... ... ...");
        Run("XXX OOO ...");
        Run("XOO XOO XX.");
        Run(".O. XO. XOX");
    }

    private static void Run(string description)
    {
        Console.WriteLine(description.Replace(" ", Environment.NewLine));
        Console.WriteLine(GetGameResult(CreateFromString(description)));
        Console.WriteLine();
    }

    private static Mark[,] CreateFromString(string str)
    {
        var field = str.Split(' ');
        var ans = new Mark[3, 3];
        for (int x = 0; x < field.Length; x++)
            for (var y = 0; y < field.Length; y++)
                ans[x, y] = field[x][y] == 'X' ? Mark.Cross : (field[x][y] == 'O' ? Mark.Circle : Mark.Empty);
        return ans;
    }

    private static GameResult GetGameResult(Mark[,] marks)
    {
        var crossWin = ExistWinningSequence(marks, Mark.Cross);
        var circleWin = ExistWinningSequence(marks, Mark.Circle);

        if (crossWin && !circleWin)
            return GameResult.CrossWin;
        else if (!crossWin && circleWin)
            return GameResult.CircleWin;
        else
            return GameResult.Draw;
    }

    private static bool ExistWinningSequence(Mark[,] field, Mark mark)
    {
        return ExistHorizontalWinningSequence(field, mark)
            || ExistVerticalWinningSequence(field, mark)
            || ExistDiagonalWinningSequence(field, mark);
    }

    private static bool ExistHorizontalWinningSequence(Mark[,] field, Mark mark)
    {
        int countOfIterations = field.GetLength(0);

        for (var x = 0; x < countOfIterations; x++)
        {
            var countOfMarks = 0;
              
            for (var y = 0; y < countOfIterations; y++, countOfMarks++)
            {
                if (field[x, y] != mark)
                    break;
            }

            if (countOfMarks == 3)
                return true;
        }

        return false;
    }

    private static bool ExistVerticalWinningSequence(Mark[,] field, Mark mark)
    {
        int countOfIterations = field.GetLength(0);

        for (var y = 0; y < countOfIterations; y++)
        {
            var countOfMarks = 0;
            for (var x = 0; x < countOfIterations; x++, countOfMarks++)
            {
                if (field[x, y] != mark)
                    break;
            }

            if (countOfMarks == 3)
                return true;
        }

        return false;
    }

    private static bool ExistDiagonalWinningSequence(Mark[,] field, Mark mark)
    {
        return ExistDiagonal1WinningSequence(field, mark) || ExistDiagonal2WinningSequence(field, mark);
    }

    private static bool ExistDiagonal1WinningSequence(Mark[,] field, Mark mark)
    {
        int countOfIterations = field.GetLength(0);

        for (int x = 0, y = 0; y < countOfIterations; x++, y++)
        {
            if (field[x, y] != mark)
                return false;
        }

        return true;
    }

    private static bool ExistDiagonal2WinningSequence(Mark[,] field, Mark mark)
    {
        int countOfIterations = field.GetLength(0);

        for (int x = 0, y = 2; x < countOfIterations; x++, y--)
        {
            if (field[x, y] != mark)
                return false;
        }

        return true;
    }
}
