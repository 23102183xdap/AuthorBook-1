using AuthorBook.Controllers;
using AuthorBook.Repository;
using AuthorBook.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AuthorBook.Test
{
    public class BookRespositoryTest
    {
        Mock<IBookRepository> dataSource = new Mock<IBookRepository>();
        BookTestController classThatIsTested;

        public BookRespositoryTest()
        {
            classThatIsTested = new BookTestController(dataSource.Object);
        }
        [Fact]
        public async void getAll_HTTPRespone200_whenDataExists()
        {
            // Arrange - Opsætning => varriable init
            // objcontroller and mok data.
            // Mock<IBookRepository> dataSource = new Mock<IBookRepository>();

            List<Book> bookList = new List<Book>();
            bookList.Add(new Book());
            bookList.Add(new Book());
            dataSource.Setup(s => s.getBooks()).ReturnsAsync(bookList);

            // Act - handling => prøve mit data af
            //BookRespositoryTest classThatIsTested = new BookRespositoryTest(dataSource.Object);

            IActionResult result = await classThatIsTested.getBooks();

            // Assert - gjort det godt nok.
            IStatusCodeActionResult statusCodeResult = (IStatusCodeActionResult)result;
            // CHange iactionresult in respository.
            Assert.Equal(200, statusCodeResult.StatusCode);


        }
        [Fact]
        public async Task getAll_shouldReturn204_whenNoBooks()
        {
            // arrange
            // •    Instans with moq – new Mock<what I am trying to mock and it has to be abstract>(); 
            // Mock<IBookRepository> dataSource = new Mock<IBookRepository>();

            List<Book> bookList = new List<Book>();
            dataSource.Setup(s => s.getBooks()).ReturnsAsync(bookList);

            // act
            //BookRespositoryTest classThatIsTested = new BookRespositoryTest(dataSource.Object);

            var result = await classThatIsTested.getBooks();
            //assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(204, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task getAll_shouldReturn404_whenBookDoesNotExists()
        {
            // arrange
            // Mock<IBookRepository> dataSource = new Mock<IBookRepository>();

            List<Book> bookList = null;
            dataSource.Setup(s => s.getBooks()).ReturnsAsync(bookList);
            // act
            //BookRespositoryTest classThatIsTested = new BookRespositoryTest(dataSource.Object);

            var result = await classThatIsTested.getBooks();
            //assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(404, statusCodeResult.StatusCode);
        }

        [Fact]

        public async Task create_shouldReturn201_whenCreated()
        {
            Book bookTest = new Book();
            bookTest.id = 20;
            bookTest.createdAt = DateTime.UtcNow;
            bookTest.page = 250;
            bookTest.title = "My Boook";
            bookTest.published = DateTime.UtcNow;

            dataSource.Setup(s => s.createBook(bookTest)).ReturnsAsync(bookTest);
            // Act - handling => prøve mit data af
            //BookRespositoryTest classThatIsTested = new BookRespositoryTest(dataSource.Object);


            var result = await classThatIsTested.postBook(bookTest);

            var statusCpdeResult = (IStatusCodeActionResult)result;
            Assert.Equal(201, statusCpdeResult.StatusCode);
        }

        [Fact]
        public async Task create_shouldReturn400_badRequest()
        {
            Book bookTest = new Book();
            bookTest.id = 20;
            bookTest.createdAt = DateTime.UtcNow;
            bookTest.page = 250;
            bookTest.title = "My Boook";
            bookTest.published = DateTime.UtcNow;
            dataSource.Setup(s => s.createBook(bookTest)).ReturnsAsync(bookTest);


            // Act - handling => prøve mit data af
            //BookRespositoryTest classThatIsTested = new BookRespositoryTest(dataSource.Object);


            var result = await classThatIsTested.postBook(null);

            // Assert -  gjort det godt nok.
            var statusCodeResult = (IStatusCodeActionResult)result;
            // CHange iactionresult in respository.
            Assert.Equal(400, statusCodeResult.StatusCode);
        }
    }
}
