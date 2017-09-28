#import <Foundation/Foundation.h>
 
@interface CaptureCallback : NSObject
 
- (void) savingImageIsFinished:(UIImage *)_image didFinishSavingWithError:(NSError *)_error contextInfo:(void *)_contextInfo;
 
@end