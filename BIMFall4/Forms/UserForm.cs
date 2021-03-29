using BIMFall4.Forms.UserValidations;
using BIMFall4.Manager;
using BIMFall4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIMFall4.Forms
{
    public class UserForm : IForm
    {
        User user;
        UserValidator validator;
        string _errorMessage = "";
        public string ErrorMessage { get { return _errorMessage; } }

        public UserForm(User user)
        {
            this.user = user;
            this.validator = new UserValidator();
            validator.AddHandler(new EmailValidation());
            validator.AddHandler(new PasswordValidation());
        }

        public bool isValid()
        {
            try
            {
                validator.StartValidation(this.user);
            }
            catch (Exception e)
            {
                _errorMessage = e.Message;
                return false;
            }
            return true;
        }
    }
}