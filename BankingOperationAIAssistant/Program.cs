using BankingOperationAIAssistant.Services;
using BankingOperationAIAssistant.Models;
using Microsoft.Extensions.AI;
using OpenAI;
using System.ClientModel;

internal class Program
{
    private static async Task Main(string[] args)
    {
        // Supplies the functions that the AI can call to look up banking data.
        BankingServices service = new BankingServices();

        // Groq exposes an OpenAI-compatible endpoint, so the OpenAI client can be used here.
        string _apiKey = Environment.GetEnvironmentVariable("GROQ_API_KEY");
        ApiKeyCredential credential = new ApiKeyCredential(_apiKey);
        OpenAIClientOptions clientOptions = new OpenAIClientOptions()
        {
            Endpoint = new("https://api.groq.com/openai/v1")
        };
        OpenAIClient Groq = new(credential, clientOptions);
        var chatClient = Groq.GetChatClient("openai/gpt-oss-20b");
        IChatClient client = chatClient.AsIChatClient();
        // Limit model tool calls to the approved banking lookup operations.
        ChatOptions chatOptions = new ChatOptions()
        {
            Tools = [
                AIFunctionFactory.Create(service.GetCustomerById),
                AIFunctionFactory.Create(service.GetAccountBalance),
                AIFunctionFactory.Create(service.FindAccountOwner)

                    ]
        };

        // Executes requested tools locally and sends their results back to the model.
        client = ChatClientBuilderChatClientExtensions.AsBuilder(client).UseFunctionInvocation().Build();
        string systemPrompt = @$"
        You are an Banking operations assistant
        Your Responsiblities are :
        1: Help employees retrieve account and customer information
        2: Check account balance
        3: Get customers details
        4: when nothing found return with proper response if null occurs";

        // Preserve history so follow-up questions can refer to earlier responses.
        List<ChatMessage> history = new List<ChatMessage>()
        {
            new(ChatRole.System,systemPrompt)
        };

        Console.WriteLine("================================================================");
        Console.WriteLine();
        Console.WriteLine("Banking Operations AI Assistant");
        Console.WriteLine("Type exit to close the application");
        Console.WriteLine();
        Console.WriteLine("================================================================");


        while (true)
        {
            Console.WriteLine();
            Console.Write("You : ");
            var query = Console.ReadLine();
            if (query == "exit")
            {
                break;
            }

            // Collect streamed chunks so the complete assistant response enters the history.
            List<ChatResponseUpdate> updates = new List<ChatResponseUpdate>();

            history.Add(new(ChatRole.User, query));
            await foreach (var update in client.GetStreamingResponseAsync(history,chatOptions))
            {
                Console.Write(update);
                updates.Add(update);
            }

            history.AddMessages(updates);

         }


    }
}
