using Domain.Models;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService
    {
        UserRepository userRepository;

        public UserService()
        {
            userRepository = new UserRepository();
        }
        public User AddUpdateUser(User user)
        {
            try
            {
                #region Regra de Negócio

                bool addFlag = false;
                if (user.UsrId == 0)
                {
                    addFlag = true;
                }
                #endregion

                #region Add or Update Movie

                return addFlag ? userRepository.Add(user) : userRepository.Update(user);

                #endregion

            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Erro: {ex.Message}");
                return null;
            }


        }
        public User ObterPorId(int id)
        {
            try
            {
                return userRepository.GetById(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Erro: {ex.Message}");
                return null;
            }
        }
        public bool ExcluirUser(int id)
        {
            try
            {
                return userRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Erro: {ex.Message}");
                return false;
            }

        }

        public IEnumerable<User> ListarTodosUser()
        {
            return userRepository.GetAll();
        }
    }
}
