using AutoMapper;
using Helpdesk.Business.DTOs;
using Helpdesk.Business.Interfaces;
using Helpdesk.Domain.Entities;
using Helpdesk.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpdesk.Business.Services
{
    public class AuthService : IAuthService
    {
        private readonly IJwtManager _jwtManager;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IGenericRepository<User> _genericRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public AuthService(IJwtManager jwtManager, IPasswordHasher passwordHasher, IGenericRepository<User> genericRepository, IMapper mapper, IUserRepository userRepository)
        {
            _jwtManager = jwtManager;
            _passwordHasher = passwordHasher;
            _genericRepository = genericRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }
        public async Task CreateUserAsync(CreateUserDTO createUserDTO)
        {
            var userExists = await _genericRepository.GetAllAsync(u => u.Email == createUserDTO.Email)
                ?? throw new Exception("Error al verificar la existencia del usuario.");

            var user = _mapper.Map<User>(createUserDTO);

            user.CreatedAt = DateTime.UtcNow;
            user.Password = _passwordHasher.HashPassword(createUserDTO.Password);
            user.Active = true;

            await _genericRepository.InsertAsync(user);
            await _genericRepository.SaveAsync();
        }

        public async Task<(UserDTO user, TokenResponseDTO token)> Login(LoginDTO loginDTO)
        {
            var user = await _userRepository.getUserByEmail(loginDTO.Email)
                ?? throw new Exception("Usuario no encontrado.");

            var isPasswordValid = _passwordHasher.VerifyPassword(loginDTO.Password, user.Password);

            if (!isPasswordValid)
            {
                throw new Exception("Credenciales inválidas.");
            }

            var token = _jwtManager.GenerateToken(user.Email, user.IdRol);
            var userDTO = _mapper.Map<UserDTO>(user);
            return (userDTO, token);
        }
    }
}

