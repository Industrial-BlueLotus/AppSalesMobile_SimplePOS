using AppSalesMobile_SimplePOS.Models.Login;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSalesMobile_SimplePOS.Data.Login
{
    public class LoginStateService
    {

        private LoginResModel ResModel = new();

        public LoginResModel LoginStateMethod(RestResponse response)
        {
            string responseContent = response.Content.ToString();
            LoginResModel array = JsonConvert.DeserializeObject<LoginResModel>(responseContent);

            ResModel.ResponseData.User.UserId = array.ResponseData.User.UserId;
            ResModel.ResponseData.User.UserCompanies = array.ResponseData.User.UserCompanies;
            Console.WriteLine(ResModel.ResponseData.User.UserId);


            return ResModel;
        }


        public LoginStateService() { }

        public string GetUserName()
        {
            return ResModel.ResponseData.User.UserId;
        }

        public Usercompany GetUserCompany()
        {
            return ResModel.ResponseData.User.UserCompanies[0];
        }
    }
}
