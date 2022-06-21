using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test1retake.Dto;

namespace Test1retake.Services
{
    public class DatabaseService : IDatabaseService
    {
        private readonly string _configuration;
        public DatabaseService(IConfiguration configuration)
        {
            _configuration = configuration.GetConnectionString("PjatkDbConnection");
        }

        public async Task<bool> CheckIfMusicianExists(int delMusician)
        {

            using var connection = new SqlConnection(_configuration);
            var command = new SqlCommand("select iif(count(1) > 0, 1, 0) from Musician_Track, Track where Musician_Track.IdTrack = Track.IdTrack and Musician_Track.IdMusician = @delMusician", connection);
            command.Parameters.AddWithValue("@delMusician", delMusician);

            await connection.OpenAsync();
            var result = await command.ExecuteNonQueryAsync();
            if (result == 0)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> DeleteMusicianAsync(int delMusician)
        {
            using var connection = new SqlConnection(_configuration);
            await connection.OpenAsync();

            if (!await CheckIfMusicianExists(delMusician))
            {
                return false;
            }
            
            var command = new SqlCommand("delete from Musician where IdMusician = @delMusician", connection);
            command.Parameters.AddWithValue("@delMusician", delMusician);

            return true;
        }

        public async Task<ICollection<AlbumDto>> GetAlbumsAsync(int albumId)
        {
            var albums = new List<AlbumDto>();

            using var connection = new SqlConnection(_configuration);
            var command = new SqlCommand("select IdAlbum, AlbumName, PublishDate, IdTrack, TrackName, Duration from Album, Track where Album.IdAlbum = Track.IdMusicAlbum and IdAlbum = @albumId order by Duration asc", connection);
            command.Parameters.AddWithValue("@albumId", albumId);

            await connection.OpenAsync();
            var reader = await command.ExecuteReaderAsync();

            while(await reader.ReadAsync())
            {
                var album = new AlbumDto();
                album.IdAlbum = Convert.ToInt32(reader["IdAlbum"]);
                album.AlbumName = reader["AlbumName"].ToString();
                album.PublishDate = Convert.ToDateTime(reader["PublishDate"]);
                album.IdTrack = Convert.ToInt32(reader["IdTrack"]);
                album.TrackName = reader["TrackName"].ToString();
                album.Duration = (float)Convert.ToDouble(reader["Duration"]);
                albums.Add(album);
            }

            return albums;
        }
    }
}
