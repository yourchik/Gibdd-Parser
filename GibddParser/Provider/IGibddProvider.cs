using GibddParser.Models;

namespace GibddParser.Provider;

public interface IGibddProvider
{
    public Task<T> GetInfo<T>(string number, string checkType, string url) where T : class;
}