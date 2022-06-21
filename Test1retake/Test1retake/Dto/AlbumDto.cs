using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test1retake.Dto
{
    public class AlbumDto
    {
        public int IdAlbum { get; set; }
        public string AlbumName { get; set; }
        public DateTime PublishDate { get; set; }
        public int IdMusicLabel { get; set; }
        public int IdTrack { get; set; }
        public string TrackName { get; set; }
        public float Duration { get; set; }
    }
}
