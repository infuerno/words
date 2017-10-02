using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class OedSearchResults
    {
        public Result[] results { get; set; }
        public Metadata metadata { get; set; }

        public class Metadata
        {
            public string provider { get; set; }
            public string sourceLanguage { get; set; }
            public int total { get; set; }
            public int offset { get; set; }
            public int limit { get; set; }
        }

        public class Result
        {
            public string matchString { get; set; }
            public string word { get; set; }
            public string id { get; set; }
            public string matchType { get; set; }
            public string inflection_id { get; set; }
            public string region { get; set; }
        }
    }
}
