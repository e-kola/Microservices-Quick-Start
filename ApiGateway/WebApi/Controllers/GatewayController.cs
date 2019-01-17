using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TVX.Test.ApiGateway.Controllers
{
    using Core;
    using Business.Interfaces;
    using Repository.Interfaces;
    using Models;

    [Produces("application/json")]
    public class GatewayController : Controller
    {
        private readonly IGatewayService _service;
        private readonly IGatewayRepository _repository;

        public GatewayController(IGatewayService service, IGatewayRepository repository)
        {
            _service = service;
            _repository = repository;
        }

        // GET: api/Gateway/IsPostsServiceOnline
        [HttpGet]
        [Route("api/Gateway/IsPostsServiceOnline")]
        public async Task<bool> IsPostsServiceOnline()
        {
            return await _service.IsPostsServiceOnlineAsync();
        }

        // GET: api/Gateway/IsCommentsServiceOnline
        [HttpGet]
        [Route("api/Gateway/IsCommentsServiceOnline")]
        public async Task<bool> IsCommentsServiceOnline()
        {
            return await _service.IsCommentsServiceOnlineAsync();
        }

        // GET: api/Gateway/PostsCount
        [HttpGet]
        [Route("api/Gateway/PostsCount")]
        public int PostsCount()
        {
            return _service.PostsCount;
        }

        // GET: api/Gateway/CommentsCount
        [HttpGet]
        [Route("api/Gateway/CommentsCount")]
        public int CommentsCount()
        {
            return _service.CommentsCount;
        }

        // GET: api/Gateway/GetOnlineStatus
        [HttpGet]
        [Route("api/Gateway/GetOnlineStatus")]
        public bool? GetOnlineStatus()
        {
            return _repository.GetOnlineStatus(1);
        }

        // GET api/Gateway/GetServiceDescriptor/3
        [HttpGet]
        [Route("api/Gateway/GetServiceDescriptor/{id}")]
        public async Task<IMicroService> GetServiceDescriptor(int id)
        {
            return await Task.Run(() => _service.GetServiceDescriptor(id));
        }
    }
}
