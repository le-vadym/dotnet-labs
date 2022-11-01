using Lab7.Models;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace Lab7.Client.Services;

public class GenericDataService<T> : IDataService<T> where T : ModelBase
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _config;

    private string EndPoint => string.Join('/', _config["apiServerUrl"], typeof(T).Name);

    public GenericDataService(HttpClient httpClient, IConfiguration config)
    {
        _httpClient = httpClient;
        _config = config;
    }

    public async Task<T> CreateAsync(T entity)
    {
        var json = JsonSerializer.Serialize(entity);
        var data = new StringContent(json, encoding: Encoding.UTF8, mediaType: "application/json");

        var responce = await _httpClient.PostAsync(EndPoint, data);
        if (!responce.IsSuccessStatusCode)
        {
            throw new Exception(responce.StatusCode.ToString());
        }
        var createdEntity = await responce.Content.ReadFromJsonAsync<T>();

        return createdEntity!;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var url = string.Join('/', EndPoint, id.ToString());

        var responce = await _httpClient.DeleteAsync(url);
        if (!responce.IsSuccessStatusCode)
        {
            throw new Exception(responce.StatusCode.ToString());
        }

        return responce.IsSuccessStatusCode;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        var responce = await _httpClient.GetAsync(EndPoint);
        if (!responce.IsSuccessStatusCode)
        {
            throw new Exception(responce.StatusCode.ToString());
        }

        var entities = await responce.Content.ReadFromJsonAsync<IEnumerable<T>>();
        return entities!;
    }

    public async Task<T> GetAsync(Guid id)
    {
        var url = string.Join('/', EndPoint, id.ToString());

        var responce = await _httpClient.GetAsync(url);
        if (!responce.IsSuccessStatusCode)
        {
            throw new Exception(responce.StatusCode.ToString());
        }

        var entity = await responce.Content.ReadFromJsonAsync<T>();
        return entity!;
    }

    public async Task<T> UpdateAsync(Guid id, T entity)
    {
        var url = string.Join('/', EndPoint, id.ToString());

        var json = JsonSerializer.Serialize(entity);
        var data = new StringContent(json, encoding: Encoding.UTF8, mediaType: "application/json");

        var responce = await _httpClient.PutAsync(url, data);
        if (!responce.IsSuccessStatusCode)
        {
            throw new Exception(responce.StatusCode.ToString());
        }

        var updatedEntity = await responce.Content.ReadFromJsonAsync<T>();
        return updatedEntity!;
    }
}
