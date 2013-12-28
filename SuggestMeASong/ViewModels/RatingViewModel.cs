using log4net.Util.TypeConverters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuggestMeASong.ViewModels
{
    [Serializable]
    public class RatingViewModel
    {
        public int Value { get; set; }
        public string ExternalId { get; set; }
        public string ExternalProviderName { get; set; }
    }
}