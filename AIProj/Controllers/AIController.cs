using AIProj.Models;
using Microsoft.AspNetCore.Mvc;
using OpenAI;
using OpenAI.Files;
using OpenAI.Models;

namespace AIProj.Controllers
{
    [ApiController]
    public class AIController : ControllerBase
    {
        private IConversationStore _conversationStore;

        public AIController(IConversationStore conversationStore)
        {
            _conversationStore = conversationStore;
        }

        [HttpGet("api/ai")]
        public async Task<IActionResult> CreateCompletion()
        {
            var openAI = new OpenAIClient(new OpenAIAuthentication("", null));
            var models = await openAI.ModelsEndpoint.GetModelsAsync();

            return Ok(models);
        }

        [HttpPost("api/ai/{input}")]
        public async Task<IActionResult> Chat([FromRoute] string input)
        {
            if (_conversationStore.Conversations.Count == 0)
            {
                _conversationStore.StartNewConversation();
            }

            _conversationStore.Current.AddQuestion(input);

            var openAI = new OpenAIClient(new OpenAIAuthentication("", null));
            var response = await openAI.CompletionsEndpoint.CreateCompletionAsync(input, temperature: 1, model: Model.Davinci);

            _conversationStore.Current.AddAnswer(response.Completions[0].Text);
            
            return Ok(response.Completions[0].Text);
        }

        [HttpGet("api/ai/conversations")]
        public IActionResult GetAllConversations()
        {
            var convs = _conversationStore.Conversations.Select(x => x.Id).ToList();
            return Ok(convs);
        }

        [HttpPost("api/ai/newConversation")]
        public IActionResult CreateConversation()
        {
            _conversationStore.StartNewConversation();
            var convs = _conversationStore.Conversations.Select(x => x.Id).ToList();
            return Ok(convs);
        }
    }
}
