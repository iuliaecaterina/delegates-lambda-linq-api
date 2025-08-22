namespace WebApplication1.Services.Lambda
{
    public class LambdaService : ILambdaService
    {
        public Tuple<int, int, int> SplitNumber(int value)
        {
            var lambdaExp = (int num) => new Tuple<int, int, int>(num % 10, (num /= 10) % 10, (num /= 10) % 10);
            return lambdaExp(value);
        }

        public bool TryParseNumber(string value)
        {
            return int.TryParse(value, out _);
        }

        public async Task<string> ToLowerCaseDelayed(string value)
        {
            var lambdaExp = async (string v) =>
            {
                await Delay();
                return value.ToLower();
            };

            return await lambdaExp(value);
        }

        public Task Delay() => Task.Delay(1000);

        // Lambda fără parametru (expression)
        public string NoParamLambda()
        {
            Func<string> noParam = () => "Lambda fără parametri";
            return noParam();
        }

        // Lambda cu un parametru (expression)
        public string OneParamLambda(string name)
        {
            Func<string, string> oneParam = n => $"Salut, {n}!";
            return oneParam(name);
        }

        // Lambda cu parametru neutilizat
        public string UnusedParam(string action, string name, string ignored)
        {
            Func<string, string, string, string> unusedLambda = (a, b, _) =>
            {
                return $"{a}, {b}";
            };

            return unusedLambda(action, name, ignored);
        }

        // Lambda cu parametru cu valoare default
        public List<int> DefaultParam(List<int> numbers, bool desc = false)
        {
            Func<List<int>, bool, List<int>> sortLambda = (list, descending) =>
            {
                if (descending)
                {
                    list.Sort();
                    list.Reverse();
                }
                else
                {
                    list.Sort();
                }

                return list;
            };

            return sortLambda(numbers, desc);
        }

        // Lambda cu tuple ca parametru
        public string TupleLambda((int a, int b) pair)
        {
            Func<(int, int), string> tupleLambda = t =>
            {
                int product = t.Item1 * t.Item2;
                return $"Produsul dintre {t.Item1} și {t.Item2} este {product}";
            };

            return tupleLambda(pair);
        }

        // Lambda fără parametru - statement block
        public string NoParamLambdaBlock()
        {
            Func<string> noParam = () =>
            {
                string message = "Lambda fără parametri (statement block)";
                return message;
            };

            return noParam();
        }

        // Lambda cu un parametru - statement block
        public string OneParamLambdaBlock(string name)
        {
            Func<string, string> oneParam = (n) =>
            {
                var greeting = $"Salut din statement block, {n}!";
                return greeting;
            };

            return oneParam(name);
        }

        // Lambda async - statement block
        public async Task<string> AsyncLambdaBlock(string value)
        {
            Func<string, Task<string>> lambda = async (v) =>
            {
                await Delay();
                var result = v.ToUpper();
                return $"Upper async: {result}";
            };

            return await lambda(value);
        }

        // Lambda cu doi parametri
        public string TwoParams(int a, int b)
        {
            Func<int, int, string> sumLambda = (x, y) =>
            {
                int sum = x + y;
                return $"Suma este: {sum}";
            };

            return sumLambda(a, b);
        }
    }
}
