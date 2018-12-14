using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System;
using System.Runtime.Serialization.Json;
using System.Collections.Generic;

namespace WebApiClient
{
  static class Processes {
    private static readonly HttpClient client = new HttpClient();

    public static async Task<List<Repository>> getRepositories() {

      var serializer = new DataContractJsonSerializer(typeof(List<Repository>));

      client.DefaultRequestHeaders.Accept.Clear();
      client.DefaultRequestHeaders.Accept.Add(
        new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json")
      );
      client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

      var streamTask = client.GetStreamAsync("https://api.github.com/orgs/dotnet/repos");
      var repositories = serializer.ReadObject(await streamTask) as List<Repository>;
      return repositories;
    }
  }
}