const int CommandAddDosier = 1;
const int CommandConclusionDossier = 2;
const int CommandDeleteDosier = 3;
const int CommandSearchByLastName = 4;
const int CommandExit = 5;

string[,] dossiersFullName = new string[3,2] { { "Архипов", "Столяров" }, { "Михаил", "Фёдор" }, { "Юрьевич", "Ибрагимович" } };
string[] dossiersJobTitle = new string[2] {"уборщик", "дворник"};
int userChoise = 0;
int numberToDeleteDosier;

while (userChoise != CommandExit)
{ 
    Console.WriteLine($"Добро пожаловать в программу управления досье. Выберите действие: " +
        $"\n{CommandAddDosier}: добавить досье в массив;" +
        $"\n{CommandConclusionDossier}: вывести весь массив досье;" +
        $"\n{CommandDeleteDosier}: удалить массив из досье;" +
        $"\n{CommandSearchByLastName}: поиск досье по фамилии." +
        $"\n{CommandExit}: выйти из программы");
    userChoise = Convert.ToInt32(Console.ReadLine());
    switch (userChoise)
    {
        case CommandAddDosier:
            dossiersJobTitle = AddJobTitleDosier(dossiersJobTitle);
            dossiersFullName = AddNameDosier(dossiersFullName);
            break;

        case CommandConclusionDossier:
            ConclusionDossier(dossiersFullName, dossiersJobTitle);
            break;

            case CommandDeleteDosier:
            numberToDeleteDosier = InputNumber();
            dossiersFullName = DeleteNameDosier(dossiersFullName, numberToDeleteDosier);
            dossiersJobTitle = DeleteJobTitleDossier(dossiersJobTitle, numberToDeleteDosier);
            break;

            case CommandSearchByLastName:
            SearchByLastName(dossiersFullName, dossiersJobTitle);
            break;

        case CommandExit:
            break;

        default:
            Console.WriteLine("Я вас не понял");
            break;
    }
}
static string[,] AddNameDosier(string[,] fullName)
{
    string[,] tempFullName = new string[3, fullName.GetLength(1) + 1];

    for (int i = 0; i < fullName.GetLength(0); i++)
    {
        for (int j = 0; j < fullName.GetLength(1); j++)
        {
            tempFullName[i, j] = fullName[i, j];
        }
    }

    Console.WriteLine("Введите фамилию.");
    tempFullName[0, tempFullName.GetLength(1) - 1] = Console.ReadLine();
    Console.WriteLine("Введите имя.");
    tempFullName[1, tempFullName.GetLength(1) - 1] = Console.ReadLine();
    Console.WriteLine("Введите отчество.");
    tempFullName[2, tempFullName.GetLength(1) - 1] = Console.ReadLine();
    return tempFullName;
}
static string[] AddJobTitleDosier(string[] jobTitle)
{
    string[] tempJobTitle = new string[jobTitle.Length + 1];

    for (int i = 0; i < jobTitle.Length; i++)
    {
        tempJobTitle[i] = jobTitle[i];
    }

    Console.WriteLine("Введите должность.");
    tempJobTitle[^1] = Console.ReadLine();
    return tempJobTitle;
}
static void ConclusionDossier(string[,] fullName, string[] jobTitle)
{
    Console.WriteLine("Вот все досье: ");

    for (int i = 0; i < jobTitle.Length; i++)
    {
        Console.WriteLine((i + 1) + ": " + fullName[0, i] + " " + fullName[1, i] + " " + fullName[2, i] + " - " + jobTitle[i]);
    }
}
static int InputNumber()
{
    Console.WriteLine("Досье под каким номером вы хотите удалить?");
    int numberToDeleteDosier = Convert.ToInt32(Console.ReadLine());
    return numberToDeleteDosier;
}
static string[,] DeleteNameDosier(string[,] fullName, int deleteNumber)
{
    string[,] tempFullName = new string[fullName.GetLength(0), fullName.GetLength(1) - 1];
    int index = 0;

    for (int i = 0; i < fullName.GetLength(1); i++)
    {
        if (i != deleteNumber - 1)
        {
            for (int j = 0; j < fullName.GetLength(0); j++)
            {
                tempFullName[j, index] = fullName[j, i];
            }
            index++;
        }
    }

    return tempFullName;
}

static string[] DeleteJobTitleDossier(string[] jobTitle, int deleteNumber)
{
    string[] tempJobTitle = new string[jobTitle.Length - 1];
    int index = 0;

    for (int i = 0; i < jobTitle.Length; i++)
    {
        if (i != deleteNumber - 1)
        {
            tempJobTitle[index] = jobTitle[i];
            index++;
        }
    }

    return tempJobTitle;
}
static void SearchByLastName(string[,] fullName, string[] jobTitle)
{
    Console.WriteLine("Введите фамилию, которую хотели бы найти");
    string enterLastName = Console.ReadLine();
    Console.WriteLine("Выводим все досье с такой фамилией...");

    for (int i = 0; i < jobTitle.Length; i++)
    {
        if (fullName[0, i] == enterLastName)
        {
            Console.WriteLine((i + 1) + ": " + fullName[0, i] + " " + fullName[1, i] + " " + fullName[2, i] + " - " + jobTitle[i]);
        }
    }
}