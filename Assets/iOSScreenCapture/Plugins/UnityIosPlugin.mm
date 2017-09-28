#import <Photos/Photos.h>
#import "CaptureCallback.h"

extern "C" void _PlaySystemShutterSound ()
{
    AudioServicesPlaySystemSound(1108);
}

extern "C" void _SendTexture (const void* byte, int length)
{
    NSData *data = [NSData dataWithBytes:byte length:length];
    UIImage *image = [[UIImage alloc]initWithData:data];
    CaptureCallback *callback = [[CaptureCallback alloc]init];
    UIImageWriteToSavedPhotosAlbum(image, callback, @selector(savingImageIsFinished:didFinishSavingWithError:contextInfo:), nil);
}

extern "C" void _RequestCameraPermission()
{
    [AVCaptureDevice requestAccessForMediaType:AVMediaTypeVideo completionHandler:^(BOOL granted) { }];
}

extern "C" void _RequestCameraRollPermission()
{
    [PHPhotoLibrary requestAuthorization:^(PHAuthorizationStatus status) { }];
}

extern "C" int _HasCameraPermission()
{
    AVAuthorizationStatus authStatus = [AVCaptureDevice authorizationStatusForMediaType:AVMediaTypeVideo];
    return (int)authStatus;
}

extern "C" int _HasCameraRollPermission()
{
    PHAuthorizationStatus authStatus = [PHPhotoLibrary authorizationStatus];
    return (int)authStatus;
}

extern "C" void _GoToSettings()
{
    [[UIApplication sharedApplication] openURL:[NSURL URLWithString:UIApplicationOpenSettingsURLString]];
}

