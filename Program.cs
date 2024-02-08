
string username = "teymur75";
string token = "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";

List<string> reposToDelete = new List<string>
        {
           "Csharp-Class-Constructor-Methods",
           "Csharp-Basics"
        };

using (var client = new HttpClient())
{
    client.DefaultRequestHeaders.Add("User-Agent", "GitHubRepoDeleter");
    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("token", token);

    foreach (string repoName in reposToDelete)
    {
        HttpResponseMessage response = await client.DeleteAsync($"https://api.github.com/repos/{username}/{repoName}");

        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine($"Repo {repoName} successfully deleted.");
        }
        else
        {
            Console.WriteLine($"Error deleting repo {repoName}. Status code: {response.StatusCode}");
        }
    }
}