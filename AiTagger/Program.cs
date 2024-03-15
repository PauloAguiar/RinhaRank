using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

string rootPath = @"./rinha-repo/participantes";

HttpClient client = new HttpClient();

using (StreamWriter writer = new StreamWriter("./result.csv", false, Encoding.UTF8))
{
    writer.WriteLine("Folder,LoadBalancer,Language,Framework,Database");

    foreach (var filePath in Directory.GetFiles(rootPath, "readme.md", SearchOption.AllDirectories))
    {
        var fi = new FileInfo(filePath);
        var foldername = fi.Directory.Name;

        string prompt = "Based on the following README file, generate 4 tags for the repository. The format should be tag1;tag2;tag3;tag4. The response should include the tags only. First tag should be for the load balancer. If its not a standard solution, use custom, otherwise use a short form name for the solution (e.g. nginx, haproxy). The second tag should be the language used to implement the server e.g. (cpp, c, rust, c#). The third tag should be the web technology used (e.g. aspnet, tokio, bun). If not possible to determine, use unknown. the fourth that should be the database solution, again use custom or a standard solution (postgres, mariadb, mysql). If the solution is in an in memory solution, use \"in-memory\". README: {Content}";

        var finalPrompt = prompt.Replace("{Content}", File.ReadAllText(fi.FullName));
        var result = await CallChatGPTAPI(finalPrompt);
        writer.WriteLine($"{foldername};{result}");
    }
}

async Task<string> CallChatGPTAPI(string prompt)
{
    var apiKey = Environment.GetEnvironmentVariable("openapi_key");
    var endpoint = "https://api.openai.com/v1/chat/completions"; // Adjust if using a different version or endpoint

    var request = new ChatGPTRequest
    {
        Model = "gpt-3.5-turbo-16k",
        Messages = new List<Message>
        {
            new Message { Role = "user", Content = prompt }
        }
    };

    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKey);
    var json = JsonSerializer.Serialize(request);
    var content = new StringContent(json, Encoding.UTF8, "application/json");

    var response = await client.PostAsync(endpoint, content);
    var responseString = await response.Content.ReadAsStringAsync();

    if (response.IsSuccessStatusCode)
    {
        var result = JsonSerializer.Deserialize<ChatResponse>(responseString);
        return result.Choices[0].Message.Content;
    }
    else
    {
        return "Error: " + responseString;
    }
}

class ChatGPTRequest
{
    [JsonPropertyName("model")]
    public string Model { get; set; }

    [JsonPropertyName("messages")]
    public List<Message> Messages { get; set; }

    [JsonPropertyName("temperature")]
    public double Temperature { get; set; }
}

class Message
{
    [JsonPropertyName("role")]
    public string Role { get; set; }

    [JsonPropertyName("content")]
    public string Content { get; set; }
}

class ChatResponse
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("object")]
    public string Object { get; set; }

    [JsonPropertyName("created")]
    public long Created { get; set; }

    [JsonPropertyName("model")]
    public string Model { get; set; }

    [JsonPropertyName("choices")]
    public Choice[] Choices { get; set; }

    [JsonPropertyName("usage")]
    public Usage Usage { get; set; }
}

class Choice
{
    [JsonPropertyName("index")]
    public int Index { get; set; }

    [JsonPropertyName("message")]
    public Message Message { get; set; }

    [JsonPropertyName("logprobs")]
    public object Logprobs { get; set; }

    [JsonPropertyName("finish_reason")]
    public string FinishReason { get; set; }
}

class Usage
{
    [JsonPropertyName("prompt_tokens")]
    public int PromptTokens { get; set; }

    [JsonPropertyName("completion_tokens")]
    public int CompletionTokens { get; set; }

    [JsonPropertyName("total_tokens")]
    public int TotalTokens { get; set; }
}