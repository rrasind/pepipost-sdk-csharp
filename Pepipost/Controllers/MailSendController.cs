/*
 * Pepipost
 *
 * This file was automatically generated by APIMATIC v2.0 ( https://apimatic.io ).
 */
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;
using Pepipost;
using Pepipost.Utilities;
using Pepipost.Http.Request;
using Pepipost.Http.Response;
using Pepipost.Http.Client;
using Pepipost.Exceptions;

namespace Pepipost.Controllers
{
    public partial class MailSendController : BaseController
    {
        #region Singleton Pattern

        //private static variables for the singleton pattern
        private static object syncObject = new object();
        private static MailSendController instance = null;

        /// <summary>
        /// Singleton pattern implementation
        /// </summary>
        internal static MailSendController Instance
        {
            get
            {
                lock (syncObject)
                {
                    if (null == instance)
                    {
                        instance = new MailSendController();
                    }
                }
                return instance;
            }
        }

        #endregion Singleton Pattern

        /// <summary>
        /// The endpoint send is used to generate the request to pepipost server for sending an email to recipients.
        /// </summary>
        /// <param name="body">Required parameter: New mail request will be generated</param>
        /// <return>Returns the object response from the API call</return>
        public object CreateGeneratethemailsendrequest(Models.Send body)
        {
            Task<object> t = CreateGeneratethemailsendrequestAsync(body);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// The endpoint send is used to generate the request to pepipost server for sending an email to recipients.
        /// </summary>
        /// <param name="body">Required parameter: New mail request will be generated</param>
        /// <return>Returns the object response from the API call</return>
        public async Task<object> CreateGeneratethemailsendrequestAsync(Models.Send body, string url = null)
        {
            //the base uri for api requests
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder();

            if (string.IsNullOrWhiteSpace(url))
            {
                _queryBuilder.Append("/mail/send");
            }
            else
            {
                _queryBuilder.Append(url + "/v5/mail/send");
            }

            //validate and preprocess url
            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string, string>()
            {
                { "user-agent", "pepi-sdk-csharp v5" },
                { "content-type", "application/json; charset=utf-8" }
            };
            _headers.Add("api_key", Configuration.ApiKey);

            //append body params
            var _body = APIHelper.JsonSerialize(body);

            //prepare the API call request to fetch the response
            HttpRequest _request = ClientInstance.PostBody(_queryUrl, _headers, _body);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse)await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);

            try
            {
                return _response.Body;
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message + "\nResponse : " + _response.Body, _context);
            }
        }

    }
}