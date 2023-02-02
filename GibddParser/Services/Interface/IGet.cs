using GibddParser.Models;

namespace GibddParser.Services.Interface;

public interface IGet
{
    public Task<Response<T>> GetResponse<T>(string number, string checkType, string url) where T : class;
    public Task<T> GetInfo<T>(string number, string checkType, string url) where T : class;
}