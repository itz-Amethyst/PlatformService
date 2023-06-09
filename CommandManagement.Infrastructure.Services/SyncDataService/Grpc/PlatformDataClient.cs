﻿using AutoMapper;
using CommandManagement.Domain.Platforms;
using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;
using PlatformService;

namespace CommandManagement.Infrastructure.Services.SyncDataService.Grpc
{
    public class PlatformDataClient : IPlatformDataClient
    {

        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public PlatformDataClient(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
        }

        public IEnumerable<Platform> ReturnAllPlatforms()
        {
            Console.WriteLine($"--> Calling GRPC Service {_configuration.GetSection("GrpcPlatform").Value}");

            var channel = GrpcChannel.ForAddress(_configuration.GetSection("GrpcPlatform").Value);

            var client = new GrpcPlatform.GrpcPlatformClient(channel);

            var request = new GetAllRequest();

            try
            {
                var reply = client.GetAllPlatforms(request);
                return _mapper.Map<IEnumerable<Platform>>(reply.Platform);
            }
            catch (Exception e)
            {
                Console.WriteLine($"--> Couldnot call GRPC Server {e.Message}");

            }
        }
    }
}
