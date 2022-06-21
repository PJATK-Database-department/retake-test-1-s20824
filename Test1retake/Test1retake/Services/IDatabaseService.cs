using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test1retake.Dto;

namespace Test1retake.Services
{
    public interface IDatabaseService
    {
        Task<ICollection<AlbumDto>> GetAlbumsAsync(int albumId);
        Task<bool> DeleteMusicianAsync(int delMusician);
    }
}
