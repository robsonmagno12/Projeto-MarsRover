using MarsRover.Models;
using Xunit;

namespace MarsRover.Tests
{
    public class RoverTests
    {
        [Fact]
        public void Rover_ExecutaComandosCorretamente()
        {
            var plateau = new Plateau(5, 5);
            var rover = new Rover(new Position(1, 2), Direction.N, plateau);

            rover.Execute("LMLMLMLMM");

            Assert.Equal(1, rover.Position.X);
            Assert.Equal(3, rover.Position.Y);
            Assert.Equal(Direction.N, rover.Direction);
        }

        [Fact]
        public void Rover_NaoSaiDoPlanalto()
        {
            var plateau = new Plateau(2, 2);
            var rover = new Rover(new Position(0, 0), Direction.S, plateau);

            rover.Execute("M");

            Assert.Equal(0, rover.Position.X);
            Assert.Equal(0, rover.Position.Y); // movimento ignorado
        }

        [Fact]
        public void Rover_NaoEntraEmPosicaoOcupada()
        {
            var plateau = new Plateau(5, 5);
            var rover1 = new Rover(new Position(1, 2), Direction.N, plateau);
            var rover2 = new Rover(new Position(3, 3), Direction.W, plateau);

            rover1.Execute("MM"); // Vai para (1,4)

            rover2.Execute("MM"); // Tentaria (1,3) -> (1,2) -> colisão

            Assert.NotEqual(rover1.Position, rover2.Position);
        }

        [Fact]
        public void LancaErro_SePosicaoInicialOcupada()
        {
            var plateau = new Plateau(5, 5);
            var rover1 = new Rover(new Position(0, 0), Direction.N, plateau);

            Assert.Throws<InvalidOperationException>(() =>
                new Rover(new Position(0, 0), Direction.E, plateau));
        }
    }
}