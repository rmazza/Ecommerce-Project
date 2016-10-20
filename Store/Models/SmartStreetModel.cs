using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Models
{
    public class SmartStreetModel
    {
        public SmartStreetModel(string json)
        {
            JObject jObject = JObject.Parse(json);
            JToken jUser = jObject[""];

        }

        public class Rootobject
        {
            [JsonProperty(PropertyName = "Data")]
            public Class1[] Data { get; set; }
        }

        public class Class1
        {
            public int input_index { get; set; }
            public int candidate_index { get; set; }
            public string delivery_line_1 { get; set; }
            public string last_line { get; set; }
            public string delivery_point_barcode { get; set; }
            public Components components { get; set; }
            public Metadata metadata { get; set; }
            public Analysis analysis { get; set; }
        }

        public class Components
        {
            public string primary_number { get; set; }
            public string street_name { get; set; }
            public string street_suffix { get; set; }
            public string city_name { get; set; }
            public string state_abbreviation { get; set; }
            public string zipcode { get; set; }
            public string plus4_code { get; set; }
            public string delivery_point { get; set; }
            public string delivery_point_check_digit { get; set; }
        }

        public class Metadata
        {
            public string record_type { get; set; }
            public string zip_type { get; set; }
            public string county_fips { get; set; }
            public string county_name { get; set; }
            public string carrier_route { get; set; }
            public string congressional_district { get; set; }
            public string rdi { get; set; }
            public string elot_sequence { get; set; }
            public string elot_sort { get; set; }
            public float latitude { get; set; }
            public float longitude { get; set; }
            public string precision { get; set; }
            public string time_zone { get; set; }
            public int utc_offset { get; set; }
            public bool dst { get; set; }
        }

        public class Analysis
        {
            public string dpv_match_code { get; set; }
            public string dpv_footnotes { get; set; }
            public string dpv_cmra { get; set; }
            public string dpv_vacant { get; set; }
            public string active { get; set; }
            public string footnotes { get; set; }
        }

    }
}