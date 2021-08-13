using AuthorBook.Controllers;
using AuthorBook.Domain;
using AuthorBook.Repository;
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
    // Methods Get authors


    public class AuthorRepositoryTest
    {
        Mock<IAuthorRepository> dataSource = new Mock<IAuthorRepository>();
        AurthorTestController classThatIsTested;

        public AuthorRepositoryTest()
        {
            classThatIsTested = new AurthorTestController(dataSource.Object);
        }
        [Fact]
        public async void getAll_HTTPRespone200_whenDataExists()
        {
            // Arrange - Opsætning => varriable init
            // objcontroller and mok data.
            //Mock<IAuthorRepository> dataSource = new Mock<IAuthorRepository>();
            List<Aurthor> authorList = new List<Aurthor>();
            authorList.Add(new Aurthor());
            authorList.Add(new Aurthor());
            dataSource.Setup(s => s.getAuthors()).ReturnsAsync(authorList);

            // Act - handling => prøve mit data af
            //AurthorTestController classThatIsTested = new AurthorTestController(dataSource.Object);

            IActionResult result = await classThatIsTested.getAuthors();

            // Assert - verfocer p, kegjar gjort det godt nok.
            IStatusCodeActionResult statusCodeResult = (IStatusCodeActionResult)result;
            // CHange iactionresult in respository.
            Assert.Equal(200, statusCodeResult.StatusCode);


        }

        [Fact]
        public async Task getAll_shouldReturn200_whenDataExists()
        {
            // arrange
            // •    Instans with moq – new Mock<what I am trying to mock and it has to be abstract>(); 
            //var dataSource = new Mock<IAuthorRepository>();
            List<Aurthor> authorList = new List<Aurthor>();
            authorList.Add(new Aurthor());
            authorList.Add(new Aurthor());

            dataSource
                .Setup(s => s.getAuthors())
                .ReturnsAsync(authorList);
            // act
            //var classThatIsTested = new AurthorTestController(dataSource.Object);
            var result = await classThatIsTested.getAuthors();
            //assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task getAll_shouldReturn204_whenNoAuthors()
        {
            // arrange
            // •    Instans with moq – new Mock<what I am trying to mock and it has to be abstract>(); 
            //var dataSource = new Mock<IAuthorRepository>();
            List<Aurthor> authorList = new List<Aurthor>();
            dataSource
                .Setup(s => s.getAuthors())
                .ReturnsAsync(authorList);
            // act
            // AurthorTestController classThatIsTested = new AurthorTestController(dataSource.Object);
            var result = await classThatIsTested.getAuthors();
            //assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(204, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task getAll_shouldReturn404_whenAuthorDoesNotExists()
        {
            // arrange
           // var dataSource = new Mock<IAuthorRepository>();
            List<Aurthor> authorList = null;
            dataSource
                .Setup(s => s.getAuthors())
                .ReturnsAsync(authorList);
            // act
           // var classThatIsTested = new AurthorTestController(dataSource.Object);
            var result = await classThatIsTested.getAuthors();
            //assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(404, statusCodeResult.StatusCode);
        }
        [Fact]

        public async Task create_shouldReturn201_whenCreated()
        {
            Aurthor authorTest = new Aurthor();
            authorTest.id = 20;
            authorTest.firstname = "Manish";
            authorTest.lastname = "Shrestha";
            authorTest.createdAt = DateTime.UtcNow;
            dataSource.Setup(s => s.create(authorTest)).ReturnsAsync(authorTest);

            // Act - handling => prøve mit data af
            //AurthorTestController classThatIsTested = new AurthorTestController(dataSource.Object);

            var result = await classThatIsTested.PostAurthor(authorTest);

            // Assert - verfocer p, kegjar gjort det godt nok.
            var statusCodeResult = (IStatusCodeActionResult)result;
            // CHange iactionresult in respository.
            Assert.Equal(201, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task create_shouldReturn400_badRequest()
        {
            Aurthor authorTest = new Aurthor();
            authorTest.id = 20;
            authorTest.firstname = "Manish";
            authorTest.lastname = "Shrestha";
            authorTest.createdAt = DateTime.UtcNow;

            dataSource.Setup(s => s.create(authorTest)).ReturnsAsync(authorTest);

            // Act - handling => prøve mit data af
            //AurthorTestController classThatIsTested = new AurthorTestController(dataSource.Object);

            var result = await classThatIsTested.PostAurthor(null);

            // Assert - verfocer p, kegjar gjort det godt nok.
            var statusCodeResult = (IStatusCodeActionResult)result;
            // CHange iactionresult in respository.
            Assert.Equal(400, statusCodeResult.StatusCode);
        }

    }
}
