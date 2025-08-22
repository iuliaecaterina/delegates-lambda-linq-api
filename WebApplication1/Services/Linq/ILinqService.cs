namespace WebApplication1.Services.Linq
{
    public interface ILinqService
    {
        int CountStudentsOver_Method(int value);
        int CountStudentsOver_Query(int value);

        List<Student> FilterByGroup(string groupName);        
        List<string> SelectEmails();
        List<Student> FilterByNota(double minNota);
        List<string> JoinWithGroups();
    }
}
