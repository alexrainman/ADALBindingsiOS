// Copyright (c) Microsoft Corporation.
// All rights reserved.
//
// This code is licensed under the MIT License.
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files(the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and / or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions :
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

#import <Foundation/Foundation.h>

#if TARGET_OS_IPHONE
#import <UIKit/UIKit.h>
#endif

//! Project version number for ADALFramework.
FOUNDATION_EXPORT double ADALFrameworkVersionNumber;

//! Project version string for ADALFramework.
FOUNDATION_EXPORT const unsigned char ADALFrameworkVersionString[];

#if TARGET_OS_IPHONE
//iOS:
typedef UIWebView WebViewType;
#else
//OS X:
#   include <WebKit/WebKit.h>
typedef WebView   WebViewType;
#endif

@class ADAuthenticationResult;

/*! The completion block declaration. */
typedef void(^ADAuthenticationCallback)(ADAuthenticationResult* result);

#import "ADAuthenticationContext.h"
#import "ADAuthenticationError.h"
#import "ADAuthenticationParameters.h"
#import "ADAuthenticationResult.h"
#import "ADAuthenticationSettings.h"
#import "ADErrorCodes.h"
#import "ADLogger.h"
#import "ADTokenCacheItem.h"
#import "ADUserIdentifier.h"
#import "ADUserInformation.h"
#import "ADWebAuthController.h"
#import "ADTelemetry.h"

#if TARGET_OS_IPHONE
#import "ADKeychainTokenCache.h"
#else
#import "ADTokenCache.h"
#endif

