## Microsoft Azure Active Directory Authentication Library (ADAL) for iOS and macOS (C# Bindings)

### Build the .a library:

1.) Download ADAL for Objective-C version 2.6.5

2.) Open ADAL.xcworkspace in Xcode

3.) Change the build target to "ADALiOS"

4.) Change the build configuration from Debug to Release

5.) Build for any simulator

6.) In the project explorer, expand ADAL -> Products

7.) Right click libADALiOS.a and select "Show in Finder". The path of the Finder window that appears should end in "Release-iphonesimulator", and you should see a file called libADALiOS.a in that directory if everything was done correctly

9.) Plug in a physical device and build for that device

10.) Right click libADALiOS.a and select "Show in Finder". The path of the Finder window that appears should end in "Release-iphoneos", and you should see a file called libADALiOS.a in that directory if everything was done correctly

11.) Open a terminal window and run the following: lipo -create <path to iphoneos libADALiOS.a> <path to iphonesimulator libADALiOS.a> -output <path to new combined libADALiOS.a>
  
12.) Use the combined library to create the bindings. All the public headers for iOS can be found in the "include" folder of either build directory
  
### Shared Interface

```cs
public interface IAuthenticator
{
    Task Authenticate(string ResourceUri);
    void SignOut();
    string AccessToken { get; }
    string Identity { get; }
    string UniqueId { get; }
    string FullName { get; }
}
```

### Xamarin.iOS implementation

```cs
public class Authenticator: IAuthenticator
{
    public async Task Authenticate(string ResourceUri)
    {
        var authContext = new ADAuthenticationContext(Constants.ADALAuthority, false, out ADAuthenticationError error);
        var uri = new Uri(Constants.ADALRedirectUri);
        var domain_hint = "domain_hint=yourcompany.com";
        var identity = this.Identity;

        await authContext.AcquireTokenWithResourceAsync(ResourceUri, Constants.ADALClientId, uri, identity, domain_hint);
    }

    public void SignOut()
    {
        var items = ADKeychainTokenCache.DefaultKeychainCache().AllItems(out ADAuthenticationError error);
        foreach (var item in items)
        {
            ADKeychainTokenCache.DefaultKeychainCache().RemoveItem(item, out error);
        }
    }

    public string AccessToken
    {
        get
        {
            try
            {
                var item = ADTokenCacheItem();
                return item.AccessToken;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }
    }

    public string Identity
    {
        get
        {
            try
            {
                var item = ADTokenCacheItem();
                return item.UserInformation.Upn.ToLower();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }
    }

    public string UniqueId
    {
        get
        {
            try
            {
                var item = ADTokenCacheItem();
                return item.UserInformation.UniqueId;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }
    }

    public string FullName
    {
        get
        {
            try
            {
                var result = ADTokenCacheItem();
                return result.UserInformation.GivenName + " " + result.UserInformation.FamilyName;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }
    }

    private ADTokenCacheItem ADTokenCacheItem()
    {
        return ADKeychainTokenCache.DefaultKeychainCache().AllItems(out ADAuthenticationError error)
                                   .Last(arg => !string.IsNullOrEmpty(arg.AccessToken) && !arg.IsExpired && !arg.IsEmptyUser);
    }
}    
```
