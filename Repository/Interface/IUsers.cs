using AdminPannelApp.Utils.Enums;
using AdminPannelApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPannelApp.Repository.Interface
{
    public interface IUsers
    {
        SignInEnum SignIn(SignInModel model);
        SignUpEnum SignUp(SignUpModel model);
        ForgotPassEnum ForgotPassword(ForgotPassModel model);
        bool VerifyAccount(string otp);
    }
}