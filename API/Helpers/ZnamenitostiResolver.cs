using API.Dtos;
using AutoMapper;
using Core.Entities;
using Microsoft.Extensions.Configuration;

namespace API.Helpers
{
    public class ZnamenitostiResolver : IValueResolver<Znamenitost, ZnamenitostiToReturnDto, string> {
        private readonly IConfiguration _config;

    
        public ZnamenitostiResolver(IConfiguration config)
    {
        _config = config;
    }

    public string Resolve(Znamenitost source, ZnamenitostiToReturnDto destination, string destMember, ResolutionContext context)
    {
        if(!string.IsNullOrEmpty(source.PictureUrl))
        {
            return _config["ApiUrl"] + source.PictureUrl;
        }
        return null;
    }
}
}