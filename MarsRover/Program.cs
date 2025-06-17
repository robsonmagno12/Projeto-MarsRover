
class Program
{
    static void Main()
    {
        var plateau = new Plateau(5, 5);

        var rover1 = new Router(new Position(1, 2), Direction.N, plateau);
        rover1.Execute("LMLMLMLMM");
        Console.WriteLine($"Sonda 1: {rover1}");

        var rover2 = new Rover(new Position(3, 3), Direction.E, plateau);
        rover2.Execute("MMRMMRMRRM");
        Console.WriteLine($"Sonda 2: {rover2}");
    }
}