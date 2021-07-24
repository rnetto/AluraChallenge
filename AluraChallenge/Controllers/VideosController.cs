using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AluraFlix.Data;
using AluraFlix.Domain;
using AluraFlix.Service;
using AluraFlix.Dtos;

namespace AluraFlix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideosController : ControllerBase
    {
        private readonly IVideoService _videoContext;

        public VideosController(IVideoService videoService)
        {
            _videoContext = videoService;
        }

        // GET: api/Videos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VideoDto>>> GetVideo()
        {
            var listVideo = await _videoContext.GetAll();

            var listVideoDto = listVideo.Select(x => new VideoDto
            {
                Id = x.Id,
                Titulo = x.Titulo,
                Descricao = x.Descricao,
                Url = x.Url
            });


            return Ok(listVideoDto);
        }

        // GET: api/Videos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Video>> GetVideo(int id)
        {
            var video = await _videoContext.GetId(id);

            if (video == null)
            {
                return NotFound("Video não encontrado.");
            }

            return video;
        }

        // PUT: api/Videos/id
       
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVideo(int id, VideoDto videoDto)
        {
            if (id != videoDto.Id)
            {
                return BadRequest();
            }

            var videoUpdate = new Video
            {
                Id = videoDto.Id,
                Titulo = videoDto.Titulo,
                Descricao = videoDto.Descricao,
                Url = videoDto.Url
            };

            var videoUp = await _videoContext.Update(id, videoUpdate);
            if(videoUp == null)
            {
                return BadRequest();
            }

            return Ok(videoUp);
        }

        // POST: api/Videos
        
        [HttpPost]
        public async Task<ActionResult<Video>> PostVideo(PostVideoDto postVideoDto)
        {
            var video = new Video
            {
                Titulo = postVideoDto.Titulo,
                Descricao = postVideoDto.Descricao,
                Url = postVideoDto.Url
            };

            await _videoContext.Insert(video);

            return CreatedAtAction("GetVideo", new { id = video.Id }, postVideoDto);
        }

        // DELETE: api/Videos/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVideo(int id)
        {
            var video = await _videoContext.Delete(id);
            if(video == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        
    }
}
