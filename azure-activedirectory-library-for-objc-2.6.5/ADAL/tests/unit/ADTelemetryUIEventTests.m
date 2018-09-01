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

#import <XCTest/XCTest.h>
#import "ADTelemetryUIEvent.h"
#import "XCTestCase+TestHelperMethods.h"
#import "ADTelemetryEventStrings.h"

@interface ADTelemetryUIEventTests : XCTestCase

@end

@implementation ADTelemetryUIEventTests

- (void)setUp
{
    [super setUp];
}

- (void)tearDown
{
    [super tearDown];
}

- (void)testSetLoginHint_whenLogingHintNotNil_shouldHashLoginHint
{
    ADTelemetryUIEvent *event = [[ADTelemetryUIEvent alloc] initWithName:@"testEvent"
                                                                requestId:@"requestId"
                                                            correlationId:[NSUUID UUID]];
    
    [event setLoginHint:@"eric_cartman@contoso.com"];
    
    ADAssertStringEquals([event getProperties][AD_TELEMETRY_KEY_LOGIN_HINT], [@"eric_cartman@contoso.com" adComputeSHA256]);
}

@end
