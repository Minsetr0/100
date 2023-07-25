const int CommandAddDosier = 1;
const int CommandConclusionDossier = 2;
const int CommandDeleteDosier = 3;
const int CommandSearchByLastName = 4;
const int CommandExit = 5;

string[] fullNames = new string[3] { "Архипов Михаил Юрьевич", "Столяров Фёдор Ибрагимович", "Иванов Иван Иванович" };
string[] dossiersJobTitle = new string[3] { "уборщик", "дворник", "директор" };
int userChoice = 0;

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
            AddDossier();
            break;

        case CommandConclusionDossier:
            ConclusionDossier(fullNames, dossiersJobTitle);
            break;

        case CommandDeleteDosier:
            DeleteDossier();
            break;

        case CommandSearchByLastName:
            SearchByLastName(fullNames, dossiersJobTitle);
            break;

        default:
            if (userChoice != CommandExit)
            {
                Console.WriteLine("Я вас не понял");
            }
            break;
    }
}

void AddDossier()
{
    Console.WriteLine("Введите фамилию, имя и отчество через пробел:");
    string fullName = Console.ReadLine();
    Console.WriteLine("Введите должность:");
    string jobTitle = Console.ReadLine();

    Array.Resize(ref fullNames, fullNames.Length + 1);
    Array.Resize(ref dossiersJobTitle, dossiersJobTitle.Length + 1);

    fullNames[fullNames.Length - 1] = fullName;
    dossiersJobTitle[dossiersJobTitle.Length - 1] = jobTitle;
}

void DeleteDossier()
{
    Console.WriteLine("Досье под каким номером вы хотите удалить?");
    int numberToDeleteDossier = Convert.ToInt32(Console.ReadLine());

    if (numberToDeleteDossier >= 1 && numberToDeleteDossier <= fullNames.Length)
    {
        numberToDeleteDossier--;

        for (int i = numberToDeleteDossier; i < fullNames.Length - 1; i++)
        {
            fullNames[i] = fullNames[i + 1];
            dossiersJobTitle[i] = dossiersJobTitle[i + 1];
        }

        Array.Resize(ref fullNames, fullNames.Length - 1);
        Array.Resize(ref dossiersJobTitle, dossiersJobTitle.Length - 1);

        Console.WriteLine("Досье успешно удалено.");
    }
    else
    {
        Console.WriteLine("Некорректный номер досье.");
    }
}

void ConclusionDossier(string[] fullNames, string[] jobTitle)
{
    Console.WriteLine("Вот все досье: ");

    for (int i = 0; i < fullNames.Length; i++)
    {
        Console.WriteLine($"{i + 1}: {fullNames[i]} - {jobTitle[i]}");
    }
}

void SearchByLastName(string[] fullNames, string[] jobTitle)
{
    bool foundDossier = false;
    Console.WriteLine("Введите фамилию, которую хотите найти:");
    string enterLastName = Console.ReadLine();

    Console.WriteLine("Выводим все досье с такой фамилией...");

    for (int i = 0; i < fullNames.Length; i++)
    {
        if (fullNames[i].StartsWith(enterLastName, StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine($"{i + 1}: {fullNames[i]} - {jobTitle[i]}");
            foundDossier = true;
        }
    }

    if (!foundDossier)
    {
        Console.WriteLine("Нет ни одного человека с такой фамилией.\n");
    }
}
