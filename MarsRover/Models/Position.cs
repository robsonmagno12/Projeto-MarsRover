namespace Rover.Models
{
    public record Position(int X, int Y)
    {
        public Position Move(Direction direction) =>
            direction switch
            {
                Direction.N => new(X, Y + 1),
                Direction.E => new(X + 1, Y),
                Direction.S => new(X, Y - 1),
                Direction.W => new(X - 1, Y),
                _ => this
            };
    }
}