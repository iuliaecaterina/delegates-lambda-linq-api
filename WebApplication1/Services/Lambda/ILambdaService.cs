namespace WebApplication1.Services.Lambda
{
    public interface ILambdaService
    {
        Tuple<int, int, int> SplitNumber(int value);
        bool TryParseNumber(string value);
        Task<string> ToLowerCaseDelayed(string value);
        Task<string> AsyncLambdaBlock(string value);

        string NoParamLambda();
        string NoParamLambdaBlock();

        string OneParamLambda(string name);
        string OneParamLambdaBlock(string name);

        string TwoParams(int a, int b);

        string UnusedParam(string action, string name, string ignored);

        List<int> DefaultParam(List<int> numbers, bool desc = false);

        string TupleLambda((int a, int b) pair);
    }
}
