using AluraFlix.Data;
using AluraFlix.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AluraFlix.Service
{
    public class VideoService : IVideoService
    {
        private readonly AluraFlixContext _context;
        public VideoService(AluraFlixContext context)
        {
            _context = context;
        }
        public async Task<List<Video>> GetAll()
        {
            var listVideo = await _context.Video
                .ToListAsync();
            
            return listVideo;
        }
        public async Task<Video> GetId(int id)
        {
            var video = await _context.Video.FindAsync(id);
            if (video == null)
            {
                return null;
            }

            return video;
        }
        public async Task<Video> Update(int id, Video videoUpdate)
        {
            if (id != videoUpdate.Id)
            {
                return null;
            }

            var video = await _context.Video.FindAsync(videoUpdate.Id);

            video.Id = videoUpdate.Id;
            video.Titulo = videoUpdate.Titulo;
            video.Descricao = videoUpdate.Descricao;
            video.Url = videoUpdate.Url;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VideoExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return video;

        }
        public async Task<Video> Insert(Video video)
        {
            _context.Video.Add(video);
            await _context.SaveChangesAsync();
            return video;
        }
        public async Task<int?> Delete(int id)
        {
            var video = await _context.Video.FindAsync(id);
            if (video == null)
            {
                return null;
            }

            _context.Video.Remove(video);
            await _context.SaveChangesAsync();
            return video.Id;
        }

        private bool VideoExists(int id)
        {
            return _context.Video.Any(e => e.Id == id);
        }

    }
}
