using BIMFall4.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIMFall4.Forms.UserValidations
{
    public class UserValidator
    {
        User user;
        List<IValidateHandler> validators = new List<IValidateHandler>();

        public void AddHandler(IValidateHandler val)
        {
            validators.Add(val);
        }

        public void LinkValidators()
        {
            for (int i = 0; i < validators.Count - 1; i++)
            {
                validators[i].SetNextValidator(validators[i + 1]);
            }
        }

        public void StartValidation(User user)
        {
            this.LinkValidators();

            if(validators.Any())
                validators[0].Validate(user);
        }

    }
}