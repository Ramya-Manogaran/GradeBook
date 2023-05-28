namespace GradeBook.Tests;

public class BookTests
{
    [Fact]
    public void BookCalculatesAnAverageGrade()
    {
        //arrange
        var book = new InMemoryBook("");
        
        book.AddGrade(80.3);
        book.AddGrade(71.5);
        book.AddGrade(94);

        //act
        var result  = book.GetStatistics(); 

        //assert
        Assert.Equal(81.9, result.Average, 1);
        Assert.Equal(94, result.High, 1);
        Assert.Equal(71.5, result.Low, 1);
        Assert.Equal('B', result.Letter);


    }
}