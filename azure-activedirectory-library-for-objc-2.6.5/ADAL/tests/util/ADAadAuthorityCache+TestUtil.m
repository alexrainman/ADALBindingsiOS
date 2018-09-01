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

#import "ADAadAuthorityCache+TestUtil.h"

#include <pthread.h>

@implementation ADAadAuthorityCache (TestUtil)

- (NSDictionary<NSString *, ADAadAuthorityCacheRecord *> *)recordMap
{
    return _recordMap;
}

- (void)setRecordMap:(NSDictionary<NSString *, ADAadAuthorityCacheRecord *> *)cacheDictionary
{
    _recordMap = [cacheDictionary mutableCopy];
}

- (BOOL)grabWriteLock
{
    return 0 == pthread_rwlock_wrlock(&_rwLock);
}

- (BOOL)tryWriteLock
{
    return 0 == pthread_rwlock_trywrlock(&_rwLock);
}

- (BOOL)grabReadLock
{
    return 0 == pthread_rwlock_rdlock(&_rwLock);
}

- (BOOL)unlock
{
    return 0 == pthread_rwlock_unlock(&_rwLock);
}

- (void)clear
{
    [self grabWriteLock];
    [_recordMap removeAllObjects];
    [self unlock];
}

@end
