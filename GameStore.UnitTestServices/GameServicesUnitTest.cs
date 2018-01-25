using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using GameStore.DataAccess.Repositories;
using GameStore.DataAccess.EntityModels;
using GameStore.Services.Services.Implementation;
using GameStore.Domains.Domain;
using System.Linq;

namespace GameStore.UnitTestServices
{
    [TestClass]
    public class GameServicesUnitTest
    {
        [TestMethod]
        public void GetAllNotNullEqualsTypesEqualsId()
        {
            Guid[] idGames = { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() };
            var mockGameRepository = new Mock<IRepository<Game>>();
            mockGameRepository.Setup(x => x.GetAll())
                .Returns(new List<Game>()
                {
                    new Game() { Id = idGames[0] },
                    new Game() { Id = idGames[1] },
                    new Game() { Id = idGames[2] }
                });

            var mockProducerRepository = new Mock<IRepository<Producer>>();

            var service = new GameServices(mockGameRepository.Object, mockProducerRepository.Object);

            var result = service.GetAll();
            var resultItem = result.FirstOrDefault();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ICollection<GameModel>));
            Assert.IsInstanceOfType(resultItem, typeof(GameModel));
            Assert.IsTrue(idGames.SequenceEqual(result.Select(x => x.Id).ToArray()));
        }

        [TestMethod]
        public void GetGameInfoTransferAllNotNullEqualsTypesEqualsId()
        {
            Guid[] idGames = { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() };
            var mockGameRepository = new Mock<IRepository<Game>>();
            mockGameRepository.Setup(x => x.GetAll())
                .Returns(new List<Game>()
                {
                    new Game() { Id = idGames[0] },
                    new Game() { Id = idGames[1] },
                    new Game() { Id = idGames[2] }
                });

            var mockProducerRepository = new Mock<IRepository<Producer>>();

            var service = new GameServices(mockGameRepository.Object, mockProducerRepository.Object);

            var result = service.GetGameInfoTransferAll();
            var resultItem = result.FirstOrDefault();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ICollection<GameInfoTransferModel>));
            Assert.IsInstanceOfType(resultItem, typeof(GameInfoTransferModel));
            Assert.IsTrue(idGames.SequenceEqual(result.Select(x => x.Id).ToArray()));
        }

        [TestMethod]
        public void GetItemByIdNotNullEqualsTypesEqualsId()
        {
            var id = Guid.NewGuid();            
            var mockGameRepository = new Mock<IRepository<Game>>();
            mockGameRepository.Setup(x => x.GetItemById(id)).Returns(new Game() { Id = id });

            var mockProducerRepository = new Mock<IRepository<Producer>>();

            var service = new GameServices(mockGameRepository.Object, mockProducerRepository.Object);

            var result = service.GetItemById(id);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(GameModel));
            Assert.AreEqual(id, result.Id);
        }

        [TestMethod]
        public void GetTopRatedGamesNotNullEqualsTypesEqualsNames()
        {
            string[] idGames = { "game1", "game2", "game3" };
            var mockGameRepository = new Mock<IRepository<Game>>();
            mockGameRepository.Setup(x => x.GetAll())
                .Returns(new List<Game>()
                {
                    new Game() { Name = idGames[0] },
                    new Game() { Name = idGames[1] },
                    new Game() { Name = idGames[2] }
                });

            var mockProducerRepository = new Mock<IRepository<Producer>>();

            var service = new GameServices(mockGameRepository.Object, mockProducerRepository.Object);
            var parameter = 3;

            var result = service.GetTopRatedGames(parameter);
            var resultItem = result.FirstOrDefault();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ICollection<GameRateTransferModel>));
            Assert.IsInstanceOfType(resultItem, typeof(GameRateTransferModel));
            Assert.IsTrue(idGames.Take(parameter).SequenceEqual(result.Select(x => x.Name)));
        }

        [TestMethod]
        public void AddWithOneParameterNotNullEqualsTypesEqualsId()
        {
            var mockProducerRepository = new Mock<IRepository<Producer>>();
            var mockGameRepository = new Mock<IRepository<Game>>();

            var id = Guid.NewGuid();
            mockGameRepository.Setup(x => x.Add(It.IsAny<Game>())).Returns(id);

            var service = new GameServices(mockGameRepository.Object, mockProducerRepository.Object);

            var actualId = service.Add(new GameModel()
            {
                Id = id,
                Producers = new List<ProducerModel>() 
            });

            Assert.IsNotNull(actualId);
            Assert.IsInstanceOfType(id, typeof(Guid));
            Assert.AreEqual(id, actualId);
        }

        [TestMethod]
        public void AddTwoParameterNotNullEqualsTypesEqualsId()
        {
            var mockProducerRepository = new Mock<IRepository<Producer>>();
            var mockGameRepository = new Mock<IRepository<Game>>();

            var id = Guid.NewGuid();
            mockGameRepository.Setup(x => x.Add(It.IsAny<Game>())).Returns(id);

            var service = new GameServices(mockGameRepository.Object, mockProducerRepository.Object);


            var actualId = service.Add(new GameCreationTransferModel()
            {
                Id = id,
                Producers = new List<Guid>()
            }, "pathOfFile");

            Assert.IsNotNull(actualId);
            Assert.IsInstanceOfType(id, typeof(Guid));
            Assert.AreEqual(id, actualId);
        }

        [TestMethod]
        public void UpdateNotNullEqualsTypesEqualsId()
        {
            var mockProducerRepository = new Mock<IRepository<Producer>>();
            var mockGameRepository = new Mock<IRepository<Game>>();

            var id = Guid.NewGuid();
            mockGameRepository.Setup(x => x.Update(It.IsAny<Game>())).Returns(id);

            var service = new GameServices(mockGameRepository.Object, mockProducerRepository.Object);

            var actualId = service.Update(new GameModel()
            {
                Id = id,
                Producers = new List<ProducerModel>()
            });

            Assert.IsNotNull(actualId);
            Assert.AreEqual(id, actualId);
            Assert.IsInstanceOfType(id, typeof(Guid));
        }

        [TestMethod]
        public void RemoveNotNullEqualsTypesEqualsId()
        {
            var mockProducerRepository = new Mock<IRepository<Producer>>();
            var mockGameRepository = new Mock<IRepository<Game>>();

            var id = Guid.NewGuid();
            mockGameRepository.Setup(x => x.Update(It.IsAny<Game>())).Returns(id);

            var service = new GameServices(mockGameRepository.Object, mockProducerRepository.Object);

            var actualId = service.Update(new GameModel()
            {
                Id = id,
                Producers = new List<ProducerModel>()
            });

            Assert.IsNotNull(actualId);
            Assert.AreEqual(id, actualId);
            Assert.IsInstanceOfType(id, typeof(Guid));
        }
    }
}
