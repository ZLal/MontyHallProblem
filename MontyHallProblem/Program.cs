using MontyHallProblem;

Console.WriteLine("Starting..");

int iterationCount = 100;
GameState state = new();
Game game = new();
for (int i = 0; i < iterationCount; i++)
{
    game.Iterate();
    state = game.GetState();
    Console.Write($"{state.IterationCount}, ");
    Console.Write($"Prize: {state.HiddenPrizePos}, Selection: {state.FirstSelection}, Reveal: {state.RevealedPos}, Switch: {state.SwitchSelection}");
    Console.WriteLine();
}
Console.WriteLine();
Console.WriteLine($"Success rate without switch : {Math.Round((((double)state.FirstSelectionWinCount / state.IterationCount) * 100),2)}%");
Console.WriteLine($"Success rate after switch   : {Math.Round((((double)state.SwitchSelectionWinCount / state.IterationCount) * 100),2)}%");
Console.WriteLine();

Console.WriteLine("Press enter to exit");
Console.ReadLine();