using RecipeApp.Data;
using RecipeApp.Models;
using System;
using System.Linq;
using System.Text;
using System.Web;

namespace RecipeApp.WebAPI.Persisters
{
    public class UserDataPersister : IDisposable
    {
        private const int Sha1CodeLength = 40;
        private const int SessionKeyLen = 50;
        private const int MinUsernameNicknameChars = 6;
        private const int MaxUsernameNicknameChars = 30;
        private const string SessionKeyChars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        private const string ValidUsernameChars = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM_1234567890";
        private RecipeAppContext entities;
        private static Random rand = new Random();
        
        public UserDataPersister(RecipeAppContext entities)
        {
            this.entities = entities;
        }

        private void ValidateSessionKey(string sessionKey)
        {
            if (sessionKey.Length != SessionKeyLen || sessionKey.Any(ch => !SessionKeyChars.Contains(ch)))
            {
                throw new HttpException("Invalid Password");
            }
        }

        private string GenerateSessionKey(int userId)
        {
            StringBuilder keyChars = new StringBuilder(50);
            keyChars.Append(userId.ToString());
            while (keyChars.Length < SessionKeyLen)
            {
                int randomCharNum;
                lock (rand)
                {
                    randomCharNum = rand.Next(SessionKeyChars.Length);
                }

                char randomKeyChar = SessionKeyChars[randomCharNum];
                keyChars.Append(randomKeyChar);
            }

            string sessionKey = keyChars.ToString();
            return sessionKey;
        }

        private void ValidateUsername(string username)
        {
            if (username == null || username.Length < MinUsernameNicknameChars || username.Length > MaxUsernameNicknameChars)
            {
                throw new HttpException(string.Format("Username should be between {0} and {1} symbols long", 
                    MinUsernameNicknameChars, MaxUsernameNicknameChars));
            }
            else if (username.Any(ch => !ValidUsernameChars.Contains(ch)))
            {
                throw new HttpException("Username contains invalid characters");
            }
        }

        private void ValidateAuthCode(string authCode)
        {
            if (authCode.Length != Sha1CodeLength)
            {
                throw new HttpException("Invalid user authentication");
            }
        }

        public User GetUser(int userId)
        {
            var user = entities.Users.FirstOrDefault(u => u.UserId == userId);
            if (user == null)
            {
                throw new HttpException("No such user.");
            }
            return user;
        }

        public void CreateUser(string username, string authCode)
        {
            ValidateUsername(username);
            ValidateAuthCode(authCode);
            var usernameToLower = username.ToLower();

            var dbUser = entities.Users
                .FirstOrDefault(u => u.Username == usernameToLower);

            if (dbUser != null && dbUser.Username.ToLower() == usernameToLower)
            {
                throw new HttpException("Username already exists");
            }
            else
            {
                dbUser = new User()
                {
                    Username = usernameToLower,
                    AuthCode = authCode
                };

                entities.Users.Add(dbUser);
                entities.SaveChanges();
            }
        }

        public string LoginUser(string username, string authCode)
        {
            ValidateUsername(username);
            ValidateAuthCode(authCode);
            var usernameToLower = username.ToLower();
            var user = entities.Users.FirstOrDefault(u => u.Username == usernameToLower 
                && u.AuthCode == authCode);

            if (user.SessionKey != null)
            {
                throw new HttpException("User is already logged in.");
            }

            if (user == null)
            {
                throw new HttpException("Invalid username or password");
            }

            var sessionKey = GenerateSessionKey((int)user.UserId);
            user.SessionKey = sessionKey;
            entities.SaveChanges();

            return sessionKey;
        }

        public User GetUser(string sessionKey)
        {
            ValidateSessionKey(sessionKey);
            var user = entities.Users.FirstOrDefault(u => u.SessionKey == sessionKey);
            if (user == null)
            {
                throw new HttpException("Invalid user authentication");
            }

            // entities.Entry(user).State = System.Data.EntityState.Detached;
            return user;
        }

        public void LogoutUser(string sessionKey)
        {
            ValidateSessionKey(sessionKey);
            var user = entities.Users.FirstOrDefault(u => u.SessionKey == sessionKey);
            if (user == null)
            {
                throw new HttpException("Invalid user authentication");
            }

            user.SessionKey = null;
            entities.SaveChanges();
        }


        public void Dispose()
        {
            entities.Dispose();
        }
    }
}