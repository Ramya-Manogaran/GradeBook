namespace GradeBook.Tests;
public delegate string WriteLogDelegate(string logMessage);


public class TypeTests
{
    int count = 0;
    [Fact]
    public void WriteLogDelegateCanPointToMethod(){
        //WriteLogDelegate log;
        WriteLogDelegate log = ReturnMessage;
        log += ReturnMessage;
        log += IncrementCount;

        var result = log("Hello!");
        Assert.Equal(result, "Hello!");
        Assert.Equal(3, count);
    }

    string ReturnMessage(string message)
    {
        count++;
        return message;
    }

    string  IncrementCount(string message)
    {
        count++;
        return message;
    }

    [Fact]
    public void GetBookReturnsDifferentObjects()
    {
        var book1 = GetBook("Book 1");
        var book2 = GetBook("Book 2");

        Assert.Equal("Book 1", book1.Name);
        Assert.Equal("Book 2", book2.Name);

        Assert.NotSame(book1, book2);

    }

    [Fact]
    public void TwoVariablesCanreferenceSameObjects()
    {
        var book1 = GetBook("Book 1");
        var book2 = book1;//book1 holds reference that points to Book 1

        Assert.Same(book1, book2);
        Assert.True(Object.ReferenceEquals(book1, book2));

    }

    [Fact]
    public void CanSetNameFromReference()
    {
        var book1 = GetBook("Book 1");
        SetName(book1, "New Name");
        
        Assert.Equal("New Name", book1.Name);
    }

    private void SetName(InMemoryBook book, string name){
        book.Name = name;
    }

    [Fact]
    public void CsharpIsPassByValue()
    {
        var book1 = GetBook("Book 1");
        GetBookSetName(book1, "New Name");
        
        Assert.Equal("Book 1", book1.Name);
    }

    private InMemoryBook GetBook(string name)
    {
        return new InMemoryBook(name);
    }
    private void GetBookSetName(InMemoryBook book, string name){
        book = new InMemoryBook(name);
    }

    [Fact]
    public void CsharpCanPassByRef()
    {
        var book1 = GetBook("Book 1");
        GetBookSetName(ref book1, "New Name");
        
        Assert.Equal("New Name", book1.Name);
    }

    private void GetBookSetName(ref InMemoryBook book, string name){
        book = new InMemoryBook(name);
    }

     [Fact]
    public void CsharpCanPassByRefWithOutParam()
    {
        var book1 = GetBook("Book 1");
        GetBookSetNamePutParam(out book1, "New Name");
        
        Assert.Equal("New Name", book1.Name);
    }

    private void GetBookSetNamePutParam(out InMemoryBook book, string name){
        book = new InMemoryBook(name);
        //out parameters must be initialized before the control leaves this method
    }

    [Fact]
    public void test1(){
        var x = GetInt();
        SetInt(ref x);
        Assert.Equal(42, x);
    }

    private void SetInt(ref int x)
    {
        x = 42;
    }

    private int GetInt()
    {
        return 3;
    }

    [Fact]
    public void StringBehavesLikeValueType(){
        string name = "Ramya";
        var upper = MakeUpperCase(name);

        Assert.Equal("Ramya", name);
        Assert.Equal("RAMYA", upper);
    }

    private string MakeUpperCase(string parameter)
    {
        return parameter.ToUpper();
    }
}