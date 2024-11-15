
namespace MontyHallProblem
{
    public struct GameState
    {
        public int HiddenPrizePos { get; set; }
        public int RevealedPos { get; set; }
        public int FirstSelection { get; set; }
        public int SwitchSelection { get; set; }

        public int IterationCount { get; set; }
        public int FirstSelectionWinCount { get; set; }
        public int SwitchSelectionWinCount { get; set; }
    }

    public class Game
    {
        GameState state = new();
        public GameState GetState() => state;
        public void Reset() => state = new GameState();

        private void ResetChoice()
        {
            state.HiddenPrizePos = 0;
            state.RevealedPos = 0;
            state.FirstSelection =
            state.SwitchSelection = 0;
        }

        private void SelectPositions()
        {
            int[] positions = new int[3] { 1, 2, 3 };

            state.HiddenPrizePos = positions[Random.Shared.Next(positions.Length)];
            state.FirstSelection = positions[Random.Shared.Next(positions.Length)];

            // Select random door to reveal. Exclude prize and selected position
            int[] remainPos = positions.Where(x => x != state.HiddenPrizePos && x != state.FirstSelection).ToArray();
            state.RevealedPos = remainPos[Random.Shared.Next(remainPos.Length)];

            // Switch selection from first to unrevealed option
            state.SwitchSelection = positions.SingleOrDefault(x => x != state.FirstSelection && x != state.RevealedPos);
        }

        private void Calculate()
        {
            state.IterationCount++;
            if (state.HiddenPrizePos == state.FirstSelection) state.FirstSelectionWinCount++;
            if (state.HiddenPrizePos == state.SwitchSelection) state.SwitchSelectionWinCount++;
        }

        public void Iterate()
        {
            ResetChoice();
            SelectPositions();
            Calculate();
        }
    }
}
