using System;
using ObjCRuntime;

namespace ADAL
{
	public enum ADAssertionType : uint
	{
		AdSaml11,
		AdSaml2
	}

	public enum ADPromptBehavior : uint
	{
		PromptAuto,
		PromptAlways,
		PromptRefreshSession,
		ForcePrompt
	}

	public enum ADCredentialsType : uint
	{
		Auto,
		Embedded
	}

	public enum ADAuthenticationResultStatus : uint
	{
		Succeeded,
		UserCancelled,
		Failed
	}

	[Native]
	public enum ADErrorCode : nint
	{
		Succeeded = 0,
		Unexpected = -1,
		DeveloperInvalidArgument = 100,
		DeveloperAuthorityValidation = 101,
		ServerUserInputNeeded = 200,
		ServerWpjRequired = 201,
		ServerOauth = 202,
		ServerRefreshTokenRejected = 203,
		ServerWrongUser = 204,
		ServerNonHttpsRedirect = 205,
		ServerInvalidIdToken = 206,
		ServerMissingAuthenticateHeader = 207,
		ServerAuthenticateHeaderBadFormat = 208,
		ServerUnauthorizedCodeExpected = 209,
		ServerUnsupportedRequest = 210,
		ServerAuthorizationCode = 211,
		ServerInvalidResponse = 212,
		ServerProtectionPolicyRequired = 213,
		CacheMultipleUsers = 300,
		CacheVersionMismatch = 301,
		CacheBadFormat = 302,
		CacheNoRefreshToken = 303,
		UiMultlipleInteractiveRequests = 400,
		UiNoMainViewController = 401,
		UiNotSupportedInAppExtension = 402,
		UiUserCancel = 403,
		UiNotOnMainThread = 404,
		TokenbrokerUnknown = 500,
		TokenbrokerInvalidRedirectUri = 501,
		TokenbrokerResponseHashMismatch = 502,
		TokenbrokerResponseNotReceived = 503,
		TokenbrokerFailedToCreateKey = 504,
		TokenbrokerDecryptionFailed = 505,
		TokenbrokerNotABrokerResponse = 506,
		TokenbrokerNoResumeState = 507,
		TokenbrokerBadResumeState = 508,
		TokenbrokerMismatchedResumeState = 509,
		TokenbrokerHashMissing = 510,
		TokenbrokerNotSupportedInExtension = 511
	}

	public enum HTTPStatusCodes : uint
	{
		HttpUnauthorized = 401
	}

	public enum AdalLogLevel : uint
	{
		EvelNoLog,
		EvelError,
		EvelWarn,
		EvelInfo,
		EvelVerbose,
		Ast = EvelVerbose
	}

	public enum ADUserIdentifierType : uint
	{
		UniqueId,
		OptionalDisplayableId,
		RequiredDisplayableId
	}
}
