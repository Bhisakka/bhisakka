using Bhisakka.DataAccess;
using Bhisakka.Models;
using Bhisakka.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bhisakka.Services
{
    internal class AuthService
    {
        private readonly AuthRepository _authRepository;

        public AuthService()
        {
            _authRepository = new AuthRepository();
        }

        public User Authenticate(string username, string plainPassword)
        {
            return _authRepository.GetUserByCredentials(username, CryptoUtil.ComputeSha256Hash(plainPassword));
        }
    }
}
