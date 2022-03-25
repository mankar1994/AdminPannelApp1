using AdminPannelApp.Models;
using AdminPannelApp.Repository.Interface;
using AdminPannelApp.Utils.Enums;
using AdminPannelApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace AdminPannelApp.Repository.Services
{
    public class AccountService : IUsers
    {
        private AppDbContext dBContex;
        public AccountService()
        {
            dBContex = new AppDbContext();
        }
        public SignInEnum SignIn(SignInModel model)
        {
            var user = dBContex.Users.SingleOrDefault(e=>e.Email==model.Email && e.Password==model.Password);
            if (user != null)
            {
                if (user.IsVerified)
                {
                    if (user.IsActive)
                    {
                        return SignInEnum.Success;
                    }
                    else
                    {
                        return SignInEnum.InActive;
                    }
                }
                else
                {
                    return SignInEnum.NotVerified;
                }
            }
            else
            {
                return SignInEnum.WrongCredentials;
            }
        }

        public SignUpEnum SignUp(SignUpModel model)
        {
            if (dBContex.Users.Any(e => e.Email == model.Email))
            {
                return SignUpEnum.EmailExist;
            }
            else 
            {
                var user = new Users()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Password = model.ConfirmPassword,
                    Gender = model.Gender
                };
                dBContex.Users.Add(user);
                string Otp = GenerateOTP();
                SendMail(model.Email, Otp);
                var VAccount = new VerifyAccount()
                {
                    Otp = Otp,
                    UserId = model.Email,
                    SendTime = DateTime.Now
                };
                dBContex.VerifyAccounts.Add(VAccount); 
                dBContex.SaveChanges();
                return SignUpEnum.Success;
            }
            return SignUpEnum.Failure;

        }
        private void SendMail(string to, string Otp)
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(to);
            mail.From = new MailAddress("palajitsingh91@gmail.com");
            mail.Subject = "Verify Your Account";
            string Body = $"Your OTP is <b> {Otp}</b>  <br/>thanks for choosing us.";
            mail.Body = Body;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("palajitsingh91@gmail.com", "9935277183"); // Enter seders User name and password  
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }
        private string GenerateOTP()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var list = Enumerable.Repeat(0, 8).Select(x => chars[random.Next(chars.Length)]);
            var r = string.Join("", list);
            return r;
        }

        public bool VerifyAccount(string Otp)
        {
            if (dBContex.VerifyAccounts.Any(e => e.Otp == Otp))
            {
                var Acc = dBContex.VerifyAccounts.SingleOrDefault(e => e.Otp == Otp);
                var User = dBContex.Users.SingleOrDefault(e => e.Email == Acc.UserId);
                User.IsVerified = true;
                User.IsActive = true;

                dBContex.VerifyAccounts.Remove(Acc);
                dBContex.Users.Update(User);
                dBContex.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public ForgotPassEnum ForgotPassword(ForgotPassModel model)
        {
            if (dBContex.Users.Any(e => e.Email == model.Email))
            {
                string Otp = GenerateOTP();
                SendMail(model.Email, Otp);
                var VAccount = new VerifyAccount()
                {
                    Otp = Otp,
                    UserId = model.Email,
                    SendTime = DateTime.Now
                };
                dBContex.VerifyAccounts.Add(VAccount);
                return ForgotPassEnum.Success;
            }
            else
            {
                return ForgotPassEnum.Failure;
            }
            
        }

    }
}
// https://g.co/allowaccess
