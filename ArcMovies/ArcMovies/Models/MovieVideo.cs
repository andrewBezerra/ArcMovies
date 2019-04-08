using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ArcMovies.Models
{
    [DataContract]
    public class MovieVideo
    {
        [DataMember(Name = "id")]
        public int MovieId { get; set; }

        [DataMember(Name = "results")]
        public IList<MovieVideoItem> Videos { get; set; }
    }
}