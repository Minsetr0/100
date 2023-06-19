const int CommandAddDosier = 1;
const int CommandConclusionDossier = 2;
const int CommandDeleteDosier = 3;
const int CommandSearchByLastName = 4;
const int CommandExit = 5;

string[,] dossiersFullName = new string[3,2] { { "Архипов", "Столяров" }, { "Михаил", "Фёдор" }, { "Юрьевич", "Ибрагимович" } };
string[] dossiersJobTitle = new string[2] {"уборщик", "дворник"};
int userChoise = 0;
int numberToDeleteDosier = 0;

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
            InputNumber(numberToDeleteDosier);
            DeleteNameDosier(dossiersFullName, numberToDeleteDosier);
            DeleteJobTitleDossier(dossiersJobTitle, numberToDeleteDosier);
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
    string[,] tempFullName = new string[3, fullName.GetLength(0) + 1];

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
    tempJobTitle[tempJobTitle.Length - 1] = Console.ReadLine();
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
static int InputNumber(int numberToDeleteDosier)
{
    Console.WriteLine("Досье под каким номером вы хотите удалить?");
    numberToDeleteDosier = Convert.ToInt32(Console.ReadLine());
    return numberToDeleteDosier;
}
static string[,] DeleteNameDosier(string[,] fullName, int deleteNumber)
{
    string deleteString = "delete";
    fullName[0, deleteNumber] = deleteString;
    fullName[1, deleteNumber] = deleteString;
    fullName[2, deleteNumber] = deleteString;
    string[,] tempFullName = new string[2, fullName.GetLength(0) - 2];
    int whetherRemoved = 0;

    for (int i = 0; i < fullName.GetLength(1) - 1; i++)
    {
        if (fullName[0, i] == deleteString || fullName[1, i] == deleteString || fullName[2, i] == deleteString)
        {
            whetherRemoved++;
        }
        else
        {
            tempFullName[0, i - whetherRemoved] = fullName[0, i];
            tempFullName[1, i - whetherRemoved] = fullName[1, i];
            tempFullName[2, i - whetherRemoved] = fullName[2, i];
        }
    }

    return tempFullName;
}
static string[] DeleteJobTitleDossier(string[] jobTitle, int deleteNumber)
{
    string deleteString = "delete";
    jobTitle[deleteNumber] = deleteString;
    string[] tempJobTitle = new string[jobTitle.Length - 1];
    int whetherRemoved = 0;

    for (int i = 0; i < jobTitle.GetLength(0) - 2; i++)
    {
        if (jobTitle[i] == deleteString)
        {
            whetherRemoved++;
        }
        else
        {
            tempJobTitle[i - whetherRemoved] = jobTitle[i];
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
        if (fullName[0, i - 1] == enterLastName)
        {
            Console.WriteLine((i + 1) + ": " + fullName[0, i - 1] + fullName[1, i - 1] + fullName[2, i - 1] + " - " + jobTitle[i]);
        }
    }
}