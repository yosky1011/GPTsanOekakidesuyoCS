﻿using GPTsanOekakidesuyoCS.Data;
using GPTsanOekakidesuyoCS.Responses.Session;
using GPTsanOekakidesuyoCS.Services;
using Microsoft.AspNetCore.Mvc;

namespace GPTsanOekakidesuyoCS.Controllers.session
{
    [ApiController]
    [Route("[controller]")]
    public class SessionController : ControllerBase
    {

        // DIに用いるフィールドを定義
        private readonly ILogger<SessionController> _logger;
        private IGetSessionService _getSessionService;

        // DIによる初期化
        // Program.csで対象をDIコンテナに登録済み
        public SessionController(
            ILogger<SessionController> logger,
            IGetSessionService getSessionService
        ) {
            _logger = logger;
            _getSessionService = getSessionService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetSessionResponse>> Get(int id)
        {
            return await _getSessionService.Run(id);
        }
    }
}
