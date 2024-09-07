using Pets.Entities;

namespace Pets.Repositories
{
    public class OwnerInfoRepository : IOwnerInfoRepository
    {
        private readonly DataStore _dataStore;
        private readonly OwnerInfoContext _ownerInfoContext;

        public OwnerInfoRepository(DataStore dataStore, OwnerInfoContext ownerInfoContext)
        {
            _dataStore = dataStore;
            _ownerInfoContext = ownerInfoContext;
        }
        public Owner? GetOwnerById(int ownerId, bool includePets = true)
        {

            var owner = _ownerInfoContext.Owners.SingleOrDefault(o => o.Id == ownerId);
            if (owner == null) return null;

            if (includePets)
            {
                owner.Pets = _ownerInfoContext.Pets
                    .Where(p => p.OwnerId == owner.Id)
                    .ToList();
            }

            return owner;
        }

        public List<Pet> GetAllPetsByOwnerId(int ownerId)
        {
            return _ownerInfoContext.Pets
                .Where(p => p.OwnerId == ownerId)
                .ToList();
        }

        public Pet? AddPetToOwner(int ownerId, string name, DateTime birthDate)
        {
            var owner = _ownerInfoContext.Owners.SingleOrDefault(o => o.Id == ownerId);
            if (owner == null) return null;

            var newPet = new Pet
            {
                Name = name,
                Birthdate = birthDate,
                OwnerId = ownerId,
            };

            _ownerInfoContext.Pets.Add(newPet);
            _ownerInfoContext.SaveChanges();

            return newPet;
        }
    }
}
