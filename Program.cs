const int CommandAddDosier = 1;
const int CommandConclusionDossier = 2;
const int CommandDeleteDosier = 3;
const int CommandSearchByLastName = 4;

string[,] fullNameDossiers = new string[3,2] { { "Архипов", "Столяров" }, { "Михаил", "Фёдор" }, { "Юрьевич", "Ибрагимович" } };
string[] dossiersJobTitle = new string[2] {"уборщик", "дворник"};
int userChoise = 0;
int numberToDeleteDossier;
int commandExit = 5;

while (userChoise != commandExit)
{ 
    Console.WriteLine($"Добро пожаловать в программу управления досье. Выберите действие: " +
        $"\n{CommandAddDosier}: добавить досье в массив;" +
        $"\n{CommandConclusionDossier}: вывести весь массив досье;" +
        $"\n{CommandDeleteDosier}: удалить массив из досье;" +
        $"\n{CommandSearchByLastName}: поиск досье по фамилии." +
        $"\n{commandExit}: выйти из программы");
    userChoise = Convert.ToInt32(Console.ReadLine());
    switch (userChoise)
    {
        case CommandAddDosier:
            AddDossier();
            break;

        case CommandConclusionDossier:
            ConclusionDossier(fullNameDossiers, dossiersJobTitle);
            break;

        case CommandDeleteDosier:
            numberToDeleteDossier = InputNumber();
            DeleteDossier(numberToDeleteDossier);
            break;

        case CommandSearchByLastName:
            SearchByLastName(fullNameDossiers, dossiersJobTitle);
            break;

        default:
            if (userChoise != commandExit)
            {
                Console.WriteLine("Я вас не понял");
            }
            break;
    }
}
void AddDossier()
{
    dossiersJobTitle = AddJobTitleDossier(dossiersJobTitle);
    fullNameDossiers = AddNameDossier(fullNameDossiers);
}

void DeleteDossier(int deleteNumber)
{
    fullNameDossiers = DeleteNameDossier(fullNameDossiers, deleteNumber);
    dossiersJobTitle = DeleteJobTitleDossier(dossiersJobTitle, deleteNumber);
}
static string[,] AddNameDossier(string[,] fullName)
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
static string[] AddJobTitleDossier(string[] jobTitle)
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
    int numberToDeleteDossier = Convert.ToInt32(Console.ReadLine());
    return numberToDeleteDossier;
}
static string[,] DeleteNameDossier(string[,] fullName, int deleteNumber)
{
    string[,] tempFullName = new string[fullName.GetLength(0), fullName.GetLength(1) - 1];

    for (int i = 0; i < deleteNumber - 1; i++)
    {
        for (int j = 0; j < fullName.GetLength(0); j++)
        {
            tempFullName[j, i] = fullName[j, i];
        }
    }

    for (int i = deleteNumber; i < fullName.GetLength(1); i++)
    {
        for (int j = 0; j < fullName.GetLength(0); j++)
        {
            tempFullName[j, i - 1] = fullName[j, i];
        }
    }

    return tempFullName;
}


static string[] DeleteJobTitleDossier(string[] jobTitle, int deleteNumber)
{
    string[] tempJobTitle = new string[jobTitle.Length - 1];
    int index = 0;

    for (int i = 0; i < deleteNumber - 1; i++)
    {
        tempJobTitle[index] = jobTitle[i];
        index++;
    }

    for (int i = deleteNumber; i < jobTitle.Length; i++)
    {
        tempJobTitle[index] = jobTitle[i];
        index++;
    }

    return tempJobTitle;
}

static void SearchByLastName(string[,] fullName, string[] jobTitle)
{
    bool didItHatch = true;
    Console.WriteLine("Введите фамилию, которую хотели бы найти");
    string enterLastName = Console.ReadLine();
    Console.WriteLine("Выводим все досье с такой фамилией...");

    for (int i = 0; i < jobTitle.Length; i++)
    {
        if (fullName[0, i] == enterLastName)
        {
            Console.WriteLine((i + 1) + ": " + fullName[0, i] + " " + fullName[1, i] + " " + fullName[2, i] + " - " + jobTitle[i]);
            didItHatch = false;
        }
    }

    if (didItHatch)
    {
        Console.WriteLine("Нет ни одного человека с такой фамилией.\n");
    }
}