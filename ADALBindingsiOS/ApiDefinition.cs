using System;
using System.Threading.Tasks;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace ADAL
{
    [Static]
    partial interface Constants
    {
        // extern double ADALFrameworkVersionNumber;
        //[Field("ADALFrameworkVersionNumber", "__Internal")]
        //double ADALFrameworkVersionNumber { get; }

        // extern const unsigned char [] ADALFrameworkVersionString;
        [Field("ADALFrameworkVersionString", "__Internal")]
        NSString ADALFrameworkVersionString { get; }

        // extern NSString *const ADAuthenticationErrorDomain;
        [Field("ADAuthenticationErrorDomain", "__Internal")]
        NSString ADAuthenticationErrorDomain { get; }

        // extern NSString *const ADBrokerResponseErrorDomain;
        [Field("ADBrokerResponseErrorDomain", "__Internal")]
        NSString ADBrokerResponseErrorDomain { get; }

        // extern NSString *const ADKeychainErrorDomain;
        [Field("ADKeychainErrorDomain", "__Internal")]
        NSString ADKeychainErrorDomain { get; }

        // extern NSString *const ADHTTPErrorCodeDomain;
        [Field("ADHTTPErrorCodeDomain", "__Internal")]
        NSString ADHTTPErrorCodeDomain { get; }

        // extern NSString *const ADOAuthServerErrorDomain;
        [Field("ADOAuthServerErrorDomain", "__Internal")]
        NSString ADOAuthServerErrorDomain { get; }

        // extern NSString *const ADHTTPHeadersKey;
        [Field("ADHTTPHeadersKey", "__Internal")]
        NSString ADHTTPHeadersKey { get; }

        // extern NSString *const ADSuberrorKey;
        [Field("ADSuberrorKey", "__Internal")]
        NSString ADSuberrorKey { get; }

        // extern NSString *const ADBrokerVersionKey;
        [Field("ADBrokerVersionKey", "__Internal")]
        NSString ADBrokerVersionKey { get; }

        // extern NSString *const ADUserIdKey;
        [Field("ADUserIdKey", "__Internal")]
        NSString ADUserIdKey { get; }

        // extern NSString * ADWebAuthDidStartLoadNotification;
        [Field("ADWebAuthDidStartLoadNotification", "__Internal")]
        NSString ADWebAuthDidStartLoadNotification { get; }

        // extern NSString * ADWebAuthDidFinishLoadNotification;
        [Field("ADWebAuthDidFinishLoadNotification", "__Internal")]
        NSString ADWebAuthDidFinishLoadNotification { get; }

        // extern NSString * ADWebAuthDidFailNotification;
        [Field("ADWebAuthDidFailNotification", "__Internal")]
        NSString ADWebAuthDidFailNotification { get; }

        // extern NSString * ADWebAuthDidCompleteNotification;
        [Field("ADWebAuthDidCompleteNotification", "__Internal")]
        NSString ADWebAuthDidCompleteNotification { get; }

        // extern NSString * ADWebAuthWillSwitchToBrokerApp;
        [Field("ADWebAuthWillSwitchToBrokerApp", "__Internal")]
        NSString ADWebAuthWillSwitchToBrokerApp { get; }

        // extern NSString * ADWebAuthDidReceieveResponseFromBroker;
        [Field("ADWebAuthDidReceieveResponseFromBroker", "__Internal")]
        NSString ADWebAuthDidReceieveResponseFromBroker { get; }
    }

    // typedef void (^ADAuthenticationCallback)(ADAuthenticationResult *);
    delegate void ADAuthenticationCallback(ADAuthenticationResult result);

    // @interface ADAuthenticationContext : NSObject
    [BaseType(typeof(NSObject))]
    interface ADAuthenticationContext
    {
        // -(id)initWithAuthority:(NSString *)authority validateAuthority:(BOOL)validateAuthority sharedGroup:(NSString *)sharedGroup error:(ADAuthenticationError **)error;
        [Export("initWithAuthority:validateAuthority:sharedGroup:error:")]
        IntPtr Constructor(string authority, bool validateAuthority, string sharedGroup, out ADAuthenticationError error);

        // -(id)initWithAuthority:(NSString *)authority validateAuthority:(BOOL)validateAuthority error:(ADAuthenticationError **)error;
        [Export("initWithAuthority:validateAuthority:error:")]
        IntPtr Constructor(string authority, bool validateAuthority, out ADAuthenticationError error);

        // +(ADAuthenticationContext *)authenticationContextWithAuthority:(NSString *)authority error:(ADAuthenticationError **)error;
        [Static]
        [Export("authenticationContextWithAuthority:error:")]
        ADAuthenticationContext AuthenticationContextWithAuthority(string authority, out ADAuthenticationError error);

        // +(ADAuthenticationContext *)authenticationContextWithAuthority:(NSString *)authority validateAuthority:(BOOL)validate error:(ADAuthenticationError **)error;
        [Static]
        [Export("authenticationContextWithAuthority:validateAuthority:error:")]
        ADAuthenticationContext AuthenticationContextWithAuthority(string authority, bool validate, out ADAuthenticationError error);

        // +(ADAuthenticationContext *)authenticationContextWithAuthority:(NSString *)authority sharedGroup:(NSString *)sharedGroup error:(ADAuthenticationError **)error;
        [Static]
        [Export("authenticationContextWithAuthority:sharedGroup:error:")]
        ADAuthenticationContext AuthenticationContextWithAuthority(string authority, string sharedGroup, out ADAuthenticationError error);

        // +(ADAuthenticationContext *)authenticationContextWithAuthority:(NSString *)authority validateAuthority:(BOOL)validate sharedGroup:(NSString *)sharedGroup error:(ADAuthenticationError **)error;
        [Static]
        [Export("authenticationContextWithAuthority:validateAuthority:sharedGroup:error:")]
        ADAuthenticationContext AuthenticationContextWithAuthority(string authority, bool validate, string sharedGroup, out ADAuthenticationError error);

        // +(BOOL)isResponseFromBroker:(NSString *)sourceApplication response:(NSURL *)response;
        [Static]
        [Export("isResponseFromBroker:response:")]
        bool IsResponseFromBroker(string sourceApplication, NSUrl response);

        // +(BOOL)handleBrokerResponse:(NSURL *)response;
        [Static]
        [Export("handleBrokerResponse:")]
        bool HandleBrokerResponse(NSUrl response);

        // @property (readonly) NSString * authority;
        [Export("authority")]
        string Authority { get; }

        // @property BOOL validateAuthority;
        [Export("validateAuthority")]
        bool ValidateAuthority { get; set; }

        // @property (strong) NSUUID * correlationId;
        [Export("correlationId", ArgumentSemantic.Strong)]
        NSUuid CorrelationId { get; set; }

        // @property ADCredentialsType credentialsType;
        [Export("credentialsType", ArgumentSemantic.Assign)]
        ADCredentialsType CredentialsType { get; set; }

        // @property (retain) NSString * logComponent;
        [Export("logComponent", ArgumentSemantic.Retain)]
        string LogComponent { get; set; }

        // @property (weak) UIViewController * parentController;
        [Export("parentController", ArgumentSemantic.Weak)]
        UIViewController ParentController { get; set; }

        // @property (weak) WebViewType * webView;
        [Export("webView", ArgumentSemantic.Weak)]
        UIWebView WebView { get; set; }

        // @property BOOL extendedLifetimeEnabled;
        [Export("extendedLifetimeEnabled")]
        bool ExtendedLifetimeEnabled { get; set; }

        // -(void)acquireTokenForAssertion:(NSString *)assertion assertionType:(ADAssertionType)assertionType resource:(NSString *)resource clientId:(NSString *)clientId userId:(NSString *)userId completionBlock:(ADAuthenticationCallback)completionBlock;
        [Export("acquireTokenForAssertion:assertionType:resource:clientId:userId:completionBlock:")]
        [Async]
        void AcquireTokenForAssertion(string assertion, ADAssertionType assertionType, string resource, string clientId, string userId, ADAuthenticationCallback completionBlock);

        // -(void)acquireTokenWithResource:(NSString *)resource clientId:(NSString *)clientId redirectUri:(NSURL *)redirectUri completionBlock:(ADAuthenticationCallback)completionBlock;
        [Export("acquireTokenWithResource:clientId:redirectUri:completionBlock:")]
        [Async]
        void AcquireTokenWithResource(string resource, string clientId, NSUrl redirectUri, ADAuthenticationCallback completionBlock);

        // -(void)acquireTokenWithResource:(NSString *)resource clientId:(NSString *)clientId redirectUri:(NSURL *)redirectUri userId:(NSString *)userId completionBlock:(ADAuthenticationCallback)completionBlock;
        [Export("acquireTokenWithResource:clientId:redirectUri:userId:completionBlock:")]
        [Async]
        void AcquireTokenWithResource(string resource, string clientId, NSUrl redirectUri, string userId, ADAuthenticationCallback completionBlock);

        // -(void)acquireTokenWithResource:(NSString *)resource clientId:(NSString *)clientId redirectUri:(NSURL *)redirectUri userId:(NSString *)userId extraQueryParameters:(NSString *)queryParams completionBlock:(ADAuthenticationCallback)completionBlock;
        [Export("acquireTokenWithResource:clientId:redirectUri:userId:extraQueryParameters:completionBlock:")]
        [Async]
        void AcquireTokenWithResource(string resource, string clientId, NSUrl redirectUri, string userId, string queryParams, ADAuthenticationCallback completionBlock);

        // -(void)acquireTokenWithResource:(NSString *)resource clientId:(NSString *)clientId redirectUri:(NSURL *)redirectUri promptBehavior:(ADPromptBehavior)promptBehavior userId:(NSString *)userId extraQueryParameters:(NSString *)queryParams completionBlock:(ADAuthenticationCallback)completionBlock;
        [Export("acquireTokenWithResource:clientId:redirectUri:promptBehavior:userId:extraQueryParameters:completionBlock:")]
        [Async]
        void AcquireTokenWithResource(string resource, string clientId, NSUrl redirectUri, ADPromptBehavior promptBehavior, string userId, string queryParams, ADAuthenticationCallback completionBlock);

        // -(void)acquireTokenWithResource:(NSString *)resource clientId:(NSString *)clientId redirectUri:(NSURL *)redirectUri promptBehavior:(ADPromptBehavior)promptBehavior userIdentifier:(ADUserIdentifier *)userId extraQueryParameters:(NSString *)queryParams completionBlock:(ADAuthenticationCallback)completionBlock;
        [Export("acquireTokenWithResource:clientId:redirectUri:promptBehavior:userIdentifier:extraQueryParameters:completionBlock:")]
        [Async]
        void AcquireTokenWithResource(string resource, string clientId, NSUrl redirectUri, ADPromptBehavior promptBehavior, ADUserIdentifier userId, string queryParams, ADAuthenticationCallback completionBlock);

        // -(void)acquireTokenWithResource:(NSString *)resource clientId:(NSString *)clientId redirectUri:(NSURL *)redirectUri promptBehavior:(ADPromptBehavior)promptBehavior userIdentifier:(ADUserIdentifier *)userId extraQueryParameters:(NSString *)queryParams claims:(NSString *)claims completionBlock:(ADAuthenticationCallback)completionBlock;
        [Export("acquireTokenWithResource:clientId:redirectUri:promptBehavior:userIdentifier:extraQueryParameters:claims:completionBlock:")]
        [Async]
        void AcquireTokenWithResource(string resource, string clientId, NSUrl redirectUri, ADPromptBehavior promptBehavior, ADUserIdentifier userId, string queryParams, string claims, ADAuthenticationCallback completionBlock);

        // -(void)acquireTokenSilentWithResource:(NSString *)resource clientId:(NSString *)clientId redirectUri:(NSURL *)redirectUri completionBlock:(ADAuthenticationCallback)completionBlock;
        [Export("acquireTokenSilentWithResource:clientId:redirectUri:completionBlock:")]
        [Async]
        void AcquireTokenSilentWithResource(string resource, string clientId, NSUrl redirectUri, ADAuthenticationCallback completionBlock);

        // -(void)acquireTokenSilentWithResource:(NSString *)resource clientId:(NSString *)clientId redirectUri:(NSURL *)redirectUri userId:(NSString *)userId completionBlock:(ADAuthenticationCallback)completionBlock;
        [Export("acquireTokenSilentWithResource:clientId:redirectUri:userId:completionBlock:")]
        [Async]
        void AcquireTokenSilentWithResource(string resource, string clientId, NSUrl redirectUri, string userId, ADAuthenticationCallback completionBlock);

        // -(void)acquireTokenSilentWithResource:(NSString *)resource clientId:(NSString *)clientId redirectUri:(NSURL *)redirectUri userId:(NSString *)userId forceRefresh:(BOOL)forceRefresh completionBlock:(ADAuthenticationCallback)completionBlock;
        [Export("acquireTokenSilentWithResource:clientId:redirectUri:userId:forceRefresh:completionBlock:")]
        [Async]
        void AcquireTokenSilentWithResource(string resource, string clientId, NSUrl redirectUri, string userId, bool forceRefresh, ADAuthenticationCallback completionBlock);

        // -(void)acquireTokenWithRefreshToken:(NSString *)refreshToken resource:(NSString *)resource clientId:(NSString *)clientId redirectUri:(NSURL *)redirectUri completionBlock:(ADAuthenticationCallback)completionBlock;
        [Export("acquireTokenWithRefreshToken:resource:clientId:redirectUri:completionBlock:")]
        [Async]
        void AcquireTokenWithRefreshToken(string refreshToken, string resource, string clientId, NSUrl redirectUri, ADAuthenticationCallback completionBlock);
    }

    // @interface ADAuthenticationError : NSError
    [BaseType(typeof(NSError))]
    interface ADAuthenticationError
    {
        // @property (readonly) NSString * protocolCode;
        [Export("protocolCode")]
        string ProtocolCode { get; }

        // @property (readonly) NSString * errorDetails;
        [Export("errorDetails")]
        string ErrorDetails { get; }
    }

    // @interface ADAuthenticationParameters : NSObject
    [BaseType(typeof(NSObject))]
    interface ADAuthenticationParameters
    {
        // @property (readonly) NSString * authority;
        [Export("authority")]
        string Authority { get; }

        // @property (readonly) NSString * resource;
        [Export("resource")]
        string Resource { get; }

        // @property (readonly) NSDictionary * extractedParameters;
        [Export("extractedParameters")]
        NSDictionary ExtractedParameters { get; }

        // +(ADAuthenticationParameters *)parametersFromResponse:(NSHTTPURLResponse *)response error:(ADAuthenticationError **)error;
        [Static]
        [Export("parametersFromResponse:error:")]
        ADAuthenticationParameters ParametersFromResponse(NSHttpUrlResponse response, out ADAuthenticationError error);

        // +(ADAuthenticationParameters *)parametersFromResponseAuthenticateHeader:(NSString *)authenticateHeader error:(ADAuthenticationError **)error;
        [Static]
        [Export("parametersFromResponseAuthenticateHeader:error:")]
        ADAuthenticationParameters ParametersFromResponseAuthenticateHeader(string authenticateHeader, out ADAuthenticationError error);

        // +(void)parametersFromResourceUrl:(NSURL *)resourceUrl completionBlock:(ADParametersCompletion)completionBlock;
        [Static]
        [Export("parametersFromResourceUrl:completionBlock:")]
        [Async(ResultType = typeof(ADAuthenticationParameters), ResultTypeName = "parameters")]
        void ParametersFromResourceUrl(NSUrl resourceUrl, ADParametersCompletion completionBlock);
    }

    // typedef void (^ADParametersCompletion)(ADAuthenticationParameters *, ADAuthenticationError *);
    delegate void ADParametersCompletion(ADAuthenticationParameters parameters, ADAuthenticationError error);

    // @interface ADAuthenticationResult : NSObject
    [BaseType(typeof(NSObject))]
    interface ADAuthenticationResult
    {
        // @property (readonly) ADAuthenticationResultStatus status;
        [Export("status")]
        ADAuthenticationResultStatus Status { get; }

        // @property (readonly) NSString * accessToken;
        [Export("accessToken")]
        string AccessToken { get; }

        // @property (readonly) ADTokenCacheItem * tokenCacheItem;
        [Export("tokenCacheItem")]
        ADTokenCacheItem TokenCacheItem { get; }

        // @property (readonly) ADAuthenticationError * error;
        [Export("error")]
        ADAuthenticationError Error { get; }

        // @property (readonly) BOOL multiResourceRefreshToken;
        [Export("multiResourceRefreshToken")]
        bool MultiResourceRefreshToken { get; }

        // @property (readonly) NSUUID * correlationId;
        [Export("correlationId")]
        NSUuid CorrelationId { get; }

        // @property (readonly) BOOL extendedLifeTimeToken;
        [Export("extendedLifeTimeToken")]
        bool ExtendedLifeTimeToken { get; }

        // @property (readonly) NSString * authority;
        [Export("authority")]
        string Authority { get; }
    }

    // @interface ADAuthenticationSettings : NSObject
    [BaseType(typeof(NSObject))]
    interface ADAuthenticationSettings
    {
        // +(ADAuthenticationSettings *)sharedInstance;
        [Static]
        [Export("sharedInstance")]
        ADAuthenticationSettings SharedInstance { get; }

        // @property int requestTimeOut;
        [Export("requestTimeOut")]
        int RequestTimeOut { get; set; }

        // @property uint expirationBuffer;
        [Export("expirationBuffer")]
        uint ExpirationBuffer { get; set; }

        // @property BOOL enableFullScreen;
        [Export("enableFullScreen")]
        bool EnableFullScreen { get; set; }

        // -(NSString *)defaultKeychainGroup;
        // -(void)setDefaultKeychainGroup:(NSString *)keychainGroup;
        [Export("defaultKeychainGroup")]
        string DefaultKeychainGroup { get; set; }
    }

    // @interface ADLogger : NSObject
    [BaseType(typeof(NSObject))]
    interface ADLogger
    {
        // +(void)setLevel:(ADAL_LOG_LEVEL)logLevel;
        [Static]
        [Export("setLevel:")]
        void SetLevel(AdalLogLevel logLevel);

        // +(ADAL_LOG_LEVEL)getLevel;
        [Static]
        [Export("getLevel")]
        AdalLogLevel Level { get; }

        // +(void)setPiiEnabled:(BOOL)piiEnabled;
        [Static]
        [Export("setPiiEnabled:")]
        void SetPiiEnabled(bool piiEnabled);

        // +(BOOL)getPiiEnabled;
        [Static]
        [Export("getPiiEnabled")]
        bool PiiEnabled { get; }

        // +(void)setLogCallBack:(LogCallback)callback __attribute__((deprecated("Use the setLoggerCallback: method instead.")));
        [Static]
        [Export("setLogCallBack:")]
        void SetLogCallBack(LogCallback callback);

        // +(void)setLoggerCallback:(ADLoggerCallback)callback;
        [Static]
        [Export("setLoggerCallback:")]
        void SetLoggerCallback(ADLoggerCallback callback);

        // +(void)setNSLogging:(BOOL)nslogging;
        [Static]
        [Export("setNSLogging:")]
        void SetNSLogging(bool nslogging);

        // +(BOOL)getNSLogging;
        [Static]
        [Export("getNSLogging")]
        bool NSLogging { get; }
    }

    // typedef void (^LogCallback)(ADAL_LOG_LEVEL, NSString *, NSString *, NSInteger, NSDictionary *);
    delegate void LogCallback(AdalLogLevel logLevel, string message, string additionalInfo, nint errorCode, NSDictionary userInfo);

    // typedef void (^ADLoggerCallback)(ADAL_LOG_LEVEL, NSString *, BOOL);
    delegate void ADLoggerCallback(AdalLogLevel logLevel, string message, bool containsPii);

    // @interface ADTokenCacheItem : NSObject <NSCopying, NSSecureCoding>
    [BaseType(typeof(NSObject))]
    interface ADTokenCacheItem : INSCopying, INSSecureCoding
    {
        // @property (copy) NSString * _Nullable resource;
        [NullAllowed, Export("resource")]
        string Resource { get; set; }

        // @property (copy) NSString * _Nonnull authority;
        [Export("authority")]
        string Authority { get; set; }

        // @property (copy) NSString * _Nullable clientId;
        [NullAllowed, Export("clientId")]
        string ClientId { get; set; }

        // @property (copy) NSString * _Nullable familyId;
        [NullAllowed, Export("familyId")]
        string FamilyId { get; set; }

        // @property (copy) NSString * _Nullable accessToken;
        [NullAllowed, Export("accessToken")]
        string AccessToken { get; set; }

        // @property (copy) NSString * _Nullable accessTokenType;
        [NullAllowed, Export("accessTokenType")]
        string AccessTokenType { get; set; }

        // @property (copy) NSString * _Nullable refreshToken;
        [NullAllowed, Export("refreshToken")]
        string RefreshToken { get; set; }

        // @property (copy) NSData * _Nullable sessionKey;
        [NullAllowed, Export("sessionKey", ArgumentSemantic.Copy)]
        NSData SessionKey { get; set; }

        // @property (copy) NSDate * _Nullable expiresOn;
        [NullAllowed, Export("expiresOn", ArgumentSemantic.Copy)]
        NSDate ExpiresOn { get; set; }

        // @property (retain) ADUserInformation * _Nullable userInformation;
        [NullAllowed, Export("userInformation", ArgumentSemantic.Retain)]
        ADUserInformation UserInformation { get; set; }

        // -(ADTokenCacheKey * _Nullable)extractKey:(ADAuthenticationError * _Nullable * _Nullable)error;
        [Export("extractKey:")]
        [return: NullAllowed]
        ADTokenCacheKey ExtractKey([NullAllowed] out ADAuthenticationError error);

        // -(BOOL)isExpired;
        [Export("isExpired")]
        bool IsExpired { get; }

        // -(BOOL)isEmptyUser;
        [Export("isEmptyUser")]
        bool IsEmptyUser { get; }

        // -(BOOL)isMultiResourceRefreshToken;
        [Export("isMultiResourceRefreshToken")]
        bool IsMultiResourceRefreshToken { get; }
    }

    // @interface ADUserIdentifier : NSObject <NSCopying>
    [BaseType(typeof(NSObject))]
    interface ADUserIdentifier : INSCopying
    {
        // @property (readonly, retain) NSString * userId;
        [Export("userId", ArgumentSemantic.Retain)]
        string UserId { get; }

        // @property (readonly) ADUserIdentifierType type;
        [Export("type")]
        ADUserIdentifierType Type { get; }

        // +(ADUserIdentifier *)identifierWithId:(NSString *)userId;
        [Static]
        [Export("identifierWithId:")]
        ADUserIdentifier IdentifierWithId(string userId);

        // +(ADUserIdentifier *)identifierWithId:(NSString *)userId type:(ADUserIdentifierType)type;
        [Static]
        [Export("identifierWithId:type:")]
        ADUserIdentifier IdentifierWithId(string userId, ADUserIdentifierType type);

        // +(ADUserIdentifier *)identifierWithId:(NSString *)userId typeFromString:(NSString *)type;
        [Static]
        [Export("identifierWithId:typeFromString:")]
        ADUserIdentifier IdentifierWithId(string userId, string type);

        // +(BOOL)identifier:(ADUserIdentifier *)identifier matchesInfo:(ADUserInformation *)info;
        [Static]
        [Export("identifier:matchesInfo:")]
        bool Identifier(ADUserIdentifier identifier, ADUserInformation info);

        // -(NSString *)userIdMatchString:(ADUserInformation *)info;
        [Export("userIdMatchString:")]
        string UserIdMatchString(ADUserInformation info);

        // -(NSString *)typeAsString;
        [Export("typeAsString")]
        string TypeAsString { get; }

        // +(NSString *)stringForType:(ADUserIdentifierType)type;
        [Static]
        [Export("stringForType:")]
        string StringForType(ADUserIdentifierType type);

        // -(BOOL)isDisplayable;
        [Export("isDisplayable")]
        bool IsDisplayable { get; }
    }

    // @interface ADUserInformation : NSObject <NSCopying, NSSecureCoding>
    [BaseType(typeof(NSObject))]
    interface ADUserInformation : INSCopying, INSSecureCoding
    {
        // +(ADUserInformation *)userInformationWithIdToken:(NSString *)idToken error:(ADAuthenticationError **)error;
        [Static]
        [Export("userInformationWithIdToken:error:")]
        ADUserInformation UserInformationWithIdToken(string idToken, out ADAuthenticationError error);

        // @property (readonly) NSString * userId;
        [Export("userId")]
        string UserId { get; }

        // @property (readonly) BOOL userIdDisplayable;
        [Export("userIdDisplayable")]
        bool UserIdDisplayable { get; }

        // @property (readonly) NSString * uniqueId;
        [Export("uniqueId")]
        string UniqueId { get; }

        // @property (readonly) NSString * givenName;
        [Export("givenName")]
        string GivenName { get; }

        // @property (readonly) NSString * familyName;
        [Export("familyName")]
        string FamilyName { get; }

        // @property (readonly) NSString * identityProvider;
        [Export("identityProvider")]
        string IdentityProvider { get; }

        // @property (readonly) NSString * eMail;
        [Export("eMail")]
        string EMail { get; }

        // @property (readonly) NSString * uniqueName;
        [Export("uniqueName")]
        string UniqueName { get; }

        // @property (readonly) NSString * upn;
        [Export("upn")]
        string Upn { get; }

        // @property (readonly) NSString * tenantId;
        [Export("tenantId")]
        string TenantId { get; }

        // @property (readonly) NSString * subject;
        [Export("subject")]
        string Subject { get; }

        // @property (readonly) NSString * userObjectId;
        [Export("userObjectId")]
        string UserObjectId { get; }

        // @property (readonly) NSString * guestId;
        [Export("guestId")]
        string GuestId { get; }

        // @property (readonly) NSString * rawIdToken;
        [Export("rawIdToken")]
        string RawIdToken { get; }

        // @property (readonly) NSDictionary * allClaims;
        [Export("allClaims")]
        NSDictionary AllClaims { get; }

        // +(NSString *)normalizeUserId:(NSString *)userId;
        [Static]
        [Export("normalizeUserId:")]
        string NormalizeUserId(string userId);
    }

    // @interface ADWebAuthController : NSObject
    [BaseType(typeof(NSObject))]
    interface ADWebAuthController
    {
        // +(void)cancelCurrentWebAuthSession;
        [Static]
        [Export("cancelCurrentWebAuthSession")]
        void CancelCurrentWebAuthSession();

        // +(ADAuthenticationResult *)responseFromInterruptedBrokerSession;
        [Static]
        [Export("responseFromInterruptedBrokerSession")]
        ADAuthenticationResult ResponseFromInterruptedBrokerSession { get; }
    }

    // @protocol ADDispatcher <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface ADDispatcher
    {
        // @required -(void)dispatchEvent:(NSDictionary<NSString *,NSString *> * _Nonnull)event;
        [Abstract]
        [Export("dispatchEvent:")]
        void DispatchEvent(NSDictionary<NSString, NSString> @event);
    }

    // @interface ADTelemetry : NSObject
    [BaseType(typeof(NSObject))]
    interface ADTelemetry
    {
        // +(ADTelemetry * _Nonnull)sharedInstance;
        [Static]
        [Export("sharedInstance")]
        ADTelemetry SharedInstance { get; }

        // @property (nonatomic) BOOL piiEnabled;
        [Export("piiEnabled")]
        bool PiiEnabled { get; set; }

        // -(void)addDispatcher:(id<ADDispatcher> _Nonnull)dispatcher aggregationRequired:(BOOL)aggregationRequired;
        [Export("addDispatcher:aggregationRequired:")]
        void AddDispatcher(ADDispatcher dispatcher, bool aggregationRequired);

        // -(void)removeDispatcher:(id<ADDispatcher> _Nonnull)dispatcher;
        [Export("removeDispatcher:")]
        void RemoveDispatcher(ADDispatcher dispatcher);

        // -(void)removeAllDispatchers;
        [Export("removeAllDispatchers")]
        void RemoveAllDispatchers();
    }

    // @interface ADKeychainTokenCache : NSObject
    [BaseType(typeof(NSObject))]
    interface ADKeychainTokenCache
    {
        // @property (readonly) NSString * _Nonnull sharedGroup;
        [Export("sharedGroup")]
        string SharedGroup { get; }

        // +(NSString * _Nullable)defaultKeychainGroup;
        // +(void)setDefaultKeychainGroup:(NSString * _Nullable)keychainGroup;
        [Static]
        [NullAllowed, Export("defaultKeychainGroup")]
        string DefaultKeychainGroup { get; set; }

        // +(ADKeychainTokenCache * _Nonnull)defaultKeychainCache;
        [Static]
        [Export("defaultKeychainCache")]
        ADKeychainTokenCache DefaultKeychainCache();

        // +(ADKeychainTokenCache * _Nonnull)keychainCacheForGroup:(NSString * _Nullable)group;
        [Static]
        [Export("keychainCacheForGroup:")]
        ADKeychainTokenCache KeychainCacheForGroup([NullAllowed] string group);

        // -(instancetype _Nullable)initWithGroup:(NSString * _Nullable)sharedGroup;
        [Export("initWithGroup:")]
        IntPtr Constructor([NullAllowed] string sharedGroup);

        // -(NSArray<ADTokenCacheItem *> * _Nullable)allItems:(ADAuthenticationError * _Nullable * _Nullable)error;
        [Export("allItems:")]
        [return: NullAllowed]
        ADTokenCacheItem[] AllItems([NullAllowed] out ADAuthenticationError error);

        // -(BOOL)removeItem:(ADTokenCacheItem * _Nonnull)item error:(ADAuthenticationError * _Nullable * _Nullable)error;
        [Export("removeItem:error:")]
        bool RemoveItem(ADTokenCacheItem item, [NullAllowed] out ADAuthenticationError error);

        // -(BOOL)removeAllForClientId:(NSString * _Nonnull)clientId error:(ADAuthenticationError * _Nullable * _Nullable)error;
        [Export("removeAllForClientId:error:")]
        bool RemoveAllForClientId(string clientId, [NullAllowed] out ADAuthenticationError error);

        // -(BOOL)removeAllForUserId:(NSString * _Nonnull)userId clientId:(NSString * _Nonnull)clientId error:(ADAuthenticationError * _Nullable * _Nullable)error;
        [Export("removeAllForUserId:clientId:error:")]
        bool RemoveAllForUserId(string userId, string clientId, [NullAllowed] out ADAuthenticationError error);

        // -(BOOL)wipeAllItemsForUserId:(NSString * _Nonnull)userId error:(ADAuthenticationError * _Nullable * _Nullable)error;
        [Export("wipeAllItemsForUserId:error:")]
        bool WipeAllItemsForUserId(string userId, [NullAllowed] out ADAuthenticationError error);
    }

    // @interface ADTokenCacheKey : NSObject <NSCopying, NSSecureCoding>
    [BaseType(typeof(NSObject))]
    interface ADTokenCacheKey : INSCopying, INSSecureCoding
    {
        // +(ADTokenCacheKey *)keyWithAuthority:(NSString *)authority resource:(NSString *)resource clientId:(NSString *)clientId error:(ADAuthenticationError **)error;
        [Static]
        [Export("keyWithAuthority:resource:clientId:error:")]
        ADTokenCacheKey KeyWithAuthority(string authority, string resource, string clientId, out ADAuthenticationError error);

        // @property (readonly) NSString * authority;
        [Export("authority")]
        string Authority { get; }

        // @property (readonly) NSString * resource;
        [Export("resource")]
        string Resource { get; }

        // @property (readonly) NSString * clientId;
        [Export("clientId")]
        string ClientId { get; }

        // -(ADTokenCacheKey *)mrrtKey;
        [Export("mrrtKey")]
        ADTokenCacheKey MrrtKey { get; }
    }
}