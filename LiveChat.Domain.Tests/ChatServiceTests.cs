using LiveChat.Data;
using LiveChat.Domain.Chat.Concrete;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace LiveChat.Domain.Tests
{
    [TestFixture]
    public class ChatServiceTests
    {
        private ChatService chatService;
        private Mock<IDataUnitOfWork> dataUnitOfWorkMocked;

        [SetUp]
        public void Setup()
        {
            dataUnitOfWorkMocked = new Mock<IDataUnitOfWork>();

            chatService = new ChatService(dataUnitOfWorkMocked.Object);
        }

        [Test]
        public async Task AddMessage_Always_SaveChangesIsCalled()
        {
            //Arrange

            dataUnitOfWorkMocked.Setup(x => x.Rooms.GetAsync(It.IsAny<int>()))
                                .ReturnsAsync(new DomainModel.Room
                                {
                                    Id = It.IsAny<int>(),
                                    Name = It.IsAny<string>()
                                });
            //Act

            await chatService.AddMessage(It.IsAny<string>(),
                                            It.IsAny<int>(), 
                                            It.IsAny<string>());

            //Assert

            dataUnitOfWorkMocked.Verify(x => x.SaveChangeAsync(), Times.Once);
        }
    }
}
