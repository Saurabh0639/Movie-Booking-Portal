using AutoMapper;
using MovieBooking.Models;
using MovieBooking.Repository;

namespace MovieBooking.Service
{
    public class UserService : IUserService
    {
        private IMapper _mapper;

        private IUserRepository _userRepository;
        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<User> CreateUser(User user)
        {
            var serviceUser = _mapper.Map<User>(user);
            return await _userRepository.CreateUser(serviceUser);
        }

        public void DeleteUser(int id)
        {
            _mapper.Map<User>(id);  
            _userRepository.DeleteUser(id);
        }

        public async Task<User> GetUser(User user)
        {
            var getUserByUser = await _userRepository.GetUser(user);
            var serviceUser = _mapper.Map<User>(getUserByUser);
            return serviceUser;

        }

        public bool SaveChanges()
        {
            return _userRepository.SaveChanges();
        }
    }
}
