using System.Text.Json;
using Text_to_Objects;

string urlRequest = "https://localhost:7233/Request";
string urlResponse = "https://localhost:7233/Response";

var deserializerOptions = new JsonSerializerOptions
{
    PropertyNameCaseInsensitive = true,
};

var serializerOptions = new JsonSerializerOptions
{
    WriteIndented = true,
};

//inerente all'url request
var htttpClientRequest= new HttpClient();
var uriRequest= new Uri(urlRequest);
var resultRequest= await htttpClientRequest.GetAsync(uriRequest);

Console.WriteLine("sto stampando in formato Json le domande");
string readValueRequestToString= await resultRequest.Content.ReadAsStringAsync();
var questions= JsonSerializer.Deserialize<List<Question>>(readValueRequestToString, deserializerOptions);

string requestToJson= JsonSerializer.Serialize(questions, serializerOptions);

Console.WriteLine(requestToJson);

Console.WriteLine("------------------------------------------------------");

//inerente all'url response
var htttpClientResponse = new HttpClient();
var uriResponse = new Uri(urlResponse);
var resultResponse = await htttpClientResponse.GetAsync(uriResponse);

Console.WriteLine("sto stampando in formato Json le risposte");
string readValueResponseToString = await resultResponse.Content.ReadAsStringAsync();
var answer = JsonSerializer.Deserialize<List<Question>>(readValueResponseToString, deserializerOptions);

string responseToJson = JsonSerializer.Serialize(answer, serializerOptions);

Console.WriteLine(responseToJson);





