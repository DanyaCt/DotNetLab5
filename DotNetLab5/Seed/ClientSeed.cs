using DotNetLab5.Entities;

namespace DotNetLab5.Seed
{
    internal class ClientSeed
    {
        public static IList<Client> GetSeed()
        {
            return new[]
            {
                new Client()
                {
                    Id = Guid.NewGuid(),
                    Firstname = "Daniil",
                    Lastname = "Semeniuk",
                    Balance = 250m,
                    PhoneNumber = "+380501232312",
                    PinCode = 1122,
                },
                new Client()
                {
                    Id = Guid.NewGuid(),
                    Firstname = "Yehor",
                    Lastname = "Kalchenko",
                    Balance = 10000m,
                    PhoneNumber = "+380504904388",
                    PinCode = 3010,
                },
                new Client()
                {
                    Id = Guid.NewGuid(),
                    Firstname = "Artem",
                    Lastname = "Stankov",
                    Balance = 51m,
                    PhoneNumber = "+380962304567",
                    PinCode = 1488,
                },
            };
        }
    }
}
