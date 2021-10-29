using api.Exceptions;
using api.Models;
using api.Repositories;
using System.Collections.Generic;

namespace api.Services
{
    public class UsersService
    {
        private readonly UsersRepository _usersRepository;

        public UsersService(UsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public IList<User> GetAll()
        {
            return _usersRepository.GetAll();
        }

        public User GetById(int id)
        {
            return _usersRepository.GetById(id);
        }

        public User GetByNickname(string nickname)
        {
            return _usersRepository.GetByNickname(nickname);
        }

        public void Create(User user)
        {
            if (_usersRepository.GetByNickname(user.Nickname) != null)
            {
                throw new UserAlreadyExistsException("User with this nickname already exists");
            }

            _usersRepository.Create(user);
        }

        public void Delete(User user) { 
            _usersRepository.Delete(user);
        }

        public bool ValidatePassword(User user, string password)
        {
            return user.Password == password;
        }

        public void SaveChanges()
        {
            _usersRepository.SaveChanges();
        }
    }
}
