XBUILD=/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild
PROJECT_ROOT=./Pods
PROJECT=$(PROJECT_ROOT)/Pods.xcodeproj
TARGET=ADAL

all: $(TARGET).a

$(TARGET)-i386.a:
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphonesimulator -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphonesimulator/ADAL/ADAL.framework/$(TARGET) $@

$(TARGET)-arm64.a:
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch arm64 -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphoneos/ADAL/ADAL.framework/$(TARGET) $@

$(TARGET).a: $(TARGET)-i386.a $(TARGET)-arm64.a
	xcrun -sdk iphoneos lipo -create -output $@ $^

clean:
	-rm -f *.a *.dll