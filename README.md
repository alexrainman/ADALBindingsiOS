## Microsoft Azure Active Directory Authentication Library (ADAL) for iOS and macOS (C# Bindings)

ADAL .Net and Intune SDK token cache are incompatible. To use ADAL as authentication mechanism with Intune in Xamarin.iOS, a binding of the native Obj-C library is needed.

### Setup

* Available on NuGet: https://www.nuget.org/packages/ADALBindingsiOS/ [![NuGet](https://img.shields.io/nuget/v/ADALBindingsiOS.svg?label=NuGet)](https://www.nuget.org/packages/ADALBindingsiOS/)
* Install in your Xamarin.iOS project.
  
### Usage

#### Shared Interface

```cs
public interface IAuthenticator
{
    Task Authenticate(string ResourceUri);
    string AccessToken(string upn, string aadId, string resourceId);
    void SignOut();
}
```

#### Xamarin.iOS implementation

```cs
public class Authenticator: IAuthenticator
{
    public async Task Authenticate(string ResourceUri)
    {
        var authContext = new ADAuthenticationContext(Constants.ADALAuthority, false, out ADAuthenticationError error);
        var uri = new Uri(Constants.ADALRedirectUri);
        var domain_hint = "domain_hint=yourdomain.com"; // "&scope=openid&p=B2C_1_xyz_sign_in"

        var identity = CrossKeyChain.Current.GetKey("upn");

        var result = await authContext.AcquireTokenWithResourceAsync(ResourceUri, Constants.ADALClientId, uri, identity, domain_hint);

        CrossKeyChain.Current.SetKey("upn", result.TokenCacheItem.UserInformation.Upn);
        CrossKeyChain.Current.SetKey("aadId", result.TokenCacheItem.UserInformation.UniqueId);
    }

    public string AccessToken(string upn, string aadId, string resourceId)
    {
        try
        {
            var item = ADTokenCacheItem(upn, aadId, resourceId);
            return item.AccessToken;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return "";
        }
    }

    // IsEmptyUSer will return YES, if server doesn't return an id_token (not OIDC compliant).
    private ADTokenCacheItem ADTokenCacheItem(string upn, string aadId, string resourceId)
    {
        return ADKeychainTokenCache.DefaultKeychainCache().AllItems(out ADAuthenticationError error)
                                   .Last(arg => !string.IsNullOrEmpty(arg.AccessToken)
                                         && arg.UserInformation.Upn == upn
                                         && arg.UserInformation.UniqueId == aadId
                                         && arg.Resource == resourceId
                                         && !arg.IsExpired
                                         && !arg.IsEmptyUser);
    }

    public void SignOut()
    {
        var items = ADKeychainTokenCache.DefaultKeychainCache().AllItems(out ADAuthenticationError error);
        foreach (var item in items)
        {
            ADKeychainTokenCache.DefaultKeychainCache().RemoveItem(item, out error);
        }
    }
}   
```

#### AppDelegate.cs

```cs
SimpleIoc.Default.Register<IAuthenticator, Authenticator>();
```

#### Authenticate

```cs
var authenticator = SimpleIoc.Default.GetInstance<IAuthenticator>();
await authenticator.Authenticate(Constants.ResourceUri);
```

#### Authorization Header

```cs
var upn = CrossKeyChain.Current.GetKey("upn");
var aadId = CrossKeyChain.Current.GetKey("aadId");
var accessToken = authenticator.AccessToken(upn, aadId, Constants.ResourceUri);

client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
```

### Building the .a library:

1.) Download ADAL for Objective-C version 2.6.5

2.) Open ADAL.xcworkspace in Xcode

3.) Change the build target to "ADALiOS"

4.) Change the build configuration from Debug to Release

5.) Build for any simulator

6.) In the project explorer, expand ADAL -> Products

7.) Right click libADALiOS.a and select "Show in Finder". The path of the Finder window that appears should end in "Release-iphonesimulator", and you should see a file called libADALiOS.a in that directory if everything was done correctly

9.) Plug in a physical device and build for that device

10.) Right click libADALiOS.a and select "Show in Finder". The path of the Finder window that appears should end in "Release-iphoneos", and you should see a file called libADALiOS.a in that directory if everything was done correctly

11.) Open a terminal window and run the following:

```bash
lipo -create <path to iphoneos libADALiOS.a> <path to iphonesimulator libADALiOS.a> -output <path to new combined libADALiOS.a>
```
  
12.) Use the combined library to create the bindings. All the public headers for iOS can be found in the "include" folder of either build directory

13.) Use ObjectiveSharpie to generate API definitions and structures

```bash
sharpie bind --output=ADAL --namespace=ADAL --sdk=iphoneos11.4 -scope /ADALBindingsiOS/Headers /ADALBindingsiOS/Headers/*.h
```

14. ) Follow this link for more details about using ObjectiveSharpie and normalizing the API definitons: https://docs.microsoft.com/en-us/xamarin/ios/platform/binding-objective-c/walkthrough?tabs=vsmac#using-objective-sharpie

