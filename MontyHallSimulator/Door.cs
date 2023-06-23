namespace MontyHallSimulator;

/// <summary>
/// Represents a door.  Creating instance will generate object with the next sequential door number
/// </summary>
class Door
{
    public bool HasCarBehind { get; set; }
    public bool PlayerHasChosen { get; set; }
    public bool HostOpened { get; set; }
    public int Number { get; }

    private static int nextDoorNumber = 1;

    /// <summary>
    /// Construct a door with the next sequential door number
    /// </summary>
    public Door()
    {
        Number = nextDoorNumber++;
    }

    /// <summary>
    /// Resets the static private that controls door numbering
    /// </summary>
    public static void ResetNextDoorNumber()
    {
        nextDoorNumber = 1;
    }
}
