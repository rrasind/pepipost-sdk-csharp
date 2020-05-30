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
    public partial class EventsController: BaseController
    {
        #region Singleton Pattern

        //private static variables for the singleton pattern
        private static object syncObject = new object();
        private static EventsController instance = null;

        /// <summary>
        /// Singleton pattern implementation
        /// </summary>
        internal static EventsController Instance
        {
            get
            {
                lock (syncObject)
                {
                    if (null == instance)
                    {
                        instance = new EventsController();
                    }
                }
                return instance;
            }
        }

        #endregion Singleton Pattern

        /// <summary>
        /// Lets you to retrieve the email transaction logs.
        /// </summary>
        /// <param name="startdate">Required parameter: The starting date of the statistics to retrieve. Must follow format YYYY-MM-DD.</param>
        /// <param name="events">Optional parameter: Filter based on different email events. If not passed, all events will be fetched. Multiple comma separated events are allowed</param>
        /// <param name="sort">Optional parameter: Sort based on email sent time</param>
        /// <param name="enddate">Optional parameter: The end date of the statistics to retrieve. Defaults to today. Must follow format YYYY-MM-DD</param>
        /// <param name="offset">Optional parameter: The point in the list to begin retrieving results.</param>
        /// <param name="limit">Optional parameter: The number of results to return.</param>
        /// <param name="subject">Optional parameter: Filter logs based on subject</param>
        /// <param name="xapiheader">Optional parameter: Filter logs based on recipient's email</param>
        /// <param name="fromaddress">Optional parameter: Filter logs based on fromaddress</param>
        /// <param name="email">Optional parameter: Filter logs based on recipient's email</param>
        /// <return>Returns the object response from the API call</return>
        public object GetEventsGET(
                DateTime startdate,
                Models.EventsEnum? events = null,
                Models.SortEnum? sort = null,
                DateTime? enddate = null,
                int? offset = 0,
                int? limit = 10,
                string subject = null,
                string xapiheader = null,
                string fromaddress = null,
                string email = null)
        {
            Task<object> t = GetEventsGETAsync(startdate, events, sort, enddate, offset, limit, subject, xapiheader, fromaddress, email);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Lets you to retrieve the email transaction logs.
        /// </summary>
        /// <param name="startdate">Required parameter: The starting date of the statistics to retrieve. Must follow format YYYY-MM-DD.</param>
        /// <param name="events">Optional parameter: Filter based on different email events. If not passed, all events will be fetched. Multiple comma separated events are allowed</param>
        /// <param name="sort">Optional parameter: Sort based on email sent time</param>
        /// <param name="enddate">Optional parameter: The end date of the statistics to retrieve. Defaults to today. Must follow format YYYY-MM-DD</param>
        /// <param name="offset">Optional parameter: The point in the list to begin retrieving results.</param>
        /// <param name="limit">Optional parameter: The number of results to return.</param>
        /// <param name="subject">Optional parameter: Filter logs based on subject</param>
        /// <param name="xapiheader">Optional parameter: Filter logs based on recipient's email</param>
        /// <param name="fromaddress">Optional parameter: Filter logs based on fromaddress</param>
        /// <param name="email">Optional parameter: Filter logs based on recipient's email</param>
        /// <return>Returns the object response from the API call</return>
        public async Task<object> GetEventsGETAsync(
                DateTime startdate,
                Models.EventsEnum? events = null,
                Models.SortEnum? sort = null,
                DateTime? enddate = null,
                int? offset = 0,
                int? limit = 10,
                string subject = null,
                string xapiheader = null,
                string fromaddress = null,
                string email = null)
        {
            //the base uri for api requests
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/events");

            //process optional query parameters
            APIHelper.AppendUrlWithQueryParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "startdate", startdate.ToString("yyyy'-'MM'-'dd") },
                { "events", (events.HasValue) ? Models.EventsEnumHelper.ToValue(events.Value) : null },
                { "sort", (sort.HasValue) ? Models.SortEnumHelper.ToValue(sort.Value) : null },
                { "enddate", (enddate.HasValue) ? enddate.Value.ToString("yyyy'-'MM'-'dd") : null },
                { "offset", (null != offset) ? offset : 0 },
                { "limit", (null != limit) ? limit : 10 },
                { "subject", subject },
                { "xapiheader", xapiheader },
                { "fromaddress", fromaddress },
                { "email", email }
            },ArrayDeserializationFormat,ParameterSeparator);


            //validate and preprocess url
            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string,string>()
            {
                { "user-agent", "APIMATIC 2.0" }
            };
            _headers.Add("api_key", Configuration.ApiKey);

            //prepare the API call request to fetch the response
            HttpRequest _request = ClientInstance.Get(_queryUrl,_headers);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request,_response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 400)
                throw new APIException(@"API Response", _context);

            if (_response.StatusCode == 401)
                throw new APIException(@"API Response", _context);

            if (_response.StatusCode == 403)
                throw new APIException(@"API Response", _context);

            if (_response.StatusCode == 405)
                throw new APIException(@"Invalid input", _context);

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            try
            {
                return _response.Body;
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

    }
} 