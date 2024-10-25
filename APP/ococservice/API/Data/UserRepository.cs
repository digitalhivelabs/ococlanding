using System;
using System.Collections.Generic;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;


namespace API.Data
{
    public class UserRepository : IUserRepositoy
    {
        private readonly DataContex _context;
        private readonly IMapper _mapper;

        public UserRepository(DataContex context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Add(User user)
        {
            _context.Entry(user).State = EntityState.Added;
        }

   

        public async Task<IEnumerable<User>> GetUserAsync()
        {
            return await _context.Users.OrderBy(u => u.UserName).ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> GetUserByUsernameAsync(string userName)
        {
            return await _context.Users.SingleOrDefaultAsync(x => x.UserName == userName.ToLower());
        }

        public async Task<UserDTO> GetUserDTOByIdAsync(int id)
        {
            return await _context.Users
                .Where(x => x.Id == id)
                .ProjectTo<UserDTO>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }

        public async Task<IEnumerable<UserDTO>> GetUserActiveAsync(bool isActive)
        {
            if(isActive){
                return await _context.Users
                    .Where(s => s.IsActive || s.Status == "Pending")
                    .ProjectTo<UserDTO>(_mapper.ConfigurationProvider)
                    .OrderBy(u => u.Status).ToListAsync();
            } else {
                return await _context.Users
                    .ProjectTo<UserDTO>(_mapper.ConfigurationProvider)
                    .OrderBy(u => u.Status).ToListAsync();
            } 
        }

        public async Task<UserDTO> GetUserDTOByUsernameAsync(string userName)
        {
            return await _context.Users
                .Where(x => x.UserName == userName.ToLower())
                .ProjectTo<UserDTO>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }
    }
}