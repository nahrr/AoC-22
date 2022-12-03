namespace AoC
{
    public class Day2
    {
        //TODO: bloated
        public static void Solve(List<string> input)
        {
            int grandScore = 0;
            foreach (var line in input)
            {
                List<string> hands = line.Split(' ').ToList();
                var elfHand = ParseMove(hands[0]);
                var gamerMe = ParseMove(hands[1]);
                var result = DecideWinner(elfHand, gamerMe);
                var pointsHand = CalcPointsHand(gamerMe);
                var pointRes = CalcPointRes(result);
                grandScore += pointsHand + pointRes;
            }
            Console.WriteLine($"Part one {grandScore}");
        }

        public static void Solve2(List<string> input)
        {
            int grandScore = 0;
            foreach (var line in input)
            {
                List<string> hands = line.Split(' ').ToList();
                var elfHand = ParseMove(hands[0]);
                var resultShouldBe = EncryptedMove(hands[1]);
                var encryptedMove = DecideMove(elfHand, resultShouldBe);
                var result = DecideWinner(elfHand, encryptedMove);
                var pointsHand = CalcPointsHand(encryptedMove);
                var pointRes = CalcPointRes(result);
                grandScore += pointsHand + pointRes;
            }
            Console.WriteLine($"Part two {grandScore}");
        }
        private static Move DecideMove(Move elfMove, Result resultShouldBe)
        {
            return resultShouldBe switch
            {
                Result.Lose when elfMove == Move.Rock => Move.Scissor,
                Result.Lose when elfMove == Move.Scissor => Move.Paper,
                Result.Lose when elfMove == Move.Paper => Move.Rock,
                Result.Win when elfMove == Move.Rock => Move.Paper,
                Result.Win when elfMove == Move.Scissor => Move.Rock,
                Result.Win when elfMove == Move.Paper => Move.Scissor,
                _ => elfMove
            };

        }
        private static Result EncryptedMove(string move)
        {
            return move.ToLower() switch
            {
                "x" => Result.Lose,
                "z" => Result.Win,
                _ => Result.Draw,
            };
        }

        private static int CalcPointsHand(Move hand)
        {
            return hand switch
            {
                Move.Rock => 1,
                Move.Paper => 2,
                _ => 3,
            };
        }
        private static int CalcPointRes(Result res)
        {
            return res switch
            {
                Result.Win => 6,
                Result.Lose => 0,
                _ => 3,
            };
        }
        private static Move ParseMove(string hand)
        {
            return hand.ToLower() switch
            {
                "a" => Move.Rock,
                "b" => Move.Paper,
                "c" => Move.Scissor,
                "x" => Move.Rock,
                "y" => Move.Paper,
                "z" => Move.Scissor,
                _ => throw new Exception("blbla"),
            };
        }

        private static Result DecideWinner(Move elf, Move me)
        {
            return elf switch
            {
                Move.Paper when me == Move.Rock => Result.Lose,
                Move.Scissor when me == Move.Paper => Result.Lose,
                Move.Rock when me == Move.Scissor => Result.Lose,
                Move.Paper when me == Move.Scissor => Result.Win,
                Move.Scissor when me == Move.Rock => Result.Win,
                Move.Rock when me == Move.Paper => Result.Win,
                _ => Result.Draw
            };
        }

        private enum Move
        {
            Rock = 0,
            Paper = 1,
            Scissor = 2
        }

        private enum Result
        {
            Lose = 0,
            Draw = 1,
            Win = 2
        }
    }
}
