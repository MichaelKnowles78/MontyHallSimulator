namespace MontyHallSimulator;

static class Program
{
    private const int NumberOfDoors = 3;
    private const int NumberOfGames = 100;
    
    private static readonly Random random = new();

    /// <summary>
    /// Play 100 games to determine if it's better to stick or switch
    /// </summary>
    private static void Main()
    {
        int winsBySticking = 0;
        int winsBySwitching = 0;
        
        for (int mainLoop = 0;  mainLoop < NumberOfGames; mainLoop++)
        {
            Door[] doors = InitializeDoors();

            int carBehindDoorNumber = PlaceCarBehindRandomDoor(doors);
            int playerChoosesDoorNumber = PlayerChoosesRandomDoor(doors);
            int doorOpenedByHost = HostOpensDoor(doors);

            Console.WriteLine($"Door {carBehindDoorNumber} has the car behind it");
            Console.WriteLine($"Door {playerChoosesDoorNumber} has been chosen by the player");
            Console.WriteLine($"Door {doorOpenedByHost} has been opened by the host");

            if (carBehindDoorNumber == playerChoosesDoorNumber)
            {
                winsBySticking++;
            }
            else
            {
                winsBySwitching++;
            }           
        }

        Console.WriteLine($"If you stuck with your original choice you would have won {winsBySticking} times.  By switching you would " +
            $"have won {winsBySwitching} times.");
    }

    /// <summary>
    /// Create an array of 3 doors, numbered 1, 2, and 3
    /// </summary>
    /// <returns></returns>
    private static Door[] InitializeDoors()
    {
        Door.ResetNextDoorNumber();
        return new Door[NumberOfDoors] { new Door(), new Door(), new Door() };
    }

    /// <summary>
    /// Select a random door and update door.HasCarBehind
    /// </summary>
    /// <param name="doors"></param>
    /// <returns></returns>
    private static int PlaceCarBehindRandomDoor(Door[] doors)
    {
        int door = random.Next(1, NumberOfDoors + 1);
        doors.First(d => d.Number == door).HasCarBehind = true;

        return door;
    }

    /// <summary>
    /// Select a random door and update door.PlayerHasChosen
    /// </summary>
    /// <param name="doors"></param>
    /// <returns></returns>
    private static int PlayerChoosesRandomDoor(Door[] doors)
    {
        int door = random.Next(1, NumberOfDoors + 1);
        doors.First(d => d.Number == door).PlayerHasChosen = true;

        return door;
    }

    /// <summary>
    /// Host opens a door that doesn't have a car behind and the player didn't choose
    /// </summary>
    /// <param name="doors"></param>
    /// <returns></returns>
    private static int HostOpensDoor(Door[] doors)
    {
        int doorOpenedByHost = 0;
        
        foreach (Door door in doors)
        {
            if ((!door.HasCarBehind) && (!door.PlayerHasChosen))
            {
                door.HostOpened = true;
                doorOpenedByHost = door.Number;
                break;
            }
        }
        return doorOpenedByHost;
    }
}