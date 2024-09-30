using System.Text;
Console.OutputEncoding = Encoding.UTF8;
string[] words = { "собака", "земля", "школа", "бумага", "книга" };
int wrongattempts = 0;
StringBuilder guessedLetters = new StringBuilder();
Random random = new Random();
string randomwords = words[random.Next(0,words.Length-1)];
int win = randomwords.Length;
int attempts = randomwords.Length;
Console.WriteLine("Вітаємо! Спробуйте вгадати зашифроване слово!");
Console.WriteLine($"Кількість літер у слові: {randomwords.Length}");
Console.WriteLine($"Кількість можливих невірних спроб: {attempts}");

while(attempts>wrongattempts)
{
    char word;
    try
    {
        Console.Write("Введіть вашу літеру: ");
        word = Convert.ToChar(Console.ReadLine());
    }
    catch
    {
        Console.WriteLine("Ви ввели невірне значення у строку");
        continue;
    }
    if(guessedLetters.ToString().Contains(word))
    {
        Console.WriteLine("Ви вже вгадували цю літеру! Спробуйте іншу.");
        continue;
    }
    guessedLetters.Append(word);
    if (randomwords.Contains(word))
    {
        Console.Write("Така літера є у слові! Позиція літери: ");
        for (int i = 0; i < randomwords.Length; i++)
        {
            char letter = randomwords[i];
            

            if (word == letter)
            {
                Console.Write($"{i + 1}, ");
                win--;
            }
        }
        Console.WriteLine();
    }
    else
    {
        wrongattempts++;
        Console.WriteLine($"Такої літери немає! Залишилось спроб: {attempts - wrongattempts}");
    }
    if(win == 0)
    {
        Console.WriteLine($"\nВітаємо, ви вгадали слово! Зашифроване слово: {randomwords}.");
        Console.WriteLine("Дякуємо за гру.");
        break;

    }
    if (attempts==wrongattempts)
    {
        Console.WriteLine($"\nВи програли! Зашифроване слово було: {randomwords}.");
        Console.WriteLine("Дякуємо за гру.");
        break;
    }

}