using static Database;

public class Orm : IDisposable
{
    private Database database;

    public Orm(Database database) => this.database = database;

    public void Begin() => database.BeginTransaction();

    public void Write(string data)
    {
        if (database.DbState != State.TransactionStarted)
            return;
        
        database.Write(data);
        
        if (data == "bad write")
            database.UpdateState(State.Closed);
    }

    public void Commit() => database.EndTransaction();

    public void Dispose() => database.Dispose();
}
