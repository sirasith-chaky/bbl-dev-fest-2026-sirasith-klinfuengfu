using System.Collections.Concurrent;
using bbl_dev_fest_2026_sirasith_klinfuengfu.IServices;
using bbl_dev_fest_2026_sirasith_klinfuengfu.Models;

namespace bbl_dev_fest_2026_sirasith_klinfuengfu.Services
{
    public class UserService : IUserService
    {
        private readonly ConcurrentDictionary<long, User> _users = new();
        private long _lastId;

        public UserService()
        {
            var seed = new List<User>
            {
                new() { id = 1, name = "Leanne Graham",   username = "Bret",      email = "Sincere@april.biz",   phone = "1-770-736-8031 x56442", website = "hildegard.org" },
                new() { id = 2, name = "Ervin Howell",    username = "Antonette", email = "Shanna@melissa.tv",   phone = "010-692-6593 x09125",  website = "anastasia.net" },
                new() { id = 3, name = "Clementine Bauch", username = "Samantha", email = "Nathan@yesenia.net",  phone = "1-463-123-4447 x80814", website = "ramona.com" },
            };

            foreach (var user in seed)
            {
                _users[user.id] = user;
            }

            _lastId = _users.IsEmpty ? 0 : _users.Keys.Max();
        }

        public IEnumerable<User> GetAll() =>
            _users.Values.OrderBy(u => u.id).ToList();

        public User? GetById(long id) =>
            _users.TryGetValue(id, out var user) ? user : null;

        public User Create(UserRequest request)
        {
            var user = new User
            {
                id = Interlocked.Increment(ref _lastId),
                name = request.name,
                username = request.username,
                email = request.email,
                phone = request.phone,
                website = request.website,
            };

            _users[user.id] = user;
            return user;
        }

        public User? Update(long id, UserRequest request)
        {
            if (!_users.TryGetValue(id, out var existing))
            {
                return null;
            }

            existing.name = request.name;
            existing.username = request.username;
            existing.email = request.email;
            existing.phone = request.phone;
            existing.website = request.website;

            return existing;
        }

        public bool Delete(long id) =>
            _users.TryRemove(id, out _);
    }
}
