﻿using System;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI;
using healthsight_project.MyDBServiceReference;
using System.Globalization;
using System.Text.RegularExpressions;

namespace healthsight_project
{
    public partial class UserSettings : System.Web.UI.Page
    {
        static string finalHash;
        static string salt;
        byte[] Key;
        byte[] IV;
        protected void Page_Load(object sender, EventArgs e)
        {
            lbUpdPassEr.Text = "";
            MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
            Session["LoggedIn"].ToString();
        }

        // Created with reference from the above method
        public bool IsPasswordValid(string pwd)
        {
            if (string.IsNullOrWhiteSpace(pwd))
                return false;

            try
            {
                return Regex.IsMatch(pwd, @"^.*(?=.{8,})(?=.+\d)(?=.+[a-z])(?=.+[A-Z])(?=.+[!*@#$%^&+=]).*",
                    RegexOptions.None, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        public bool IsPasswordCorrect(string email, string pass)
        {
            MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
            User user = client.GetUserByEmail(email);
            SHA512Managed hashing = new SHA512Managed();
            string dbHash = user.FinalHash;
            string dbSalt = user.Salt;
            if (dbSalt != null && dbSalt.Length > 0 && dbHash != null && dbHash.Length > 0)
            {
                string passWithSalt = pass + dbSalt;
                byte[] hashWithSalt = hashing.ComputeHash(Encoding.UTF8.GetBytes(passWithSalt));
                string userHash = Convert.ToBase64String(hashWithSalt);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ValidatePassword()
        {
            if (!IsPasswordCorrect(Session["LoggedIn"].ToString(),tbCurrPass.Text))
            {
                lbUpdPassEr.Text += "Incorrect Password. </br>";
            }
            if (!IsPasswordValid(tbNewPass.Text))
            {
                lbUpdPassEr.Text += "Invalid Password. Please follow the requirements. </br>";
            }
            if (lbUpdPassEr.Text == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {

            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();

            if (Request.Cookies["ASP.NET_SessionId"] != null)
            {
                Response.Cookies["ASP.NET_SessionId"].Value = string.Empty;
                Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddMonths(-20);
            }

            if (Request.Cookies["AuthToken"] != null)
            {
                Response.Cookies["AuthToken"].Value = string.Empty;
                Response.Cookies["AuthToken"].Expires = DateTime.Now.AddMonths(-20);
            }

            Response.Redirect("Login.aspx", false);
        }

        protected void btnEmail_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateEmail.aspx");
        }

        protected void btnPhoneNo_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateContactNo.aspx");
        }

        protected void btnAddr_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateAddr.aspx");
        }

        protected void btnUpdPass_Click(object sender, EventArgs e)
        {
            bool passvalid = ValidatePassword();

            if (passvalid)
            {
                string pwd = tbNewPass.Text.ToString().Trim(); ;

                RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
                byte[] saltByte = new byte[8];

                rng.GetBytes(saltByte);
                salt = Convert.ToBase64String(saltByte);

                SHA512Managed hashing = new SHA512Managed();

                string pwdWithSalt = pwd + salt;

                byte[] plainHash = hashing.ComputeHash(Encoding.UTF8.GetBytes(pwd));
                byte[] hashWithSalt = hashing.ComputeHash(Encoding.UTF8.GetBytes(pwdWithSalt));
                finalHash = Convert.ToBase64String(hashWithSalt);

                RijndaelManaged cipher = new RijndaelManaged();
                cipher.GenerateKey();
                Key = cipher.Key;
                IV = cipher.IV;
                

            }
        }
    }
}