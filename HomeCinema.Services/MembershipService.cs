using HomeCinema.Data;
using HomeCinema.Data.Infrastructure;
using HomeCinema.Domain;
using HomeCinema.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Services {
    public class MembershipService : IMembershipService {
        private readonly IRepository<User> m_userRepo;

        private readonly IRepository<Role> m_roleRepo;

        private readonly IRepository<UserRole> m_userRoleRepo;

        private readonly IEncryptionService m_encryptionService;

        private readonly IUnitOfWork m_unitOfWork;

        public MembershipService(
            IRepository<User> userRepo,
            IRepository<Role> roleRepo,
            IRepository<UserRole> userRoleRepo,
            IEncryptionService encryptionService,
            IUnitOfWork unitOfWork) {
            m_userRepo = userRepo;
            m_roleRepo = roleRepo;
            m_userRoleRepo = userRoleRepo;
            m_encryptionService = encryptionService;
            m_unitOfWork = unitOfWork;
        }

        public MembershipContext ValidateUser(string username, string password) {
            var ctx = new MembershipContext();

            var user = m_userRepo.GetUserByUsername(username);

            if (user != null && IsUserValid(user, password)) {
                ctx.User = user;

                var userRoles = GetUserRoles(user.Username);
                var identity = new GenericIdentity(user.Username);
                ctx.Principal = new GenericPrincipal(identity, userRoles.Select(x => x.Name).ToArray());
            }

            return ctx;
        }

        public User CreateUser(string username, string email, string password, int[] roleIds) {
            var existingUser = m_userRepo.GetUserByUsername(username);
            if (existingUser != null) {
                throw new Exception("Username is already in user.");
            }

            var salt = m_encryptionService.CreateSalt();

            var user = new User { 
                Username = username,
                Salt = salt,
                Email = email,
                IsLocked = false,
                Password = m_encryptionService.Encrypt(password, salt),
                DateCreated = DateTime.Now
            };

            m_userRepo.Add(user);
            m_unitOfWork.Commit();

            if (roleIds != null && roleIds.Length > 0) {
                foreach (var roleId in roleIds) {
                    AddUserToRole(user, roleId);
                }
            }

            m_unitOfWork.Commit();

            return user;
        }

        public User GetUser(int userId) {
            return m_userRepo.SingleById(userId);
        }

        public List<Role> GetUserRoles(string username) {
            var existingUser = m_userRepo.GetUserByUsername(username);
            if (existingUser == null) {
                return new List<Role>();
            }

            return existingUser.UserRoles.Select(u => u.Role).Distinct().ToList();
        }

        private void AddUserToRole(User user, int roleId) {
            var role = m_roleRepo.SingleById(roleId);
            if (role == null) {
                throw new ApplicationException("Role doesn't exist.");
            }

            var userRole = new UserRole {
                UserId = user.Id,
                RoleId = roleId
            };

            m_userRoleRepo.Add(userRole);
        }

        private bool CheckPasswrod(User user, string password) {
            return string.Equals(m_encryptionService.Encrypt(password, user.Salt), user.Password);
        }

        private bool IsUserValid(User user, string password) {
            return CheckPasswrod(user, password) && !user.IsLocked;
        }
    }
}
