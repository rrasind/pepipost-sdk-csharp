/*
 * Pepipost
 *
 * This file was automatically generated by APIMATIC v2.0 ( https://apimatic.io ).
 */
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Pepipost;
using Pepipost.Utilities;


namespace Pepipost.Models
{
    public class DomainStruct : BaseModel 
    {
        // These fields hold the values for the public properties.
        private string domain;
        private string envelopeName;

        /// <summary>
        /// The domain you wish to include in the 'From' header of your emails.
        /// </summary>
        [JsonProperty("domain")]
        public string Domain 
        { 
            get 
            {
                return this.domain; 
            } 
            set 
            {
                this.domain = value;
                onPropertyChanged("Domain");
            }
        }

        /// <summary>
        /// The subdomain which will be used for tracking opens, clicks and unsubscribe
        /// </summary>
        [JsonProperty("envelopeName")]
        public string EnvelopeName 
        { 
            get 
            {
                return this.envelopeName; 
            } 
            set 
            {
                this.envelopeName = value;
                onPropertyChanged("EnvelopeName");
            }
        }
    }
} 