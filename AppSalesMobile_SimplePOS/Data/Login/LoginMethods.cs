﻿using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AppSalesMobile_SimplePOS.Models.Login;

namespace AppSalesMobile_SimplePOS.Data.Login
{
    public class LoginMethods
    {
        readonly GlobalUsings link = new();

        //private readonly LoginStateService _loginStateService;
        //public LoginMethods(LoginStateService loginStateService)
        //{
        //    _loginStateService = loginStateService;
        //}

        public async Task<string> Authenticate(LoginObj logobj)
        {
            var client = new RestClient();

            string responseContent = string.Empty;


            try
            {
                var request = new RestRequest(link.apilinkpub + "api/Login/ValidateLogin").AddJsonBody(logobj);
                request.Method = Method.Post;

                request.AddHeader("Accept", "application/json");
                request.AddHeader("Content-Type", "application/json");

                RestResponse response = await client.PostAsync(request);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    responseContent = response.Content.ToString();
                    Console.WriteLine(responseContent);
                    //LoginStateService loginStateService = new();
                    //_loginStateService.LoginStateMethod(response);



                }
                return responseContent;

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                return responseContent;

                //await _navigation.PushAsync(new AlertPop());

            }


        }
    }
}
