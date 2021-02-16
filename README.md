# BlackProxiesSharp [![Latest release](https://img.shields.io/github/v/release/Laiteux/BlackProxiesSharp?color=blue&style=flat-square)](https://github.com/Laiteux/BlackProxiesSharp/releases) [![License](https://img.shields.io/github/license/Laiteux/BlackProxiesSharp?color=blue&style=flat-square)](https://github.com/Laiteux/BlackProxiesSharp/blob/main/LICENSE)

The official .NET wrapper for the BlackProxies API.

### [PackageApi](https://github.com/Laiteux/BlackProxiesSharp/blob/main/src/BlackProxiesSharp/Api/PackageApi.cs)

- `Task<PackageModel> GetAsync()`
- `Task<PackageModel> StartAsync(IEnumerable<string> ips)`
- `Task<IEnumerable<string>> GetProxiesAsync(string format = "host:port")`
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

- `Task<ResellerModel> GetAsync()`
- `Task<string> DepositAsync(double amount)`
- `Task<string> PurchasePackageAsync(int planId, int additionalTrafficGB = 0)`
- `Task<string> PurchasePackageAsync(PlanModel plan, int additionalTrafficGB = 0)`

Example usage:

```cs
var reseller = new ResellerApi("f2c5b80f-d57f-4403-82b2-c35bd7d4506b");

List<PlanModel> plans = (await reseller.GetAsync()).Plans;
PlanModel trialPlan = plans.Single(p => p.Billing == BillingType.Hourly);

string package = await reseller.PurchasePackageAsync(trialPlan);
Console.WriteLine($"Purchased trial plan. Package ID: {package}");
```

The above code will retrieve a reseller plan list and make a purchase for the trial (hourly) plan.
