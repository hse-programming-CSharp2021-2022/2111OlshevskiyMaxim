using static System.Console;

class Object
{
    public static string Grade(int grade)
    {
        switch (grade)
        {
            case 1:
                return "Неудовлитворительно.";
                break;
            case 2:
                return "Неудовлитворительно.";
                break;
            case 3:
                return "Неудовлитворительно.";
                break;
            case 4:
                return "Удовлитворительно.";
                break;
            case 5:
                return "Удовлитворительно.";
                break;
            case 6:
                return "Хорошо.";
                break;
            case 7:
                return "Хорошо.";
                break;
            case 8:
                return "Отлично.";
                break;
            case 9:
                return "Отлично.";
                break;
            case 10:
                return "Отлично.";
                break;
        }
        return "Error";
    }

    static void Main()
    {
        int grade = int.Parse(ReadLine());
        WriteLine(Grade(grade));
    }
}
