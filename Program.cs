const int CommandAddDosier = 1;
const int CommandConclusionDossier = 2;
const int CommandDeleteDosier = 3;
const int CommandSearchByLastName = 4;
const int CommandExit = 5;

string[,] fullName = new string[0, 0];
string[] jobTitle = new string[0];
int userChoise = 0;

while(userChoise != CommandExit)
{ 
    Console.WriteLine($"Добро пожаловать в программу управления досье. Выберите действие: " +
        $"\n{CommandAddDosier}: добавить досье в массив;" +
        $"\n{CommandConclusionDossier}: вывести весь массив досье;" +
        $"\n{CommandDeleteDosier}: удалить массив из досье;" +
        $"\n{CommandSearchByLastName}: поиск досье по фамилии." +
        $"\n{CommandExit}: выйти из программы");
    userChoise = Console.Read();
    switch (userChoise)
    {
       case CommandAddDosier:
           AddDosier(fullName, jobTitle);
           break;
       case CommandConclusionDossier:
           ConclusionDossier(fullName, jobTitle);
           break;
           case CommandDeleteDosier:
           DeleteDosier(fullName, jobTitle);
           break;
           case CommandSearchByLastName:
            SearchByLastName(fullName, jobTitle);
           break;
        case CommandExit:
        break;
    }
    Console.Clear();
}
static void AddDosier(string[,] fullName, string[] jobTitle)
{
    string[,] tempFullName = new string[fullName.GetLength(0) + 1, 2];
    Console.WriteLine("Введите фамилию.");
    tempFullName[tempFullName.GetLength(0), 0] = Console.ReadLine();
    Console.WriteLine("Введите имя.");
    tempFullName[tempFullName.GetLength(0), 1] = Console.ReadLine();
    Console.WriteLine("Введите отчество.");
    tempFullName[tempFullName.GetLength(0), 2] = Console.ReadLine();
    string[] tempJobTitle = new string[jobTitle.Length + 1];
    Console.WriteLine("Введите должность.");
    tempJobTitle[tempJobTitle.Length] = Console.ReadLine();
    fullName = tempFullName;
    jobTitle = tempJobTitle;
}

static void ConclusionDossier(string[,] fullName, string[] jobTitle)
{
    Console.WriteLine("Вот все досье: ");

    for (int i = 0; i < fullName.GetLength(0) - 1; i++)
    {
        Console.WriteLine((i + 1) + ": " + fullName[i, 0] + fullName[i, 1] + fullName[i, 2] + " - " + jobTitle[i]);
    }
}

static void DeleteDosier(string[,] fullName, string[] jobTitle)
{
    Console.WriteLine("Досье под каким номером вы хотите удалить?");
    int DeleteNumber = Console.Read();
    string deleteString = "delete";
    fullName[DeleteNumber, 0] = deleteString;
    fullName[DeleteNumber, 1] = deleteString;
    fullName[DeleteNumber, 2] = deleteString;
    jobTitle[DeleteNumber] = deleteString;
    string[,] tempFullName = new string[fullName.GetLength(0) - 1, 2];
    string[] tempJobTitle = new string[jobTitle.Length - 1];
    int whetherRemoved = 0;

    for (int i = 0; i < fullName.GetLength(0) - 2; i++)
    {
        if (fullName[i, 0] == deleteString && fullName[i, 1] == deleteString && fullName[i, 2] == deleteString && jobTitle[i] == deleteString)
        {
            whetherRemoved++;
        }
        else
        {
            tempFullName[i - whetherRemoved, 0] = fullName[i, 0];
            tempFullName[i - whetherRemoved, 1] = fullName[i, 1];
            tempFullName[i - whetherRemoved, 2] = fullName[i, 2];
            tempJobTitle[i - whetherRemoved] = jobTitle[i];
        }
    }
}

static void SearchByLastName(string[,] fullName, string[] jobTitle)
{
    Console.WriteLine("Введите фамилию, которую хотели бы найти");
    string enterLastName = Console.ReadLine();

    Console.WriteLine("Выводим все досье с такой фамилией...");

    for (int i = 0; i < fullName.GetLength(0); i++)
    {
        if (fullName[0, 0] == enterLastName)
        {
            Console.WriteLine((i + 1) + ": " + fullName[i, 0] + fullName[i, 1] + fullName[i, 2] + " - " + jobTitle[i]);
        }
    }
}