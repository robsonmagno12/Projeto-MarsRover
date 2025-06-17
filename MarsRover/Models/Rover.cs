using System;

namespace Rover.Models
{
    public class Rover
    {
        public Position Position { get; private set; }
        public Direction Direction { get; private set; }
        private readonly Plateau _plateau;

        public Rover(Position start, Direction dir, Plateau plateau)
        {
            Position = start;
            Direction = dir;
            _plateau = plateau;
            _plateau.Register(start);
        }

        public void Execute(string commands)
        {
            foreach (char cmd in commands.ToUpper())
            {
                switch (cmd)
                {
                    case 'L':
                        Direction = Direction.TurnLeft();
                        break;
                    case 'R':
                        Direction = Direction.TurnRight();
                        break;
                    case 'M':
                        var next = Position.Move(Direction);
                        if (_plateau.TryMove(Position, next))
                            Position = next;
                        break;
                }
            }
        }

        public override string ToString() => $"{Position.X} {Position.Y} {Direction}";
    }
}