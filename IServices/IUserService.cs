using bbl_dev_fest_2026_sirasith_klinfuengfu.Models;

namespace bbl_dev_fest_2026_sirasith_klinfuengfu.IServices
{
    /// <summary>
    /// Abstraction over user storage/retrieval so the controller depends on an
    /// interface rather than a concrete implementation.
    /// </summary>
    public interface IUserService
    {
        /// <summary>Returns every user.</summary>
        IEnumerable<User> GetAll();

        /// <summary>Returns the user with the given id, or <c>null</c> if none exists.</summary>
        User? GetById(long id);

        /// <summary>Creates a new user from the request and returns the stored entity (with generated id).</summary>
        User Create(UserRequest request);

        /// <summary>
        /// Updates the user with the given id. Returns the updated user,
        /// or <c>null</c> if no user with that id exists.
        /// </summary>
        User? Update(long id, UserRequest request);

        /// <summary>Deletes the user with the given id. Returns <c>true</c> if a user was removed.</summary>
        bool Delete(long id);
    }
}
