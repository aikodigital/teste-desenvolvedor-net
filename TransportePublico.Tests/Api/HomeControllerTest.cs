// using TransportePublico.API.Controllers;
// using TransportePublico.Infra.Contexts;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;

// namespace TransportePublico.Tests.Controllers
// {
//     public class HomeControllerTests
//     {
//         [Fact]
//         public void Home_DeveRetornarOkQuandoBancoDeDadosCriadoComSucesso()
//         {
//             // Arrange
//             var options = new DbContextOptionsBuilder<ApplicationDbContext>()
//                 .UseInMemoryDatabase(databaseName: "TestDatabase")
//                 .Options;

//             using (var context = new ApplicationDbContext(options))
//             {
//                 // Act
//                 var controller = new HomeController(context);
//                 var result = controller.Home() as OkObjectResult;

//                 // Assert
//                 Assert.NotNull(result);
//                 Assert.Equal("TransportePublico.API", result.Value.GetType().GetProperty("App").GetValue(result.Value));
//                 Assert.Equal("Iniciada com sucesso", result.Value.GetType().GetProperty("Status").GetValue(result.Value));
//                 Assert.Equal("OK", result.Value.GetType().GetProperty("Database").GetValue(result.Value));
//             }
//         }

//         [Fact]
//         public void Home_DeveRetornarBadRequestQuandoConexaoFalha()
//         {
//             // Arrange
//             var options = new DbContextOptionsBuilder<ApplicationDbContext>()
//                 .UseInMemoryDatabase(databaseName: "TestDatabase")
//                 .Options;

//             using (var context = new ApplicationDbContext(options))
//             {
//                 context.Database.EnsureCreated();
//             }

//             var contextMock = new Mock<ApplicationDbContext>(options);
//             contextMock.Setup(x => x.Set<object>()).Throws(new Exception("Erro de conexão"));

//             var controller = new HomeController(contextMock.Object);

//             // Act
//             var result = controller.Home() as BadRequestObjectResult;

//             // Assert
//             Console.WriteLine(result);
//         }
//     }
// }
