using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApi.Models
{
        [DataContract]
    public class Address
    {
        [DataMember]
        public string IPAddress { get; set; }
        [DataMember]

        public string Province { get; set; }
        [DataMember]

        public string City { get; set; }
    }  
}