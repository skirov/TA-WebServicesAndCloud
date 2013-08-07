﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace MusicCatalogue.Models
{
    [DataContract(IsReference = true)]
    public class Album
    {
        [DataMember]
        private ICollection<Artist> artists;

        [DataMember]
        private ICollection<Song> songs;

        public Album()
        {
            this.artists = new HashSet<Artist>();
            this.songs = new HashSet<Song>();
        }

        public int AlbumId { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Producer { get; set; }

        [DataMember]
        public int Year { get; set; }

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
