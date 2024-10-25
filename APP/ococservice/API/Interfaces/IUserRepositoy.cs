using System;
using System.Collections.Generic;
using API.DTOs;
using API.Entities;


namespace API.Interfaces
{
    public interface IUserRepositoy
    {
        void Update(User user);
        void Add(User user);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<User>> GetUserAsync();
        /// <summary>
        /// Regresa una lista de usuarios, si isActive es true regresa solo activos y "Pendientes" de aprovacion, sino regresa todos.
        /// </summary>
        /// <param name="isActive"></param>
        /// <returns></returns>
        Task<IEnumerable<UserDTO>> GetUserActiveAsync(bool isActive);
        Task<UserDTO> GetUserDTOByIdAsync(int id);
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByUsernameAsync(string userName);
        Task<UserDTO> GetUserDTOByUsernameAsync(string userName);
    }
}