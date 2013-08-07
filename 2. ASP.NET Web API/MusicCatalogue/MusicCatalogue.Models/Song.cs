using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MusicCatalogue.Models
{
    [DataContract(IsReference = true)]
    public class Song
    {
        [DataMember]
        private ICollection<Album> albums;

        [DataMember]
        private ICollection<Artist> artists;

        public Song()
        {
            this.artists = new HashSet<Artist>();
            this.albums = new HashSet<Album>();
        }

        public int SongId { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Genre { get; set; }

        [DataMember]
        public int Year { get; set; }

        public virtual ICollection<Album> Albums
        {
            get
            {
                return this.albums;
            }
            set
            {
                this.albums = value;
            }
        }

        public virtual ICollection<Artist> Artists
        {
            get
            {
                return this.artists;
            }
            set
            {
                this.artists = value;
            }
        }
    }
}