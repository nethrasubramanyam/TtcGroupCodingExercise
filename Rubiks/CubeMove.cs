using System;

namespace TtcGroupRubiksCubeSimulator.Rubiks
{
    /// <summary>
    /// Represents a single rubiks cube movement.
    /// </summary>
    internal class CubeMove
    {
        /// <summary>
        /// Gets the side corresponding to the move.
        /// </summary>
        public CubeSide Side { get; }

        /// <summary>
        /// Gets the move direction.
        /// </summary>
        public Rotation Rotation { get; }

        public CubeMove(CubeSide side, Rotation rotation)
        {
            Side = side;
            Rotation = rotation;
        }

        /// <summary>
        /// Creates an instance of CubeMove from a single notation.
        /// </summary>
        /// <exception cref="ArgumentException">Value is not valid notation.</exception>
        public CubeMove(string notation)
        {
            switch (notation.Trim().ToLower())
            {
                case "f":
                    Rotation = Rotation.Cw;
                    Side = CubeSide.Front;
                    break;

                case "f'":
                    Rotation = Rotation.Aw;
                    Side = CubeSide.Front;
                    break;

                case "b":
                    Rotation = Rotation.Cw;
                    Side = CubeSide.Back;
                    break;

                case "b'":
                    Rotation = Rotation.Aw;
                    Side = CubeSide.Back;
                    break;

                case "r":
                    Rotation = Rotation.Cw;
                    Side = CubeSide.Right;
                    break;

                case "r'":
                    Rotation = Rotation.Aw;
                    Side = CubeSide.Right;
                    break;

                case "l":
                    Rotation = Rotation.Cw;
                    Side = CubeSide.Left;
                    break;

                case "l'":
                    Rotation = Rotation.Aw;
                    Side = CubeSide.Left;
                    break;

                case "u":
                    Rotation = Rotation.Cw;
                    Side = CubeSide.Up;
                    break;

                case "u'":
                    Rotation = Rotation.Aw;
                    Side = CubeSide.Up;
                    break;

                case "d":
                    Rotation = Rotation.Cw;
                    Side = CubeSide.Down;
                    break;

                case "d'":
                    Rotation = Rotation.Aw;
                    Side = CubeSide.Down;
                    break;

                default:
                    throw new ArgumentException("Value is not valid command.", nameof(notation));
            }
        }

    }
}
