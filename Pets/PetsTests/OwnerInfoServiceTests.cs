using Moq;
using Pets.Dtos;
using Pets.Entities;
using Pets.Repositories;
using Pets.Services;

namespace PetsTests
{
    public class OwnerInfoServiceTests
    {
        private OwnerInfoService _service;
        private Mock<IOwnerInfoRepository> _mockRepository;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IOwnerInfoRepository>();
            _service = new OwnerInfoService(_mockRepository.Object);
        }

        [Test]
        public void GetOwnerById_NullOwner_ShouldReturnNull()
        {
            // Arrange
            var id = 1;
            _mockRepository.Setup(m => m.GetOwnerById(id, true));

            // Act
            var result = _service.GetOwnerById(id);

            // Assert
            Assert.Null(result);
        }

        [Test]
        public void GetOwnerById_HasOwner_ShouldReturnOwnerDto()
        {
            // Arrange
            var id = 1;

            var fakeOwner = new Owner { Id = id };
            _mockRepository
                .Setup(m => m.GetOwnerById(id, true))
                .Returns(fakeOwner);

            // Act
            var result = _service.GetOwnerById(id);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.IsInstanceOf<OwnerDto>(result);
            Assert.That(id, Is.EqualTo(result.Id));
        }

        [Test]
        public void AddPetToOwner_NullOwner_ShouldReturnNull()
        {
            // Arrange
            var id = 1;
            var fakeDto = new PetCreationDto
            {
                BirthDate = DateTime.UtcNow,
                Name = "FakeName"
            };

            _mockRepository.Setup(m => m.AddPetToOwner(id, It.IsAny<string>(), It.IsAny<DateTime>()));

            // Act
            var result = _service.AddPetToOwner(id, fakeDto);

            // Assert
            Assert.Null(result);
        }

        [Test]
        public void AddPetToOwner_ValidOwner_ShouldReturnPet()
        {
            // Arrange
            var id = 1;
            var fakeDto = new PetCreationDto
            {
                BirthDate = DateTime.UtcNow,
                Name = "FakeName"
            };
            var fakePet = new Pet
            {
                Id = 2,
                Name = fakeDto.Name,
                Birthdate = fakeDto.BirthDate,
                OwnerId = id
            };

            _mockRepository
                .Setup(m => m.AddPetToOwner(id, It.IsAny<string>(), It.IsAny<DateTime>()))
                .Returns(fakePet);

            // Act
            var result = _service.AddPetToOwner(id, fakeDto);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<PetDto>());
            Assert.That(result.Id, Is.EqualTo(fakePet.Id));
            Assert.That(result.Name, Is.EqualTo(fakePet.Name));
            Assert.That(result.BirthDate, Is.EqualTo(fakePet.Birthdate));
        }

        [Test]
        public void GetOwnerWithPets_NullOwner_ShouldReturnNull()
        {
            // Arrange
            var id = 1;
            _mockRepository.Setup(m => m.GetOwnerById(id, true));

            // Act
            var result = _service.GetOwnerWithPets(id);

            // Assert
            Assert.Null(result);
        }

        [Test]
        public void GetOwnerWithPets_HasPets_ShouldOwnerWithPetsDto()
        {
            // Arrange
            var id = 1;
            var fakeOwner = new Owner 
            { 
                Id = id,
                Name = "Test",
                Pets = [
                        new Pet { Id = 2, Name = "Pet1" , OwnerId  = 1},
                        new Pet { Id = 3, Name = "Pet3" , OwnerId  = 3}, // WRONG DATA -> Should not be included
                    ]
            
            };

            _mockRepository.Setup(m => m.GetOwnerById(id, true)).Returns(fakeOwner);

            // Act
            var result = _service.GetOwnerWithPets(id);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<OwnerWithPetsDto>());
            Assert.That(result.Id, Is.EqualTo(fakeOwner.Id));
            Assert.That(result.Name, Is.EqualTo(fakeOwner.Name));
            Assert.That(result.Pets, Is.Not.Empty);
            Assert.That(result.Pets.Count, Is.EqualTo(1));
        }
    }
}