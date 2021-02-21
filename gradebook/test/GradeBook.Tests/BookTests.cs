using System;
using System.Collections.Generic;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact] // Fact is an attribute
        public void BookCalculatesAnAverageGrade()
        {
            // arrange
            var book = new InMemoryBook("");
            book.AddGrade(95.1);
            book.AddGrade(85.1);
            book.AddGrade(75.1);

            // act
            var result = book.GetStatistics();

            // assert
            Assert.Equal(85.1, result.Average, 1);
            Assert.Equal(75.1, result.Low, 1);
            Assert.Equal(95.1, result.High, 1);
            Assert.Equal('B', result.Letter);
        }
    }
}
