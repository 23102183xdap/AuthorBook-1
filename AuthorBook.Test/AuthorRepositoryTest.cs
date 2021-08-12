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
        public async void getAll_etellerandet()
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
            ActionResult<IEnumerable<Aurthor>> result = await classThatIsTested.GetAuthors();

            // Assert - verfocer p, kegjar gjort det godt nok.
            var statusCodeResult = (IStatusCodeActionResult)result;
            // CHange iactionresult in respository.
            Assert.Equal(200,statusCodeResult.StatusCode);


        }
    }
}
