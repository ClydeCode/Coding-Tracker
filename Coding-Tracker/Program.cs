CodingController Program = new();

while (true)
{
    Program.ShowMenu();

    Program.Navigate(Convert.ToInt32(Console.ReadLine()));

    Console.WriteLine("\nPress ENTER to Continue...");
    Console.ReadLine();
}
