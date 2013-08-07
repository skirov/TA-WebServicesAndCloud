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
    public class Artist
    {
        [DataMember]
        private ICollection<Album> albums;

        [DataMember]
        private ICollection<Song> songs;

        public Artist()
        {
            this.albums = new HashSet<Album>();
            this.songs = new HashSet<Song>();
        }

        public int ArtistId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Country { get; set; }

        [DataMember]
        public DateTime DateOfBirth { get; set; }

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

        public virtual ICollection<Song> Songs
        {
            get
            {
                return this.songs;
            }
            set
            {
                this.songs = value;
            }
        }
    }
}
