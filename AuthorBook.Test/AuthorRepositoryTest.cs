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
        [Fact]
        public async void getAll_HTTPRespone200_whenDataExists()
        {
            // Arrange - Opsætning => varriable init
            // objcontroller and mok data.
            var dataSource = new Mock<IAuthorRepository>();
            List<Aurthor> authorList = new List<Aurthor>();
            authorList.Add(new Aurthor());
            authorList.Add(new Aurthor());
             dataSource.Setup(s => s.getAuthors()).ReturnsAsync(authorList);

            // Act - handling => prøve mit data af
            AurthorTestController classThatIsTested = new AurthorTestController(dataSource.Object);
            IActionResult result = await classThatIsTested.getAuthors();

            // Assert - verfocer p, kegjar gjort det godt nok.
            IStatusCodeActionResult statusCodeResult = (IStatusCodeActionResult)result;
            // CHange iactionresult in respository.
            Assert.Equal(200,statusCodeResult.StatusCode);


        }
        /*
        [Fact]
        public async Task getAll_shouldReturn200_whenDataExists()
        {
            // arrange
            // •    Instans with moq – new Mock<what I am trying to mock and it has to be abstract>(); 
            var dataSource = new Mock<IAuthorRepository>();
            List<Aurthor> authorList = new List<Aurthor>();
            authorList.Add(new Aurthor());
            authorList.Add(new Aurthor());

            dataSource
                .Setup(s => s.getAuthors())
                .ReturnsAsync(authorList);
            // act
            var classThatIsTested = new AurthorTestController(dataSource.Object);
            var result = await classThatIsTested.getAll();
            //assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task getAll_shouldReturn204_whenNoAuthors()
        {
            // arrange
            // •    Instans with moq – new Mock<what I am trying to mock and it has to be abstract>(); 
            var dataSource = new Mock<IAuthorRepository>();
            List<Aurthor> authorList = new List<Aurthor>();
            //authorList.Add(new Author());
            //authorList.Add(new Author());

            dataSource
                .Setup(s => s.getAllAuthorsAndBooks())
                .ReturnsAsync(authorList);
            // act
            var classThatIsTested = new AurthorTestController(dataSource.Object);
            var result = await classThatIsTested.getAll();
            //assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(204, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task getAll_shouldReturn500_whenAuthorDoesNotExists()
        {
            // arrange
            var dataSource = new Mock<IAuthorRepository>();
            List<Aurthor> authorList = null;
            //authorList.Add(new Author());
            //authorList.Add(new Author());

            dataSource
                .Setup(s => s.getAllAuthorsAndBooks())
                .ReturnsAsync(authorList);
            // act
            var classThatIsTested = new AurthorTestController(dataSource.Object);
            var result = await classThatIsTested.getAll();
            //assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }
        */
    }
}
