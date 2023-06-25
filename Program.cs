const int CommandAddDosier = 1;
const int CommandConclusionDossier = 2;
const int CommandDeleteDosier = 3;
const int CommandSearchByLastName = 4;
const int CommandExit = 5;

string[] dossiersFullName = new string[0];
string[] dossiersJobTitle = new string[0];
int userChoice = 0;
int numberToDeleteDossier;

while (userChoice != CommandExit)
{
    Console.WriteLine($"Добро пожаловать в программу управления досье. Выберите действие: " +
        $"\n{CommandAddDosier}: добавить досье в массив;" +
        $"\n{CommandConclusionDossier}: вывести весь массив досье;" +
        $"\n{CommandDeleteDosier}: удалить досье из массива;" +
        $"\n{CommandSearchByLastName}: поиск досье по фамилии." +
        $"\n{CommandExit}: выйти из программы");
    userChoice = Convert.ToInt32(Console.ReadLine());

    switch (userChoice)
    {
        case CommandAddDosier:
            dossiersJobTitle = AddJobTitleDosier(dossiersJobTitle);
            dossiersFullName = AddNameDosier(dossiersFullName);
            break;

        case CommandConclusionDossier:
            ConclusionDossier(dossiersFullName, dossiersJobTitle);
            break;

        case CommandDeleteDosier:
            numberToDeleteDossier = InputNumber();
            dossiersFullName = DeleteDossier(dossiersFullName, numberToDeleteDossier);
            dossiersJobTitle = DeleteDossier(dossiersJobTitle, numberToDeleteDossier);
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

static string[] AddNameDosier(string[] fullName)
{
    string[] tempFullName = new string[fullName.Length + 1];

    for (int i = 0; i < fullName.Length; i++)
    {
        tempFullName[i] = fullName[i];
    }

    Console.WriteLine("Введите фамилию, имя и отчество через пробел.");
    tempFullName[tempFullName.Length - 1] = Console.ReadLine();
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

static void ConclusionDossier(string[] fullName, string[] jobTitle)
{
    Console.WriteLine("Вот все досье: ");

    for (int i = 0; i < fullName.Length; i++)
    {
        Console.WriteLine((i + 1) + ": " + fullName[i] + " - " + jobTitle[i]);
    }
}

static int InputNumber()
{
    Console.WriteLine("Досье под каким номером вы хотите удалить?");
    int numberToDeleteDossier = Convert.ToInt32(Console.ReadLine());
    return numberToDeleteDossier;
}

static string[] DeleteDossier(string[] array, int deleteNumber)
{
    string[] tempArray = new string[array.Length - 1];
    int index = 0;

    for (int i = 0; i < array.Length; i++)
    {
        if (i != deleteNumber - 1)
        {
            tempArray[index] = array[i];
            index++;
        }
    }

    return tempArray;
}

static void SearchByLastName(string[] fullName, string[] jobTitle)
{
    Console.WriteLine("Введите фамилию, которую хотели бы найти");
    string enterLastName = Console.ReadLine();
    Console.WriteLine("Выводим все досье с такой фамилией...");

    for (int i = 0; i < jobTitle.Length; i++)
    {
        if (fullName[i].StartsWith(enterLastName))
        {
            Console.WriteLine((i + 1) + ": " + fullName[i] + " - " + jobTitle[i]);
        }
    }
}
