using MacroControleFinanceiro.Resource.Resources;
using MacroControleFinanceiro.Resource.Validation;
using System;

namespace MacroControleFinanceiro.Domain.Models

{
    public class User
    {
        protected User() { }
        public User(string name, string email)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Email = email;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public void SetPassword(string password, string confirmPassword)
        {
            AssertionConcern.AssertArgumentNotNull(password, Errors.InvalidUserPassword);
            AssertionConcern.AssertArgumentNotNull(confirmPassword, Errors.InvalidUserPassword);
            AssertionConcern.AssertArgumentLength(password, 6, 20, Errors.InvalidUserPassword);
            AssertionConcern.AssertArgumentEquals(password, confirmPassword, Errors.PasswordDoesNotMatch);

            this.Password = PasswordAssertionConcern.Encrypt(password);
        }
        public string ResetPassword()
        {
            string password = Guid.NewGuid().ToString().Substring(0, 8);
            this.Password = PasswordAssertionConcern.Encrypt(password);

            return password;
        }
        public void ChangeName(string name)
        {
            this.Name = name;
        }
        public void Validate()
        {
            AssertionConcern.AssertArgumentLength(this.Name, 3, 60, Errors.InvalidUserName);
            EmailAssertionConcern.AssertIsValid(this.Email);
            PasswordAssertionConcern.AssertIsValid(this.Password);
        }
    }
}
