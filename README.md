# BlackProxiesSharp [![Latest release](https://img.shields.io/github/v/release/Laiteux/BlackProxiesSharp?color=blue&style=flat-square)](https://github.com/Laiteux/BlackProxiesSharp/releases) [![License](https://img.shields.io/github/license/Laiteux/BlackProxiesSharp?color=blue&style=flat-square)](https://github.com/Laiteux/BlackProxiesSharp/blob/main/LICENSE)

The official .NET wrapper for the BlackProxies API.

### [PackageApi](https://github.com/Laiteux/BlackProxiesSharp/blob/main/src/BlackProxiesSharp/Api/PackageApi.cs)

- `Task<PackageModel> GetAsync()`
- `Task<PackageModel> StartAsync(IEnumerable<string> ips)`
- `Task<List<string>> GetProxiesAsync(string format = "host:port")`
- `Task<PackageModel> PauseAsync()`
- `Task<PackageModel> ResumeAsync()`
- `Task<PackageModel> RefreshPoolAsync()`
- `Task<PackageModel> UpdateWhitelistedIPsAsync(IEnumerable<string> ips)`

Example usage:

```cs
var package = new PackageApi("c212010f-aaa6-4ab4-a6cc-0e8485fedb4c");

IEnumerable<string> proxies = await package.GetProxiesAsync();

await File.WriteAllLinesAsync("Proxies.txt", proxies);
```

The above code will retrieve a package proxy list and save it to a `Proxies.txt` file.

### [ResellerApi](https://github.com/Laiteux/BlackProxiesSharp/blob/main/src/BlackProxiesSharp/Api/ResellerApi.cs)

- Coming very soon...

## Contribute

Your help is welcome, feel free to fork this repo and submit a pull request.

However, please make sure to follow the current code base/style.

## Contact

Telegram: [@BlackProxiesSupport](https://t.me/BlackProxiesSupport)

Email: support@proxies.black

## Donate

If you would like to support this project, please consider donating.

Donations are greatly appreciated and a motivation to keep improving.

- Bitcoin: `1LaiteuxHEH4GsMC9aVmnwgUEZyrG6BiTH`
